using System.ComponentModel.DataAnnotations;

namespace PBL3.Models
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = "Please enter your username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        // Mai thêm Email hoặc Số điện thoại... thì thêm vào đây
        //[Required(ErrorMessage = "Please enter your email")]
        //public string Email { get; set; }
    }
}
