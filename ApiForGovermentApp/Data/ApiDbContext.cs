using ApiForGovermentApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiForGovermentApp.Data
{
    public class ApiDbContext :DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
}
}
