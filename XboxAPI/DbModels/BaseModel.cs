using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XboxAPI.DbModels
{
    /// <summary>
    /// Base model class to represent a database enitity
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// Gets or sets the value of identifier
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the value of created user
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the value of created time
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets of sets the value of modified user name
        /// </summary>
        public string ModifiedBy { get; set; }
        
        /// <summary>
        /// Gets or sets the value of modified date
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}
