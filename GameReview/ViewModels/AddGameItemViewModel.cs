using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameReview.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameReview.ViewModels
{
    public class AddGameItemViewModel
    {
        public int GameID { get; set; }
        public int GenreID { get; set; }

        public Genre Genre { get; set; }
        public List<SelectListItem> Games { get; set; }

        public AddGameItemViewModel() { }

        public AddGameItemViewModel(Genre genre, IEnumerable<Game> games)
        {
            Games = new List<SelectListItem>();

            foreach (var game in games)
            {
                Games.Add(new SelectListItem
                {
                    Value = game.ID.ToString(),
                    Text = game.Title
                });
            }

            Genre = genre;
        }
    }
}
