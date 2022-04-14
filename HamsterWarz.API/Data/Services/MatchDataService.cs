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
    public class MatchDataService : IMatchDataService
    {
        private readonly AppDbContext _context;

        public MatchDataService(AppDbContext context)
        {
            _context = context;
        }
        public async Task RegisterMatchData(TransferObject obj)
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
            if(winnerId != 0 && loserId != 0)
            {
                var matchData = new MatchData() { WinnerId = winnerId, LoserId = loserId };
                await _context.MatchesData.AddAsync(matchData);
                _context.Entry(matchData).State = EntityState.Added;
            }
            
            await _context.SaveChangesAsync();
        }
    }
}
