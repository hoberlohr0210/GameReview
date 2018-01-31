using System.Collections.Generic;
using System.Linq;
using GameReview.Models;
using GameReview.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using GameReview.Data;


namespace GameReview.Controllers
{
    public class GameGenreController : Controller
    {
        private readonly GameDbContext context;

        public GameGenreController(GameDbContext dbContext)
        {
            this.context = dbContext;
        }

        public IActionResult Index()
        {
            List<Genre> genres = context.Genres.ToList();
            return View();
        }

        public IActionResult Add()
        {
            AddGameGenreViewModel addGameGenreViewModel = new AddGameGenreViewModel();
            return View(addGameGenreViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddGameGenreViewModel addGameGenreViewModel)
        {
            if (ModelState.IsValid)
            {
                Genre newGenre = new Genre
                {
                    Type = addGameGenreViewModel.Name
                };

                context.Genres.Add(newGenre);
                context.SaveChanges();

                return Redirect("/GameGenre");
            }

            return View(addGameGenreViewModel);
        }

        public IActionResult ViewGameGenre(int id)
        {
            List<GameGenre> items = context
                .GameGenres
                .Include(item => item.Game)
                .Where(gg => gg.GenreID == id)
                .ToList();

            Genre genre = context.Genres.FirstOrDefault(gg => gg.ID == id);

            ViewGameGenreViewModel viewModel = new ViewGameGenreViewModel
            {
                Genre = genre,
                Game = game
            };

            return View(viewModel);
        }

        public IActionResult AddGame(int id)
        {
            //retrieve the menu wit the given ID via context
            //list of all cheeses in the system
            Genre genre = context.Genres.Single(g => g.ID == id);
            List<Game> games = context.Games.ToList();
            return View(new AddGameGenreItemViewModel(genre, games));
        }

        [HttpPost]
        public IActionResult AddGame(AddGameGenreItemViewModel addGameGenreItemViewModel)
        {
            if (ModelState.IsValid)
            {
                var gameID = addGameGenreItemViewModel.GameID;
                var genreID = addGameGenreItemViewModel.GenreID;

                IList<GameGenre> existingItems = context.GameGenres
                    .Where(gg => gg.GameID == gameID)
                    .Where(gg => gg.GenreID == genreID).ToList();

                if (existingItems.Count == 0)
                {
                    GameGenre genreItem = new GameGenre
                    {
                        //these are the values in the View Model
                        Game = context.Games.Single(g => g.ID == gameID),
                        Genre = context.Genres.Single(g => g.ID == genreID)
                    };

                    context.GameGenre.Add(genreItem);
                    context.SaveChanges();
                }

                return Redirect(string.Format("/Menu/ViewMenu/" + addGameGenreItemViewModel.GenreID));

            }
            return View(addGameGenreItemViewModel);
        }

    }
}
