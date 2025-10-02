using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "لطفا نام کاربری را وارد کنید")] 
        public string Username { get; set; }
        [Required(ErrorMessage = "لطفا ایمیل را وارد کنید"), EmailAddress] 
        public string Email { get; set; }
        [Required(ErrorMessage ="لطفا رمز عبور را وارد کنید"), DataType(DataType.Password)] 
        public string Password { get; set; }
    }
}
