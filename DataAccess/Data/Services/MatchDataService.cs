using DataAccess.Data.Interfaces;
using HamsterWarz.Entities.Helper;
using HamsterWarz.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Services
{
    public class MatchDataService : IMatchDataService
    {
        private readonly ApplicationDbContext _context;

        public MatchDataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MatchData>> GetAllMatchesAsync()
        {
            var matchData = await _context.MatchesData.ToListAsync();
            if (!matchData.Any())
            {
                return new List<MatchData>();
            }
            return matchData;
        }

        public async Task<MatchData> GetMatchById(int id)
        {
            var match = await _context.MatchesData.FirstOrDefaultAsync(x => x.Id == id);
            return match!;

        }

        public async Task RegisterMatchData(MatchWinnersDTO obj)
        {
            var winnerId = 0;
            var loserId = 0;

            foreach (var item in obj.Hamsters)
            {
                if (item.Id == obj.Id)
                {
                    winnerId = item.Id;
                }
                else
                {
                    loserId = item.Id;
                }
            }
            if (winnerId != 0 && loserId != 0)
            {
                var matchData = new MatchData() { WinnerId = winnerId, LoserId = loserId };
                await _context.MatchesData.AddAsync(matchData);
                _context.Entry(matchData).State = EntityState.Added;
            }

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// This method gets the id of a clicked hamster, and queries the database and selects all the hamsterobjects that the hamster in question has won against
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Hamster>> GetSpecificHamsterMatchData(int id)
        {
            var list = await (from md in _context.MatchesData
                              join winner in _context.Hamsters on md.WinnerId equals winner.Id
                              join losers in _context.Hamsters on md.LoserId equals losers.Id
                              where winner.Id == id
                              select losers).ToListAsync();

            return list;
        }

        public async Task<IEnumerable<MatchResultDTO>> GetAllHamsterMatches()
        {
            var list = await (from md in _context.MatchesData
                              join winner in _context.Hamsters on md.WinnerId equals winner.Id
                              join loser in _context.Hamsters on md.LoserId equals loser.Id
                              select new MatchResultDTO
                              {
                                  MatchId = md.Id,
                                  WinningHamster = winner,
                                  LosingHamster = loser,

                              }).ToListAsync();
            return list!;
        }

        public async Task DeleteMatch(int id)
        {
            var match = await _context.MatchesData.FirstOrDefaultAsync(x => x.Id == id);
            if (match != null)
            {
                _context.MatchesData.Remove(match);
            }
            await _context.SaveChangesAsync();
        }
    }
}
