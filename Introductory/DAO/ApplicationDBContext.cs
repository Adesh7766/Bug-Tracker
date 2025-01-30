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

    }
}
