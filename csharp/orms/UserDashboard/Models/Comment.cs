using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace UserDashboard.Models
{
    [Table("comments")]
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MinLength(5),MaxLength(255)]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        
        [ForeignKey("Id")]
        public int UserId { get; set; }
        public User Creator { get; set; }

        [ForeignKey("Id")]
        public int MessageId { get; set; }
        public Message Message { get; set; }

        public Comment()
        {
            CreatedAt = DateTime.Now;
        }
    }
}