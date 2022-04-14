using HamsterWarz.API.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterWarz.API.Data.Interfaces
{
    public interface IMatchDataService
    {
        Task RegisterMatchData(TransferObject obj);
    }
}
