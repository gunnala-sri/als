using Caliburn.Micro;
using System.Collections.Generic;
using XboxGame.Interface;
using XboxGame.Models;

namespace XboxGame
{
    /// <summary>
    /// View Model class to handle game reviews
    /// </summary>
    public class RateGameViewModel : Screen 
    {
        /// <summary>
        /// Event Aggregator object
        /// </summary>
        private readonly IEventAggregator _eventAggregator;

        /// <summary>
        /// Game service object
        /// </summary>
        private readonly IGameService _gameService;

        /// <summary>
        /// Gets or sets the value of Game object
        /// </summary>
        public Game Game { get; set; }

        /// <summary>
        /// Gets or sets the value of game ratings
        /// </summary>
        public List<GameRating> GameRatings { get; set; }

        /// <summary>
        /// Gets or sets the value of selected game ratings
        /// </summary>
        public GameRating SelectedGameRating { get; set; }

        /// <summary>
        /// Gets or sets the value of revview comments
        /// </summary>
        public string ReviewComments { get; set; }

        /// <summary>
        /// Instantiates the new object of RateGameViewModel
        /// </summary>
        /// <param name="gameService">game service object</param>
        /// <param name="eventAggregator">event aggregator object</param>
        /// <param name="game"></param>
        public RateGameViewModel(IGameService gameService, IEventAggregator eventAggregator, Game game)
        {
            // Initialization
            this._eventAggregator = eventAggregator;
            this._gameService = gameService;
            this.Game = game;

            // Load game rating definitions.
            this.GameRatings = this._gameService.GetGameRatingDef();
            this.SelectedGameRating = this.GameRatings.Find(r => r.Id == 1);
        }

        /// <summary>
        /// Submits the review comments for game
        /// </summary>
        public void RateGame()
        {
            GameReview review = new GameReview()
            {
                GameId = this.Game.Id,
                ReviewComments = this.ReviewComments,
                GameRatingId = this.SelectedGameRating.Id
            };

            this._gameService.PostReview(review);

            // close the pop up and load game list view
            TryClose();
            LoadGameList();
        }

        /// <summary>
        /// Load game list view
        /// </summary>
        public void LoadGameList()
        {
            EventMessage target = new EventMessage();
            target.Message = "List";
            _eventAggregator.PublishOnUIThread(target);
        }
    }
}
