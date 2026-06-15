using System.ComponentModel.DataAnnotations;

namespace Travel.Model
{
    public class UserViewModel
    {
        public string? FullName { get; set; }

        [EmailAddress]
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
        public string? PassportNumber { get; set; }
    }
}
