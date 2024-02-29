using Microsoft.EntityFrameworkCore;
using TechnicalInterview_API.DataLayer.Models;

namespace TechnicalInterview_API.DataLayer.Context
{
    public class DataContext : DbContext
    {
        public DbSet<VoterActivity> VoterActivities { get; set; }
        public DbSet<Signature> Signatures { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VoterActivity>().HasKey(key => new { key.VoterId });
            modelBuilder.Entity<Signature>().HasKey(key => new { key.SignatureId });
            modelBuilder.Entity<District>().HasKey(key => new { key.DistrictId });
            modelBuilder.Entity<Status>().HasKey(key => new { key.StatusId });
            modelBuilder.Entity<User>().HasKey(key => new { key.UserId });
        }

    }
}
