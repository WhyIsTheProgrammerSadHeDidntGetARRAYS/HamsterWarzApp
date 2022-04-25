using HamsterWarz.API.Data.Interfaces;
using HamsterWarz.API.Helper;
using HamsterWarz.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterWarz.API.Data.Services
{
    public class HamsterService : IHamsterService
    {
        private readonly AppDbContext _context;

        public HamsterService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hamster>> GetHamstersAsync()
        {
            return await _context.Hamsters.ToListAsync();
        }
        public async Task<Hamster> GetHamsterById(int id)
        {
            var hamster = await _context.Hamsters.FirstOrDefaultAsync(x => x.Id == id);
            return hamster;
        }

        //since the hamsters are gonna "fight" 1 vs 1, we want to retrieve 2 "random" hamsterobjects from the list
        public async Task<IEnumerable<Hamster>> GetHamsterCompetitorsAsync()
        {
            return await _context.Hamsters.OrderBy(x => Guid.NewGuid()).Skip(1).Take(2).ToListAsync();
        }

        public async Task VoteHamster(MatchWinnerDTO obj)
        {
            int winnerId = obj.Id;
            var hamsterList = obj.Hamsters;
            if (hamsterList.Any()) //TODO: Kanske kan kolla att det faktiskt är 2 objekt i listan istället, ifall man på något sätt lyckas skicka iväg en hamster
            {
                foreach (var item in hamsterList)
                {
                    if (item.Id == winnerId)
                    {
                        item.Wins++;
                        item.TotalGames++;
                    }
                    else
                    {
                        item.Defeats++;
                        item.TotalGames++;

                    }
                    _context.Entry(item).State = EntityState.Modified;
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Hamster>> TopFiveWinners()
        {
            var list = await _context.Hamsters.OrderByDescending(x => x.Wins).Take(5).ToListAsync();
            return list;
        }
        public async Task<IEnumerable<Hamster>> TopFiveLosers()
        {
            var list = await _context.Hamsters.OrderByDescending(x => x.Defeats).Take(5).ToListAsync();
            return list;
        }
    }
}
