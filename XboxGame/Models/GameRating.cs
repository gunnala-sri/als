using System;

namespace XboxGame.Models
{
    /// <summary>
    /// A class to represent rating definition of a game
    /// </summary>
    public class GameRating
    {
        /// <summary>
        /// Gets or sets the value of identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the value of name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the value of rating
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets the value of created user
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the value of created date
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the value of modified user name
        /// </summary>
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the value of modified date
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
