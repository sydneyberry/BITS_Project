using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BITS_Project.Models
{
    public enum SpaceType
    {
        SMALL_FIELD, MEDIUM_FIELD, LARGE_FIELD, TRACK, BATTING, OTHER
    }

    public class Space
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public SpaceType type { get; set; }
    }
}
