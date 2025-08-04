using Form_CountryStateCity_Cascade_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Form_CountryStateCity_Cascade_MVC.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ApplicationForm> Applications { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationForm>()
                .HasOne(a => a.Country)
                .WithMany()
                .HasForeignKey(a => a.CountryId)
                .OnDelete(DeleteBehavior.Restrict); // or .NoAction

            modelBuilder.Entity<ApplicationForm>()
                .HasOne(a => a.State)
                .WithMany()
                .HasForeignKey(a => a.StateId)
                .OnDelete(DeleteBehavior.Cascade); // keep only one cascade

            base.OnModelCreating(modelBuilder);
        }

    }

}
