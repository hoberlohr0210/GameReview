using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameReview.Models;
using GameReview.Data;
using GameReview.ViewModels;

namespace GameReview.Controllers
{
    public class GameController : Controller
    {
        private GameDbContext context;

        public GameController(GameDbContext dbContext)
        {
            this.context = dbContext;
        }            


        public IActionResult Index()
        {

        IList<Game> games = context.Games.Include(g => g.Genre).ToList();

            return View(games);
        }

        public IActionResult Add()
        {
            //passes collection of all description objects to the constructor
            //generates a select list hopefully
            AddGameViewModel addGameViewModel = new AddGameViewModel(context.Genres.ToList());
            return View(addGameViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddGameViewModel addGameViewModel)
        {
            if (ModelState.IsValid)
            {
                //GameGenre newGameGenre = context.Genres.Single(g => g.ID == addGameViewModel.GenreID);
                //add the new game to my existing games
                Game newGame = new Game
                {
                    Title = addGameViewModel.Title,
                    Description = addGameViewModel.Description,
                    Genre = newGameGenre
                };
                context.Games.Add(newGame);
                context.SaveChanges();

                return Redirect("/Game");
            }

            return View(addGameViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Games";
            ViewBag.games = context.Games.ToList();
            return View();

        }
        [HttpPost]
        public IActionResult Remove(int[] gameIds)
        {
            foreach (int gameId in gameIds)
            {
                Game theGame = context.Games.Single(g => g.ID == gameId);
                context.Games.Remove(theGame);
            }

            context.SaveChanges();
            return Redirect("/");
        }

        public IActionResult Genre(int id)
        {
            if (id ==0)
            {
                return Redirect("/Genre");
            }

            //will retrieve a specific genre that has its games list populated
            //that matches a given ID passed in by the administrative user
            GameGenre theGenre = context.Genres
                .Include(gen => gen.Games)
                .Single(gen => gen.ID == id);

            ViewBag.title = "Games in genre: " + theGenre.Genre;
            //passes the list into the VIew
            //wouldn't have been populated if not included above
            //Games is a property we have already defined
            return View("Index", theGenre.Game);
        }
    
    }
}