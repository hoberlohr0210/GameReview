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
    public class TypeController : Controller
    {
        private readonly GameDbContext context;

        public TypeController(GameDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var gameType = context.Types.ToList();
            return View(gameType);
        }

        public IActionResult Add()
        {
            AddTypeViewModel addGenreViewModel = new AddTypeViewModel();
            return View(addGenreViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddTypeViewModel addGenreViewModel)
        {
            if(ModelState.IsValid)
            {
                GameType newType = new GameType
                {
                    Type = addGenreViewModel.Type
                };

                context.Types.Add(newType);
                context.SaveChanges();

                return Redirect("/Type");
            }

            return View(addGenreViewModel);
        }
    }
}
