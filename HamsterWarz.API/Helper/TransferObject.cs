using HamsterWarz.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterWarz.API.Helper
{
    public class TransferObject
    {
        public int Id { get; set; }
        public IEnumerable<Hamster> Hamsters { get; set; }
    }
}
