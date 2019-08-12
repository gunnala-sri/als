using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XboxGame.Interface;
using XboxGame.Models;
using System.Configuration;

namespace XboxGame.Service
{
    public class GameService : IGameService
    {
        private string xboxAPIUrl;

        public GameService()
        {
            xboxAPIUrl = ConfigurationManager.AppSettings["XBoxAPIUrl"];
        }

        public List<Game> GetAllGames()
        {
            return AsyncHelper.RunSync<List<Game>>(() => HTTPClientWrapper<List<Game>>.Get(xboxAPIUrl + "game"));
        }

        public List<GameReview> GetGameReviews(int gameId)
        {
            return AsyncHelper.RunSync<List<GameReview>>(() => HTTPClientWrapper<List<GameReview>>.Get(xboxAPIUrl + @"game/Review?gameId=" + gameId));
        }

        public void EditGame(Game game)
        {
            AsyncHelper.RunSync(() => HTTPClientWrapper<Game>.PutRequest(xboxAPIUrl + @"game/edit",game));
        }

        public List<GameRating> GetGameRatingDef()
        {
            return AsyncHelper.RunSync<List<GameRating>>(() => HTTPClientWrapper<List<GameRating>>.Get(xboxAPIUrl + "game/Rating"));
        }

        public void PostReview(GameReview review)
        {
            AsyncHelper.RunSync(() => HTTPClientWrapper<GameReview>.PostRequest(xboxAPIUrl + @"game/Review", review));
        }
    }
}
