using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using XboxAPI.DbModels;

namespace XboxAPI.Controllers
{
    /// <summary>
    /// Game API Controller class to expose REST API calls for game library 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        /// <summary>
        /// database context
        /// </summary>
        private XboxDbContext _context;

        /// <summary>
        /// Instantiates the new object of type GameContorller class
        /// </summary>
        /// <param name="dbContext">database context object</param>
        public GameController(XboxDbContext dbContext)
        {
            _context = dbContext;
        }

        /// <summary>
        /// Retrieves all Games
        /// </summary>
        /// <returns>List of games</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Game>> Get()
        {
            var games = _context.Games.ToList();
            games.ForEach(g =>
            {
                g.AvgRating = GetGameAvgRating(g);
            });

            return games;
        }

        /// <summary>
        /// Retireves game rating definitions
        /// </summary>
        /// <returns>List of game ratings</returns>
        [HttpGet("Rating")]
        public ActionResult<IEnumerable<GameRating>> GetGameRatingDef()
        {
            return _context.GameRatings.ToList();
        }

        /// <summary>
        /// Retrieves reviews of a game
        /// </summary>
        /// <param name="gameId">game identifier</param>
        /// <returns>list of game reviews</returns>
        [HttpGet("Review")]
        public ActionResult<IEnumerable<GameReview>> GetGameReviews(int gameId)
        {
            var game = _context.Games.First(g => g.Id == gameId);
            if (game == null)
                return null;

            return _context.GameReviews.Where(g => g.GameId == gameId).ToList();
        }

        /// <summary>
        /// Updates game description
        /// </summary>
        /// <param name="game">game object to be updated</param>
        /// <returns>updated game</returns>
        [HttpPut("Edit")]
        public Game EditGame(Game game)
        {
            var g = _context.Games.First(gm => gm.Id == game.Id);
            if (g == null)
                return null;

            g.Description = game.Description;
            _context.Attach(g);
            _context.Entry(g).Property("Description").IsModified = true;
            _context.SaveChanges();

            return g;
        }

        /// <summary>
        /// Add review to a game
        /// </summary>
        /// <param name="review">game review details</param>
        /// <returns>newly added review</returns>
        [HttpPost("Review")]
        public GameReview PostGameReview(GameReview review)
        {
            // validate game identifier
            var game = _context.Games.First(g => g.Id == review.GameId);
            if (game == null)
                return null;

            _context.GameReviews.Add(review);
            _context.SaveChanges();

            return review;
        }

        /// <summary>
        /// Gets the average rating of a game
        /// </summary>
        /// <param name="game">game object</param>
        /// <returns>average rating</returns>
        private double GetGameAvgRating(Game game)
        {
            // validte game object
            var gm = _context.Games.First(g => g.Id == game.Id);
            if (gm == null)
                return 0;

            // get all review of the game
            var reviews = _context.GameReviews.Where(g => g.GameId == game.Id).ToList();
            if (!reviews.Any())
                return 0;

            // calculate average rating
            return reviews.Average(avg => _context.GameRatings.First(r => r.Id == avg.GameRatingId).Rating);
        }
    }
}