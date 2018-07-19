using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAndCategories.Models
{
    public class ViewModel
    {
        public Products Product { get; set; }
        public Categories Category { get; set; }
        public Groupings Groupings { get; set; }
        public List<Products> ProductList { get; set; }
        public List<Categories> CategoryList { get; set; }
    }
}