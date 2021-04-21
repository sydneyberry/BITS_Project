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
        SOCCER, FOOTBALL, RUGBY, CRICKET, DODGEBALL, OTHER
    }

    public class Tournament
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public Reservation ReservationID { get; set; }

        [Required]
        public Employee EmpID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateMade { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime DateFor { get; set; }

        [Required]
        public Activity ActivityType { get; set; }

        public string Description { get; set; }

    }
}
