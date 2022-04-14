using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterWarz.Entities.Models
{
    public class MatchData
    {
        [Key]
        public int Id { get; set; }
        public int WinnerId { get; set; }
        public int LoserId { get; set; }
    }
}
