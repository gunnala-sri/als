using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XboxAPI.DbModels
{
    public class XboxDbContext : DbContext
    {
        public XboxDbContext(DbContextOptions<XboxDbContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<GameRating> GameRatings { get; set; }

        public DbSet<GameReview> GameReviews { get; set; }
    }
}
