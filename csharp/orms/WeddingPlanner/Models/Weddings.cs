using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace WeddingPlanner.Models
{
    public class Weddings
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Id")]
        public int UserId { get; set; }

        [Required]
        [MinLength(2),MaxLength(255)]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use letters only")]
        public string Wedder1 { get; set; }

        [Required]
        [MinLength(2),MaxLength(255)]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Use letters only")]
        public string Wedder2 { get; set; }

        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        [MinLength(8)]
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        List<Users> Guests { get; set; }

        public Weddings()
        {
            CreatedAt = DateTime.Now;
            Guests = new List<Users>();
        }
    }
}