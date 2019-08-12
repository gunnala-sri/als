using System.ComponentModel.DataAnnotations.Schema;

namespace XboxAPI.DbModels
{
    /// <summary>
    /// Represent game model
    /// </summary>
    public class Game : BaseModel
    {
        /// <summary>
        /// Gets or sets the value of title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the value of description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the value of average rating
        /// </summary>
        [NotMapped]
        public double AvgRating { get; set; }
    }
}

