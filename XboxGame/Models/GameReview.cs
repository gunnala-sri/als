using System;
using System.ComponentModel;

namespace XboxGame.Models
{
    /// <summary>
    /// A class to represent game review model
    /// </summary>
    public class GameReview : INotifyPropertyChanged
    {
        /// <summary>
        /// event handle to handle property changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the value of identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the value of game identifier
        /// </summary>
        public int GameId { get; set; }

        /// <summary>
        /// Gets or sets the value of review comment
        /// </summary>
        public string ReviewComments { get; set; }

        /// <summary>
        /// Gets or sets the value of game rating identifier
        /// </summary>
        public int GameRatingId { get; set; }

        /// <summary>
        /// Gets or sets the value of created by user name
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the value of created date
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the value of modified by user name
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the value of modified date.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

    }
}
