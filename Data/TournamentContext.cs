using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BITS_Project.Models;

namespace BITS_Project.Data
{
    public class TournamentContext : DbContext
    {
        public TournamentContext (DbContextOptions<TournamentContext> options)
            : base(options)
        {
        }

        public DbSet<Tournament> Tournaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tournament>().ToTable("Tournament");
        }
    }
}
