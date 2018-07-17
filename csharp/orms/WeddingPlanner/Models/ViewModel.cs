using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class ViewModel
    {
        public Users regUser { get; set; }
        public LoginCheck loginUser { get; set; }

    }
}