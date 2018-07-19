using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAndCategories.Models
{
    [Table("ProductsToCategories")]
    public class Groupings
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Products Product { get; set; }
        public int CategoryId { get; set; }
        public Categories Category { get; set; }
    }
}