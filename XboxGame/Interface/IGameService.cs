using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XboxGame.Models;

namespace XboxGame.Interface
{
    public interface IGameService
    {
        List<Game> GetAllGames();

        List<GameReview> GetGameReviews(int gameId);
    }
}
