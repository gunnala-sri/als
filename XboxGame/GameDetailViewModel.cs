using Caliburn.Micro;
using System.Collections.Generic;
using XboxGame.Interface;
using XboxGame.Models;

namespace XboxGame
{
    /// <summary>
    /// View Model class to manage and display game details view
    /// </summary>
    public class GameDetailViewModel : Screen
    {
        /// <summary>
        /// Event Aggregator object
        /// </summary>
        private readonly IEventAggregator _eventAggregator;

        /// <summary>
        /// Game Service object
        /// </summary>
        private readonly IGameService _gameService;

        /// <summary>
        /// Gets and sets the value of Game model to bind in view
        /// </summary>
        public Game Game { get; set; }

        /// <summary>
        /// Gets and sets the value of Game Reviews to bind in view
        /// </summary>
        public List<GameReview> GameReviews { get; set; }

        /// <summary>
        /// Instantiates new object of GameDetailViewModel
        /// </summary>
        /// <param name="gameService">Game Serviece object</param>
        /// <param name="eventAggregator">Event Aggregator object</param>
        /// <param name="game">Game object</param>
        public GameDetailViewModel(IGameService gameService, IEventAggregator eventAggregator, Game game)
        {
            // Initialzation
            this._gameService = gameService;
            this._eventAggregator = eventAggregator;
            this.Game = game;

            // Load Game Reviews
            this.GameReviews = this._gameService.GetGameReviews(game.Id);
        }

        /// <summary>
        /// Handles the loading of GameList view
        /// </summary>
        public void LoadGameList()
        {
            EventMessage target = new EventMessage();
            target.Message = "List";
            _eventAggregator.PublishOnUIThread(target);
        }

        /// <summary>
        /// Updates the description and loads the game list view
        /// </summary>
        public void UpdateDescription()
        {
            this._gameService.EditGame(Game);
            this.LoadGameList();
        }
    }
}
