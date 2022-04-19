using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterWarz.Entities.Models
{
    public class Hamster
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public int Likes { get; set; } 
        public int Age { get; set; }
        public string? Loves { get; set; }
        public string? FavoriteFood { get; set; }
        public int TotalGames { get; set; }
        public int Wins { get; set; } 
        public int Defeats { get; set; } 

        //public List<MatchData>? MatchesData { get; set; }
        
    }
}
