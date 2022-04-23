using HamsterWarz.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterWarz.Entities.Helper
{
    public class MatchResultDTO
    {
        public int MatchId { get; set; }
        public Hamster? WinningHamster { get; set; }
        public Hamster? LosingHamster { get; set; }
    }
}
