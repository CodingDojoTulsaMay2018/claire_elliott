using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace UserDashboard.Models
{
    [Table("users")]
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

        public string Description { get; set; }

        public int Level { get; set; }
        
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [Required]
        [NotMapped]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
        [NotMapped]
        public List<Message> MessagesList { get; set; }
        public List<Comment> CommentsList { get; set; }

        public User()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            CommentsList = new List<Comment>();
            MessagesList = new List<Message>();
            Level = 1;
            Description = "No description added yet.";
        }
    }
}