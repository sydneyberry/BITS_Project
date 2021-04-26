using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BITS_Project.Models
{
    public class Reservation
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "BITS Area")]
        public int SpaceID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateMade { get; set; } = DateTime.UtcNow;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
