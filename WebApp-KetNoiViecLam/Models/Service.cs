using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_KetNoiViecLam.Models
{
    public enum ServiceStatus
    {
        ChuaDuyet,
        DaDuyet,
        DangThucHien,
        HoanThanh,
        KhongPheDuyet
    }
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        [Required]
        [ForeignKey("Category")]
        [DisplayName("Danh mục dịch vụ")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Tiêu đề dịch vụ")]
        public string ServiceTitle { get; set; }

        [Required]
        [StringLength(3000)]
        [Display(Name = "Mô tả dịch vụ")]
        public string ServiceDes { get; set; }

        [Required]
        [ForeignKey("Skill")]
        [DisplayName("Mô tả kỹ năng")]
        public int SkillId { get; set; }
        public Skill? Skill { get; set; }

        [Required]
        [DisplayName("Ngày đăng tải")]
        public DateTime DateCreated { get; set; } = DateTime.Now.Date;

        [Required]
        [DisplayName("Giá dịch vụ")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Trạng thái")]
        public ServiceStatus Status { get; set; } = ServiceStatus.ChuaDuyet; // giá trị mặc định

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
