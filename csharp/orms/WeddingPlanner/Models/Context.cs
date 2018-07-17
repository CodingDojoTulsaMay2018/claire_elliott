using Microsoft.EntityFrameworkCore;
 
namespace WeddingPlanner.Models
{
    public class Context : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Wed> Weddings { get; set; }
        public DbSet<HasGuests> HasGuests { get; set; }
    }
}