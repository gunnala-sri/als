using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XboxAPI.DbModels
{
    public class GameReview : BaseModel
    {
        public int GameId { get; set; }

        public string ReviewComments { get; set; }

        public int GameRatingId { get; set; }

    }
}
