using System.ComponentModel.DataAnnotations;

namespace Chat.Web.Models
{
    public class LoginModel
    {
        [Display(Name = "Email:")]
        public string Email { get; set; }
        [Display(Name = "Password:")]
        public string PassWord { get; set; }
    }
}