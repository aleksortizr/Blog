using System.ComponentModel.DataAnnotations;

namespace Blog_MVC.Models
{
    public class LoginModel
    {
        public class LogInModel
        {
            [Required(ErrorMessage = "Username is mandatory")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "Please submit a password")]
            public string Password { get; set; }
        }
    }
}
