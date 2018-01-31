using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameReview.Data;
using GameReview.Models;
using GameReview.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameReview.Controllers
{
    public class GenreController : Controller
    {
        private readonly GameDbContext context;

        public GenreController(GameDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var gameGenre = context.Genres.ToList();
            return View(gameGenre);
        }

        public IActionResult Add()
        {
            AddGenreViewModel addGenreViewModel = new AddGenreViewModel();
            return View(addGenreViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddGenreViewModel addGenreViewModel)
        {
            if(ModelState.IsValid)
            {
                GameGenre newGenre = new GameGenre
                {
                    Type = addGenreViewModel.Name
                };

                context.Genres.Add(newGenre);
                context.SaveChanges();

                return Redirect("/Genre");
            }

            return View(addGenreViewModel);
        }
    }
}
