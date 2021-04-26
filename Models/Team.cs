using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BITS_Project.Models
{
    public class Team
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Tournament")]
        public int TournamentID { get; set; }

        [Required]
        [Display(Name = "Captain First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Captain Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Team Name")]
        public string TeamName { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
