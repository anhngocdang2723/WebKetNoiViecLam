using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp_KetNoiViecLam.Models
{
    public enum UserType
    {
        Freelancer,
        Client,
        Admin
    }

    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Tên đăng nhập")]
        public string? UserName { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Mật khẩu")]
        public string? Password { get; set; }

        [Required]
        [StringLength(40)]
        [DisplayName("Mail")]
        public string? Email { get; set; }

        [Required]
        [EnumDataType(typeof(UserType))]
        public UserType UserType { get; set; }
    }
}
