using Caliburn.Micro;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Windows;
using XboxGame.Interface;
using XboxGame.Models;

namespace XboxGame
{
    /// <summary>
    /// View Model class to show list of games
    /// </summary>
    public class GameListViewModel : Screen
    {
        /// <summary>
        /// Event Aggregator object.
        /// </summary>
        private readonly IEventAggregator _eventAggregator;

        /// <summary>
        /// Game Service object
        /// </summary>
        private readonly IGameService _gameService;

        /// <summary>
        /// Gets or sets the value of game list to bind in UI
        /// </summary>
        public IList<Game> Games { get; set; }

        /// <summary>
        /// Gets or sets the value of sort recommendation button
        /// </summary>
        public string SortTypeConent { get; set; }

        /// <summary>
        /// Gets or sets the value of sort type
        /// </summary>
        private string SortType { get; set; }

        /// <summary>
        /// Instantiates the new instance of Game list view model
        /// </summary>
        /// <param name="gameService">game service object</param>
        /// <param name="eventAggregator">event aggregator object</param>
        public GameListViewModel(IGameService gameService, IEventAggregator eventAggregator)
        {
            // initialization
            this._gameService = gameService;
            this._eventAggregator = eventAggregator;
            this.SortType = "ASC";
            this.SortTypeConent = "Recommendation(high-low rating)";

            //Load games
            this.Games = this._gameService.GetAllGames().OrderBy(g=> g.AvgRating).ToList();
        }

        /// <summary>
        /// Loads the game details view
        /// </summary>
        /// <param name="game">game object</param>
        public void LoadDetails(Game game)
        {
            EventMessage target = new EventMessage();
            target.Message = "Details";
            target.Data = game;
            _eventAggregator.PublishOnUIThread(target);
        }

        /// <summary>
        /// Brings up rating dialog
        /// </summary>
        /// <param name="game"></param>
        public void RateGame(Game game)
        {
            // popup settings
            dynamic settings = new ExpandoObject();
            settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            settings.ResizeMode = ResizeMode.NoResize;
            settings.Title = "Rate This Game";

            // launch dialog
            IWindowManager manager = new WindowManager();
            manager.ShowDialog(new RateGameViewModel(this._gameService,this._eventAggregator, game), null, settings);
        }

        /// <summary>
        /// Sorts the recommendation based on average rating
        /// </summary>
         public void SortByRecommendation()
        {
            // If current view ascending, sort it descending by avg rating
            if(this.SortType == "ASC")
            {
                this.SortTypeConent = "Recommendation(low-high rating)";
                Games = this._gameService.GetAllGames().OrderByDescending(g => g.AvgRating).ToList();
                this.SortType = "DESC";
            }
            else // if current view is descending, sort it ascending by avg rating
            {
                this.SortTypeConent = "Recommendation(high-low rating)";
                Games = this._gameService.GetAllGames().OrderBy(g => g.AvgRating).ToList();
                this.SortType = "ASC";
            }
        }

    }
}
