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
            return _context.Games.ToList();
        }

        [HttpGet("Review")]
        public ActionResult<IEnumerable<GameReview>> GetGameReviews(int gameId)
        {
            var game = _context.Games.First(g => g.Id == gameId);
            if (game == null)
                return null;

            return _context.GameReviews.Where(g => g.GameId == gameId).ToList();
        }

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
    }
}