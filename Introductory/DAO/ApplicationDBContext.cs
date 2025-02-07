using Introductory.Models;
using Microsoft.EntityFrameworkCore;

namespace Introductory.DAO
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Complain> Complain { get; set; }
        public DbSet<ComplainType> ComplainType { get; set; }
        public DbSet<ComplainStatus> ComplainStatus { get; set; }
        public DbSet<ComplainStatusTrackInfo> ComplainStatusTrackInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Prevent cascade delete for CreatedBy in ComplainStatusTrackInfo
            modelBuilder.Entity<ComplainStatusTrackInfo>()
                .HasOne(c => c.Users)
                .WithMany()
                .HasForeignKey(c => c.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            // Prevent cascade delete for CreatedBy in ComplainStatus
            modelBuilder.Entity<ComplainStatus>()
                .HasOne(c => c.Users)
                .WithMany()
                .HasForeignKey(c => c.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}
