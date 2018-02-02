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
        [Display(Name = "Game Type")]
        public string Name { get; set; }
    }
}
