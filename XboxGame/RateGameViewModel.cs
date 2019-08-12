using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using XboxGame.Interface;
using XboxGame.Models;

namespace XboxGame
{
    public class RateGameViewModel : Screen 
    {
        private IGameService _gameService;
        public Game Game { get; set; }

        public List<GameRating> GameRatings { get; set; }

        public GameRating SelectedGameRating { get; set; }

        public string ReviewComments { get; set; }

        public RateGameViewModel(IGameService gameService, Game game)
        {
            this._gameService = gameService;
            this.Game = game;

            this.GameRatings = this._gameService.GetGameRatingDef();
            this.SelectedGameRating = this.GameRatings.Find(r => r.Id == 1);
        }

        public void RateGame()
        {
            GameReview review = new GameReview()
            {
                GameId = this.Game.Id,
                ReviewComments = this.ReviewComments,
                GameRatingId = this.SelectedGameRating.Id
            };

            this._gameService.PostReview(review);
            TryClose();
        }
    }
}
