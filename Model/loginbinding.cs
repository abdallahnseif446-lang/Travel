using System.ComponentModel.DataAnnotations;

namespace Travel.Model
{
    public class loginbinding
    {
        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password: ")]
        [MinLength(8)]
        [Required]
        public string? Password { get; set; }
       
    }
}
