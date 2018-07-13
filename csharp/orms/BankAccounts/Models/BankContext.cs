using Microsoft.EntityFrameworkCore;
 
namespace BankAccounts.Models
{
    public class BankContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public BankContext(DbContextOptions<BankContext> options) : base(options) { }
        public DbSet<User> user { get; set; }
        public DbSet<Transaction> transaction { get; set; }
    }
}