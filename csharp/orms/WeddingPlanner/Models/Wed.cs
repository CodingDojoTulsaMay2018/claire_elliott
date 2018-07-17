using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace WeddingPlanner.Models
{

    public class CustomDateAttribute : RangeAttribute
    {
        public CustomDateAttribute() : base(typeof(DateTime), 
            DateTime.Now.ToShortDateString(),
            DateTime.Now.AddYears(6).ToShortDateString()) 
            {}
    }  
    public class Wed
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Id")]
        public int UserId { get; set; }

        [Required]
        [MinLength(2),MaxLength(255)]
        public string Wedder1 { get; set; }

        [Required]
        [MinLength(2),MaxLength(255)]
        public string Wedder2 { get; set; }

        [Required]
        [CustomDateAttribute(ErrorMessage = "Date must be in the future.")]
        public DateTime Date { get; set; }
        
        [Required]
        [MinLength(8)]
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Users> Guests { get; set; }
        public Wed()
        {
            CreatedAt = DateTime.Now;
            Guests = new List<Users>();
        }
    }
}