using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameReview.ViewModels
{
    public class AddTypeViewModel
    {
        [Required]
        [Display(Name = "Genre Name")]
        public string Type { get; set; }
    }
}
