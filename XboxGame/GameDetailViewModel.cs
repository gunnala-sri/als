using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XboxGame.Interface;
using XboxGame.Models;

namespace XboxGame
{
    public class GameDetailViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IGameService _gameService;

        public Game Game { get; set; }

        public List<GameReview> GameReviews { get; set; }

        public GameDetailViewModel(IGameService gameService, IEventAggregator eventAggregator, Game game)
        {
            this._gameService = gameService;
            this._eventAggregator = eventAggregator;

            this.GameReviews = this._gameService.GetGameReviews(game.Id);
        }

        public void LoadGameList()
        {
            EventMessage target = new EventMessage();
            target.Text = "List";
            _eventAggregator.PublishOnUIThread(target);

        }
    }
}
