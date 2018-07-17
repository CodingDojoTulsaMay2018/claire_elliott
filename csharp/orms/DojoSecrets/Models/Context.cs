using Microsoft.EntityFrameworkCore;
 
namespace DojoSecrets.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Secret> Secrets { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}