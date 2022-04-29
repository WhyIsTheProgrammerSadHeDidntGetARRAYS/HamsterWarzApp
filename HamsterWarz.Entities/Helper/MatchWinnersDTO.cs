using HamsterWarz.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterWarz.Entities.Helper
{
    public class MatchWinnersDTO
    {
        public int Id { get; set; }
        public IEnumerable<Hamster>? Hamsters { get; set; }
    }
}
