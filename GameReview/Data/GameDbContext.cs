using System;
using GameReview.Models;
using Microsoft.EntityFrameworkCore;

namespace GameReview.Data
{
    public class GameDbContext : DbContext
    {
        //part of Entity Framework
        //it's a property
        public DbSet<Game> Games { get; set; }
        public DbSet<GameType> Types { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }

        public GameDbContext(DbContextOptions<GameDbContext> options)
            : base(options)
        { }

        //method that sets the primary key of GameGenre to be a composite key
        //consisting of both GameID and GenreID (two IDs)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameGenre>()
                .HasKey(g => new { g.GameID, g.GenreID });
        }
    }
}
