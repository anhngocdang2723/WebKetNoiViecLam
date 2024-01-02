using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_KetNoiViecLam.Models
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Tên người dùng")]
        public string FullName { get; set; } = string.Empty;

        [StringLength(30)]
        [DisplayName("Ảnh đại diện")]
        public string Avatar { get; set; } = string.Empty;

        [StringLength(1000)]
        [DisplayName("Giới thiệu bản thân")]
        public string Bio { get; set; } = string.Empty;

        public bool Status { get; set; }
    }
}
