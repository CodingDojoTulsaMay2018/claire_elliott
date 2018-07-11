using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Restauranter.Models
{

    public class CustomDateAttribute : RangeAttribute
    {
        public CustomDateAttribute() : base(typeof(DateTime), 
            DateTime.Now.AddYears(-6).ToShortDateString(),
            DateTime.Now.ToShortDateString()) 
            {}
    }   
    public class Review
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3),MaxLength(45)]
        public string ReviewerName { get; set; }
        [Required]
        [MinLength(3),MaxLength(75)]
        public string RestaurantName { get; set; }
        [Required]
        [MinLength(10),MaxLength(255)]
        public string Message { get; set; }
        [Required]
        [CustomDateAttribute]
        public DateTime VisitDate { get; set; }
        [Required]
        public int Stars { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Helpful { get; set; }
        public int Unhelpful { get; set; }
    }
}