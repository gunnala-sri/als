using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public void RateGame(Game game)
        {
            dynamic settings = new ExpandoObject();
            settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            settings.ResizeMode = ResizeMode.NoResize;
            settings.MinWidth = 450;
            settings.Title = "My New Window";

            IWindowManager manager = new WindowManager();
            manager.ShowDialog(new RateGameViewModel(this._gameService,this._eventAggregator, game), null, settings);
        }

    }
}
