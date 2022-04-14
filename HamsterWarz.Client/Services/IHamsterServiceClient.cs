using HamsterWarz.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterWarz.Client.Services
{
    public interface IHamsterServiceClient
    {
        Task<IEnumerable<Hamster>> GetHamstersAsync();
        Task<IEnumerable<Hamster>> GetCompetitorsAsync();
        Task VoteHamster(IEnumerable<Hamster> hamster, int id);
        Task<IEnumerable<Hamster>> GetTopCompetitors();
        Task RegisterMatchData(IEnumerable<Hamster> hamster, int id);
    }
}
