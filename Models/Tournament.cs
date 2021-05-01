using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BITS_Project.Models
{
    public enum Activity
    {
        Soccer, Football, Rugby, Cricket, Dodgeball, Other
    }

    public class Tournament
    {
        [Key]
        public int ID { get; set; }

        public Reservation ReservationID { get; set; }

        public int EmpID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateMade { get; set; } = DateTime.UtcNow;

        [Required]
        [Display(Name = "Date For")]
        public DateTime DateFor { get; set; }

        [Required]
        [Display(Name = "Activity")]
        public Activity ActivityType { get; set; } = Activity.Other;

        [Required]
        public int MaxTeams { get; set; }

        [Required]
        public int MaxTeamSize { get; set; }

        [Required]
        public int MinTeamSize { get; set; }

        [Required]
        [Display(Name = "Location")]
        public int SpaceID { get; set; }

        public string Description { get; set; }

    }
}
