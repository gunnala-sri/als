using System.Collections.Generic;
using XboxGame.Models;

namespace XboxGame.Interface
{
    /// <summary>
    /// Interface to provide data through game service
    /// </summary>
    public interface IGameService
    {
        /// <summary>
        /// Retrieves all games
        /// </summary>
        /// <returns>list of games</returns>
        List<Game> GetAllGames();

        /// <summary>
        /// Retrieves reviews of a game
        /// </summary>
        /// <param name="gameId">game identifier</param>
        /// <returns>List of game reviews</returns>
        List<GameReview> GetGameReviews(int gameId);

        /// <summary>
        /// Retrieves Game Rating definitions
        /// </summary>
        /// <returns>List of game ratings </returns>
        List<GameRating> GetGameRatingDef();

        /// <summary>
        /// Edits Game description
        /// </summary>
        /// <param name="game">game with updated description</param>
        void EditGame(Game game);

        /// <summary>
        /// Posts a review to game
        /// </summary>
        /// <param name="review">review object to be posted</param>
        void PostReview(GameReview review);
    }
}
