//using DataAccess.Data.Interfaces;
using HamsterWarz.Entities.Helper;
using HamsterWarz.Entities.Models;
using HamsterWarz.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HamsterWarz.Entities.ViewModels;

namespace DataAccess.Data.Services
{
    public class HamsterService : IHamsterService
    {
        private readonly ApplicationDbContext _context;

        public HamsterService(ApplicationDbContext context)
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
            return hamster!;
        }

        //since the hamsters are gonna "fight" 1 vs 1, we want to retrieve 2 "random" hamsterobjects from the list
        public async Task<IEnumerable<Hamster>> GetHamsterCompetitorsAsync()
        {
            return await _context.Hamsters.OrderBy(x => Guid.NewGuid()).Skip(1).Take(2).ToListAsync();
        }

        public async Task VoteHamster(MatchWinnersDTO obj)
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

        public async Task AddHamster(HamsterViewModel newHamster)
        {
            var hamster = new Hamster()
            {
                Name = newHamster.Name,
                Age = newHamster.Age,
                Loves = newHamster.Loves,
                ImageUrl = newHamster.ImageUrl
            };
            _context.Hamsters.Add(hamster);
            await _context.SaveChangesAsync();
        }
    }
}
