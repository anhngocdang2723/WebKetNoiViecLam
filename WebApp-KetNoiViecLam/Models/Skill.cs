using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp_KetNoiViecLam.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Skill")] 
        public string SkillName { get; set; }

        [Display(Name = "Kích hoạt")]
        public bool IsActive { get; set; }
    }
}
