﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XboxAPI.DbModels
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new XboxDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<XboxDbContext>>()))
            {
                // Look for any board games.
                if (context.Games.Any())
                {
                    return;   // Data was already seeded
                }

                Seed_GameRating(context);
                Seed_Game(context);
                Seed_GameReview(context);

                context.SaveChanges();
            }
        }

        private static void Seed_GameRating(XboxDbContext context)
        {
            context.GameRatings.AddRange(
            new GameRating
            {
                Name = "1Star",
                Rating = 1,
                Description = "No good",
                CreatedBy = "Sri",
                CreatedDate = DateTime.Now
            },
            new GameRating
            {
                Name = "2Star",
                Rating = 2,
                Description = "Not bad",
                CreatedBy = "Sri",
                CreatedDate = DateTime.Now
            },
             new GameRating
             {
                 Name = "3Star",
                 Rating = 3,
                 Description = "average",
                 CreatedBy = "Sri",
                 CreatedDate = DateTime.Now
             },
              new GameRating
              {
                  Name = "4Star",
                  Rating = 4,
                  Description = "Good",
                  CreatedBy = "Sri",
                  CreatedDate = DateTime.Now
              },
               new GameRating
               {
                   Name = "5Star",
                   Rating = 5,
                   Description = "Excellent",
                   CreatedBy = "Sri",
                   CreatedDate = DateTime.Now
               });
        }

        private static void Seed_Game(XboxDbContext context)
        {

            context.Games.AddRange(
                   new Game
                   {
                       Title = "Moon on the Mars",
                       Description = "Fight mooners on Mars",
                       CreatedBy = "Romeo",
                       CreatedDate = DateTime.Now
                   },
                   new Game
                   {
                       Title = "The Evil Kingdom",
                       Description = "Figh the Badies",
                       CreatedBy = "Fuelo",
                       CreatedDate = DateTime.Now
                   });
        }

        private static void Seed_GameReview(XboxDbContext context)
        {

            context.AddRange(
                new GameReview
                {
                    GameId = 1,
                    GameRatingId = 1,
                    ReviewComments = "Time waste, bad graphics",
                    CreatedBy = "Romeo",
                    CreatedDate = DateTime.Now
                },
                new GameReview
                {
                    GameId = 1,
                    GameRatingId = 5,
                    ReviewComments = "Excellent",
                    CreatedBy = "Romeo",
                    CreatedDate = DateTime.Now
                });

        }

    }
}