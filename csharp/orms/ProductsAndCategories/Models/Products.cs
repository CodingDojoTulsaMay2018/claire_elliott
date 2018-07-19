using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAndCategories.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MinLength(5), MaxLength(45)]
        public string Name { get; set; }

        [Required]
        [MinLength(5), MaxLength(155)]
        public string Description { get; set; }

        [Required]
        [Range(0.99,999.99, ErrorMessage = "Price must be between $0.99 and $99.99")]
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Groupings> GroupingList { get; set; }

        public Products()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            GroupingList = new List<Groupings>();

        }
    }
}