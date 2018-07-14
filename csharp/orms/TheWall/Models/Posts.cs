using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheWall.Models
{
    public class Posts
    {
        [Key]
        public int PostId { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Comments> Comments { get; set; }

        public Users Creator { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public Posts()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Comments = new List<Comments>();
        }

    }
}