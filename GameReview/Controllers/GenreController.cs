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
    public class GenreController : Controller
    {
        private readonly GameDbContext context;

        public GenreController(GameDbContext dbContext)
        {
            this.context = dbContext;
        }

        public IActionResult Index()
        {
            List<Genre> genres = context.Genres.ToList();
            return View(genres);
        }

        public IActionResult Add()
        {
            AddGenreViewModel addGenreViewModel = new AddGenreViewModel();
            return View(addGenreViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddGenreViewModel addGenreViewModel)
        {
            if (ModelState.IsValid)
            {
                Genre newGenre = new Genre
                {
                    Name = addGenreViewModel.Name
                };

                context.Genres.Add(newGenre);
                context.SaveChanges();

                return Redirect("/Genre");
            }

            return View(addGenreViewModel);
        }

        public IActionResult ViewGenre(int id)
        {
            List<GameGenre> items = context
                .GameGenres
                .Include(item => item.Game)
                .Where(g => g.GenreID == id)
                .ToList();

            Genre genre = context.Genres.FirstOrDefault(g => g.ID == id);

            ViewGenreViewModel viewModel = new ViewGenreViewModel
            {
                Genre = genre,
                Items = items
            };

            return View(viewModel);
        }

        public IActionResult AddItem(int id)
        {
            //retrieve the menu wit the given ID via context
            //list of all cheeses in the system
            Genre genre = context.Genres.Single(g => g.ID == id);
            List<Game> games = context.Games.ToList();
            return View(new AddGenreItemViewModel(genre, games));
        }

        [HttpPost]
        public IActionResult AddItem(AddGenreItemViewModel addGenreItemViewModel)
        {
            if (ModelState.IsValid)
            {
                var gameID = addGenreItemViewModel.GameID;
                var genreID = addGenreItemViewModel.GenreID;

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

                    context.GameGenres.Add(genreItem);
                    context.SaveChanges();
                }

                return Redirect(string.Format("/Genre/ViewGenre/" + addGenreItemViewModel.GenreID));

            }
            return View(addGenreItemViewModel);
        }

    }
}
