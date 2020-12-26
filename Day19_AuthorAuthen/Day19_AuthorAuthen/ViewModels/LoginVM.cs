
using System.ComponentModel.DataAnnotations;

namespace Day19_AuthorAuthen.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Tên đăng nhập")]
        [Required]
        public string Username { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}
