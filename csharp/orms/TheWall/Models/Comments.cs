using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheWall.Models
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        public string Content { get; set; }
        public Users Commenter { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [ForeignKey("PostId")]
        public int PostId { get; set; }

        public Comments()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

    }
}