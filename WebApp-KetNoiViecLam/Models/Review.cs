using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp_KetNoiViecLam.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        [DisplayName("Điểm đánh giá")]
        public int Rating { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Bình luận")]
        public string Comment { get; set; }

        [Required]
        [ForeignKey("User")]
        [Display(Name = "Người đánh giá")]
        public int UserId { get; set; }
        public User? User { get; set; }

    }
}
