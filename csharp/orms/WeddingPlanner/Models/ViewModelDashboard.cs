using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class ViewModelDashboard
    {
        public Users users { get; set; }
        public Wed weddings { get; set; }
        public HasGuests guests { get; set; }
    }
}