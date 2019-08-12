namespace XboxAPI.DbModels
{
    /// <summary>
    /// Represents game reviews
    /// </summary>
    public class GameReview : BaseModel
    {
        /// <summary>
        /// Gets or sets the value of game identifier
        /// </summary>
        public int GameId { get; set; }

        /// <summary>
        /// Gets or sets the value of review comments
        /// </summary>
        public string ReviewComments { get; set; }

        /// <summary>
        /// Gets or sets the value of game rating identifier
        /// </summary>
        public int GameRatingId { get; set; }

    }
}
