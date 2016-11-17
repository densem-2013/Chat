using System.ComponentModel.DataAnnotations;

namespace Chat.Web.Models
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password:")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Invalid password confirm.")]
        public string ConfirmPassword { get; set; }
    }
}