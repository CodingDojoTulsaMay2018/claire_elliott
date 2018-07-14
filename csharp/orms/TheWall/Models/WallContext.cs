using Microsoft.EntityFrameworkCore;
 
namespace TheWall.Models
{
    public class WallContext : DbContext
    {
        public WallContext(DbContextOptions<WallContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}