using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XboxAPI.DbModels
{
    public class Game : BaseModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        [NotMapped]
        public double AvgRating { get; set; }
    }
}

