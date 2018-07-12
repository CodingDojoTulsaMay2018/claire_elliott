using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginRegistration.Models
{
    public class Users
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2),MaxLength(45)]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use letters only")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2),MaxLength(45)]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use letters only")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        [NotMapped]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}