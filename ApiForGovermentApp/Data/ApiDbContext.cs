using ApiForGovermentApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiForGovermentApp.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Photo>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Photo>()
                .HasOne(p => p.DetectedUser)
                .WithMany()
                .HasForeignKey(p => p.DetectedUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
