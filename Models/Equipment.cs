using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BITS_Project.Models
{
    public class Equipment
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Equipment")]
        public string EquipmentName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        public string? Description { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
