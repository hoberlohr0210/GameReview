using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReview.Models
{
    public class GameGenre
    {
        public int GameID { get; set; }
        public Game Game { get; set; }

        public int GenreID { get; set; }
        public Genre Genre { get; set; }
    }
}
