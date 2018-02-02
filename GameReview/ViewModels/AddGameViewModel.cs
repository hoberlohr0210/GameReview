using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameReview.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GameReview.ViewModels
{
    public class AddGameViewModel
    {
        [Required]
        [Display(Name = "Game Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "You must give your game a description.")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Type")]
        public int TypeID { get; set; }

        public List<SelectListItem> Types { get; set; }
        public AddGameViewModel() { }

        public AddGameViewModel(IEnumerable<GameType> types)
        {
            Types = new List<SelectListItem>();
            foreach (var type in types)
            {
                Types.Add(new SelectListItem
                {
                    Value = (type.ID).ToString(),
                    Text = type.Name
                });
            }
        }
    }
}
