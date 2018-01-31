using System.Collections.Generic;
using GameReview.Models;

namespace GameReview.ViewModels
{
    public class ViewGameGenreViewModel
    {
        public IList<GameGenre> Game { get; set; }
        public Genre Genre { get; set; }
    }
}
