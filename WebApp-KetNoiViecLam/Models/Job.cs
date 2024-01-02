using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_KetNoiViecLam.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        [Required]
        [ForeignKey("Category")]
        [DisplayName("Danh mục công việc")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Tiêu đề công việc")]
        public string JobTitle { get; set; }

        [Required]
        [StringLength(3000)]
        [DisplayName("Mô tả công việc")]
        public string JobDes { get; set; }

        [Required]
        [ForeignKey("Skill")]
        [DisplayName("Kỹ năng cần thiết")]
        public int SkillId { get; set; }
        public Skill? Skill { get; set; }

        [Required]
        [DisplayName("Ngày đăng tải")]
        public DateTime DateCreated { get; set; } = DateTime.Now.Date;

        [Required]
        [DisplayName("Ngân sách")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Budget { get; set; }

        [Required]
        [DisplayName("Hạn chót")]
        public DateTime Deadline { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
