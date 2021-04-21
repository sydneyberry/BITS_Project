using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BITS_Project.Models;

namespace BITS_Project.Data
{
    public class ReservationContext : DbContext
    {
        public ReservationContext (DbContextOptions<ReservationContext> options)
            : base(options)
        {
        }

        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Space> Spaces { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().ToTable("Reservation");
            modelBuilder.Entity<Space>().ToTable("Space");
            
        }
    }
}
