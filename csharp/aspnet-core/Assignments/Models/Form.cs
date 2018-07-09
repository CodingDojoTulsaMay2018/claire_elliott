using System.ComponentModel.DataAnnotations;

namespace Assignments.Models
{
    public class Form
    {
        [Required]
        [MinLength(4)]
        public string FirstName {get; set;}

        [Required]
        [MinLength(4)]
        public string LastName {get; set;}
        
        [Required]
        [Range(1,100)]
        public int Age {get; set;}
        
        [Required]
        [EmailAddress]
        public string Email {get; set;}
        
        [Required]
        [DataType(DataType.Password)]
        public string Password {get; set;}
    }
}