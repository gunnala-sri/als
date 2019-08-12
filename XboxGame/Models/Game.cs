using System;
using System.ComponentModel;

namespace XboxGame.Models
{
    /// <summary>
    /// A class to represent Game Model
    /// </summary>
    public class Game : INotifyPropertyChanged
    {
        /// <summary>
        /// Event to handle propery change
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the value of identifier
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// Gets or sets the value of title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the value of description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the value of average rating of game
        /// </summary>
        public double AvgRating { get; set; }

        /// <summary>
        /// Gets or sets the value of created user
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the value of created time
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the value of last modified user name
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the value of last modified date
        /// </summary>
        public DateTime ModifiedDate { get; set; }

    }
}
