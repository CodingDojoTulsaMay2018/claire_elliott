using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class HasGuests
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Id")]
        public int UserId { get; set; }

        [ForeignKey("Id")]
        public int WeddingId { get; set; }
    }
}