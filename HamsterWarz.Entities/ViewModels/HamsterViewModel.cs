using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterWarz.Entities.ViewModels
{
    public class HamsterViewModel
    {
        [Required(ErrorMessage = "Name must be provided.")]
        public string Name { get; set; }
        
        [Range(1, 5,
            ErrorMessage = "Age must be between 1-5")]
        public int Age { get; set; }
        
        [Required(ErrorMessage = "Loves must be provided.")]
        public string Loves { get; set; }
        
        [Required(ErrorMessage = "Favorite food must be provided")]
        [Display(Name = "Favorite Food")]
        public string? FavoriteFood { get; set; }
        
        [Required(ErrorMessage = "Image must be provided.")]
        public string ImageUrl { get; set; }
    }
}
