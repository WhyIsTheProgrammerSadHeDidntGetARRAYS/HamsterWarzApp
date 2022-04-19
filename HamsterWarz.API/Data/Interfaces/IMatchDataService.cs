using HamsterWarz.API.Helper;
using HamsterWarz.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterWarz.API.Data.Interfaces
{
    public interface IMatchDataService
    {
        Task<IEnumerable<MatchData>> GetAllMatchesAsync();
        Task<MatchData> GetMatchById(int id);
        Task RegisterMatchData(TransferObject obj);
        dynamic GetSpecificHamsterMatchData(int id);
    }
}
