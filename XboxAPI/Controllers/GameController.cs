using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XboxAPI.DbModels;

namespace XboxAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private XboxDbContext _context;

        public GameController(XboxDbContext dbContext)
        {
            _context = dbContext;
        }

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

        [HttpGet("Rating")]
        public ActionResult<IEnumerable<GameRating>> GetGameRatingDef(int gameId)
        {
            return _context.GameRatings.ToList();
        }

        [HttpGet("Review")]
        public ActionResult<IEnumerable<GameReview>> GetGameReviews(int gameId)
        {
            var game = _context.Games.First(g => g.Id == gameId);
            if (game == null)
                return null;

            return _context.GameReviews.Where(g => g.GameId == gameId).ToList();
        }

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

        [HttpPost("Review")]
        public GameReview PostGameReview(GameReview review)
        {
            var game = _context.Games.First(g => g.Id == review.GameId);
            if (game == null)
                return null;

            _context.GameReviews.Add(review);
            _context.SaveChanges();

            return review;
        }

        private double GetGameAvgRating(Game game)
        {
            var gm = _context.Games.First(g => g.Id == game.Id);
            if (gm == null)
                return 0;

            var reviews = _context.GameReviews.Where(g => g.GameId == game.Id).ToList();
            if (!reviews.Any())
                return 0;

            return reviews.Average(avg => _context.GameRatings.First(r => r.Id == avg.GameRatingId).Rating);
        }
    }
}