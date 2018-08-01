using Microsoft.EntityFrameworkCore;
 
namespace UserDashboard.Models
{
    public class Context : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}