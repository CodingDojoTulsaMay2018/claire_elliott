using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner
{
    public class LoginCheck
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}