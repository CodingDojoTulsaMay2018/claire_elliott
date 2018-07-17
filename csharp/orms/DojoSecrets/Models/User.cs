using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace DojoSecrets.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
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
        public DateTime CreatedAt { get; set; }

        [Required]
        [NotMapped]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
        [NotMapped]
        public List<Secret> Secrets { get; set; }

        public User()
        {
            CreatedAt = DateTime.Now;
            Secrets = new List<Secret>();
        }
    }
}