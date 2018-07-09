using System.ComponentModel.DataAnnotations;
namespace Assignments.Models
{
    public class Surveyor
    {
        [Required]
        [StringLength(15,MinimumLength=2)]
        public string UsersName {get; set;}

        [Required]
        [StringLength(15,MinimumLength=2)]
        public string FavLanguage {get; set;}
            
        [Required]
        public string DojoLocation {get; set;}

        [StringLength(15,MinimumLength=2)]
        public string Comments {get; set;}
    }
}