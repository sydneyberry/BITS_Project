using BITS_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BITS_Project.Data
{
    public class BitsContext : DbContext
    {
        public BitsContext(DbContextOptions<BitsContext> options) : base(options)
        {
        }

        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Space> Spaces { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rental>().ToTable("Rental");
            modelBuilder.Entity<Equipment>().ToTable("Equipment");
            modelBuilder.Entity<Reservation>().ToTable("Reservation");
            modelBuilder.Entity<Space>().ToTable("Space");
            modelBuilder.Entity<Tournament>().ToTable("Tournament");
            modelBuilder.Entity<Team>().ToTable("Team");
        }

    }
}
