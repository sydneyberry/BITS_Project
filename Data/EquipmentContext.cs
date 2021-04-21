using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BITS_Project.Models;

namespace BITS_Project.Data
{
    public class EquipmentContext : DbContext
    {
        public EquipmentContext (DbContextOptions<EquipmentContext> options)
            : base(options)
        {
        }

        public DbSet<Equipment> Equipments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>().ToTable("Equipment");
        }
    }
}
