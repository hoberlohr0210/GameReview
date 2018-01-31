using System.Collections.Generic;
using GameReview.Models;

namespace GameReview.ViewModels
{
    public class ViewGenreViewModel
    {
        public IList<GameGenre> Items { get; set; }
        public Genre Genre { get; set; }
    }
}
