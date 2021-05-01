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
        Small_Field_1, Small_Field_2, Medium_Field_1, Medium_Field_2, Large_Field, Track, Batting_Cage, Other
    }

    public class Space
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public SpaceType type { get; set; }
    }
}
