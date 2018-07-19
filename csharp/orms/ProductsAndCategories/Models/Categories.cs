using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAndCategories.Models
{
    public class Categories
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MinLength(5), MaxLength(45)]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Groupings> GroupingList { get; set; }

        public Categories()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            GroupingList = new List<Groupings>();

        }
    }
}