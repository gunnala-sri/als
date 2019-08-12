using Microsoft.EntityFrameworkCore;

namespace XboxAPI.DbModels
{
    /// <summary>
    /// Application database context
    /// </summary>
    public class XboxDbContext : DbContext
    {
        /// <summary>
        /// Instantiates the new object of type XboxDbContext
        /// </summary>
        /// <param name="options">context options object</param>
        public XboxDbContext(DbContextOptions<XboxDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the value of game data set
        /// </summary>
        public DbSet<Game> Games { get; set; }

        /// <summary>
        /// Gets or sets the value of game rating data set
        /// </summary>
        public DbSet<GameRating> GameRatings { get; set; }

        /// <summary>
        /// Gets or sets the value of game reviews data set
        /// </summary>
        public DbSet<GameReview> GameReviews { get; set; }
    }
}
