using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BITS_Project.Models;

namespace BITS_Project.Data
{
    public class RentalContext : DbContext
    {
        public RentalContext (DbContextOptions<RentalContext> options)
            : base(options)
        {
        }

        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Equipment> Equipments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rental>().ToTable("Rental");
            modelBuilder.Entity<Equipment>().ToTable("Equipment");
        }
    }
}
