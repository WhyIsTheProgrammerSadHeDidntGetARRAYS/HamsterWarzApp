using HamsterWarz.API.Helper;
using HamsterWarz.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterWarz.API.Data.Interfaces
{
    public interface IHamsterService
    {
        Task<IEnumerable<Hamster>> GetHamstersAsync();
        Task<Hamster>? GetHamsterById(int id);
        Task<IEnumerable<Hamster>>? TopFiveWinners();
        Task<IEnumerable<Hamster>>? TopFiveLosers();
        Task<IEnumerable<Hamster>> GetHamsterCompetitorsAsync();
        Task VoteHamster(MatchWinnerDTO obj);
    }
}
