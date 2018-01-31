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
        [Display(Name = "Category")]
        public int GenreID { get; set; }

        public List<SelectListItem> Genres { get; set; }
        public AddGameViewModel() { }

        public AddGameViewModel(IEnumerable<GameGenre> genres)
        {
            Genres = new List<SelectListItem>();
            foreach (var genre in genres)
            {
                Genres.Add(new SelectListItem
                {
                    Value = (genre.ID).ToString(),
                    Text = genre.Name
                });
            }
        }
    }
}
