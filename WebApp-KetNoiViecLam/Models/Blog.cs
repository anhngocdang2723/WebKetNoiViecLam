using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_KetNoiViecLam.Models
{
    public class Blog
    {
        [Key] 
        public int BlogId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Tiêu đề bài viết")]
        public string BlogTitle { get; set; }

        [Required]
        [StringLength(3000)]
        [Display(Name = "Nội dung bài viết")]
        public string Content { get; set; }

        [Required]
        [ForeignKey("User")]
        [Display(Name = "Người đăng bài")]
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
