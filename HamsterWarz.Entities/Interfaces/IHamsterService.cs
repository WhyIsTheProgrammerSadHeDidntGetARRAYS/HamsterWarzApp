using HamsterWarz.Entities.Helper;
using HamsterWarz.Entities.Models;
using HamsterWarz.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterWarz.Entities.Interfaces
{
    public interface IHamsterService
    {
        Task AddHamster(HamsterViewModel newHamster);
        Task<IEnumerable<Hamster>> GetHamstersAsync();
        Task<Hamster>? GetHamsterById(int id);
        Task<IEnumerable<Hamster>>? TopFiveWinners();
        Task<IEnumerable<Hamster>>? TopFiveLosers();
        Task<IEnumerable<Hamster>> GetHamsterCompetitorsAsync();
        Task VoteHamster(MatchWinnersDTO obj);
        Task<int> DeleteHamster(int id);
    }
}
