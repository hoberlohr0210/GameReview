using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameReview.Models
{
    public class GameType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<Game> Games { get; set; }
    }
}
