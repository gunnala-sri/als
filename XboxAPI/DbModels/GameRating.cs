using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XboxAPI.DbModels
{
    public class GameRating: BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Rating { get; set; }

    }
}
