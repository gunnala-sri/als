using System.Collections.Generic;
using System.Configuration;
using XboxGame.Interface;
using XboxGame.Models;

namespace XboxGame.Service
{
    /// <summary>
    /// A class that implements IGameService interface
    /// </summary>
    public class GameService : IGameService
    {
        /// <summary>
        /// Holds XBox API Url value
        /// </summary>
        private readonly string _xboxAPIUrl;

        /// <summary>
        /// Instantiates new object of GameService class
        /// </summary>
        public GameService()
        {
            // Sets the XBoxAPI url from app settings
            this._xboxAPIUrl = ConfigurationManager.AppSettings["XBoxAPIUrl"];
        }

        /// <summary>
        /// Retrieves all games
        /// </summary>
        /// <returns>list of games</returns>
        public List<Game> GetAllGames()
        {
            return AsyncHelper.RunSync<List<Game>>(() => HTTPClientWrapper<List<Game>>.Get(this._xboxAPIUrl + "game"));
        }

        /// <summary>
        /// Retrieves reviews of a game
        /// </summary>
        /// <param name="gameId">game identifier</param>
        /// <returns>List of game reviews</returns>
        public List<GameReview> GetGameReviews(int gameId)
        {
            return AsyncHelper.RunSync<List<GameReview>>(() => HTTPClientWrapper<List<GameReview>>.Get(this._xboxAPIUrl + @"game/Review?gameId=" + gameId));
        }

        /// <summary>
        /// Edits Game description
        /// </summary>
        /// <param name="game">game with updated description</param>
        public void EditGame(Game game)
        {
            AsyncHelper.RunSync(() => HTTPClientWrapper<Game>.PutRequest(this._xboxAPIUrl + @"game/edit",game));
        }

        /// <summary>
        /// Retrieves Game Rating definitions
        /// </summary>
        /// <returns>List of game ratings </returns>
        public List<GameRating> GetGameRatingDef()
        {
            return AsyncHelper.RunSync<List<GameRating>>(() => HTTPClientWrapper<List<GameRating>>.Get(this._xboxAPIUrl + "game/Rating"));
        }

        /// <summary>
        /// Posts a review to game
        /// </summary>
        /// <param name="review">review object to be posted</param>
        public void PostReview(GameReview review)
        {
            AsyncHelper.RunSync(() => HTTPClientWrapper<GameReview>.PostRequest(this._xboxAPIUrl + @"game/Review", review));
        }
    }
}
