using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameReview.ViewModels
{
    public class AddGenreViewModel
    {
        [Required]
        [Display(Name = "Genre Name")]
        public string Name { get; set; }
    }
}
