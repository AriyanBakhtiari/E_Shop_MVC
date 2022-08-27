using System.ComponentModel.DataAnnotations;

namespace E_Shop.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = " {0} را وارد نمایید")]
        [MaxLength(255)]
        [EmailAddress]
        [Display(Name ="ایمیل کاربری")]
        public string Email { get; set; }
        [Required(ErrorMessage = " {0} را وارد نمایید")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name ="رمز کاربری")]
        public string Password { get; set; }

        [Required(ErrorMessage = " {0} را وارد نمایید")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name ="تکرار رمز")]
        public string RePassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = " {0} را وارد نمایید")]
        [MaxLength(255)]
        [EmailAddress]
        [Display(Name = "ایمیل کاربری")]
        public string Email { get; set; }
        [Required(ErrorMessage = " {0} را وارد نمایید")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز کاربری")]
        public string Password { get; set; }
        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
