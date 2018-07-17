using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DojoSecrets.Models
{
    [Table("Secrets")]
    public class Secret
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [MinLength(5), MaxLength(255)]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public User Creator { get; set; }
        public List<User> LikedBy { get; set; }

        public Secret()
        {
            CreatedAt = DateTime.Now;
            LikedBy = new List<User>();
        }
    }
}