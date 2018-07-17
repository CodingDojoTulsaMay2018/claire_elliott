using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DojoSecrets.Models
{
    [Table("Likes")]
    public class Like
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int SecretId { get; set; }
        public Secret Secret { get; set; }
    }
}