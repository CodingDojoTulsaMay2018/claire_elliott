using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace UserDashboard.Models
{
    [Table("messages")]
    public class Message
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MinLength(5),MaxLength(255)]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        List<Comment> HasComments { get; set; }
        
        [ForeignKey("Id")]
        public int UserId { get; set; }
        public User Creator { get; set; }

        public Message()
        {
            CreatedAt = DateTime.Now;
        }
    }
}