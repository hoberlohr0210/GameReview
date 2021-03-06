﻿// <auto-generated />
using GameReview.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GameReview.Migrations
{
    [DbContext(typeof(GameDbContext))]
    [Migration("20180202210541_AddTypes")]
    partial class AddTypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GameReview.Models.Game", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.Property<int>("TypeID");

                    b.HasKey("ID");

                    b.HasIndex("TypeID");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GameReview.Models.GameGenre", b =>
                {
                    b.Property<int>("GameID");

                    b.Property<int>("GenreID");

                    b.HasKey("GameID", "GenreID");

                    b.HasIndex("GenreID");

                    b.ToTable("GameGenres");
                });

            modelBuilder.Entity("GameReview.Models.GameType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("GameReview.Models.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("GameReview.Models.Game", b =>
                {
                    b.HasOne("GameReview.Models.GameType", "Type")
                        .WithMany("Games")
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GameReview.Models.GameGenre", b =>
                {
                    b.HasOne("GameReview.Models.Game", "Game")
                        .WithMany("GameGenres")
                        .HasForeignKey("GameID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GameReview.Models.Genre", "Genre")
                        .WithMany("GameGenres")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
