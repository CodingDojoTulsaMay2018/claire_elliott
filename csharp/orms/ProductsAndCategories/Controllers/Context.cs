using Microsoft.EntityFrameworkCore;
 
namespace ProductsAndCategories.Models
{
    public class Context : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Groupings> Groupings { get; set; }
    }
}