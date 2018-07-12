using Microsoft.EntityFrameworkCore;
 
namespace LoginRegistration.Models
{
    public class LoginRegistrationContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public LoginRegistrationContext(DbContextOptions<LoginRegistrationContext> options) : base(options) { }
        public DbSet<Users> users { get; set; }
    }
    
}