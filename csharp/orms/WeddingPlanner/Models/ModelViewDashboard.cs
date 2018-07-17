using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class ModelViewDashboard
    {
        public Users users { get; set; }
        public Weddings weddings { get; set; }
        public HasGuests hasGuests { get; set; }
    }
}