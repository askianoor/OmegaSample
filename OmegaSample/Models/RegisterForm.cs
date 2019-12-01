using OmegaSample.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace OmegaSample.Models
{
    public class RegisterForm
    {
        [Required]
        [Display(Name = "username", Description = "Username")]
        public string UserName { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(100)]
        [Display(Name = "password", Description = "Password")]
        [Secret]
        public string Password { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        [Display(Name = "firstName", Description = "First name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        [Display(Name = "lastName", Description = "Last name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "phonenumber", Description = "Phone number")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "email", Description = "Email address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }

        /*
        [Required]
        [Display(Name = "modifiedDateTime", Description = "Timestamp of most recent modification to user")]
        public DateTime ModifiedDateTime { get; set; }
        */
    }
}
