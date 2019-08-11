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
    public class GameListViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IGameService _gameService;

        public IList<Game> Games { get; set; }

        public GameListViewModel(IGameService gameService, IEventAggregator eventAggregator)
        {
            this._gameService = gameService;
            this._eventAggregator = eventAggregator;

            Games = this._gameService.GetAllGames();
        }

        public void LoadDetails(Game game)
        {
            EventMessage target = new EventMessage();
            target.Text = "Details";
            target.Data = game;
            _eventAggregator.PublishOnUIThread(target);
        }
    }
}
