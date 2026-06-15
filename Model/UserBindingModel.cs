using System.ComponentModel.DataAnnotations;

namespace Travel.Model
{
    public class UserBindingModel
    {
        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password: ")]
        [MinLength(8)]
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? PassportNumber { get; set; }
        [Required]
        public string? FullName { get; set; }
    }
}
