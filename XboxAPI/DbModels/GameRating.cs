namespace XboxAPI.DbModels
{
    /// <summary>
    /// Represents game rating definition
    /// </summary>
    public class GameRating: BaseModel
    {
        /// <summary>
        /// Gets or sets the value of rating name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of rating description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the value of rating
        /// </summary>
        public int Rating { get; set; }

    }
}
