using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp_KetNoiViecLam.Models
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Tên danh mục")] 
        public string CatName { get; set; }

        [Display(Name = "Lớp")]
        public int Level { get; set; }

        [Display(Name = "Danh mục cha")]
        public int ParentId { get; set; }

        [Display(Name = "Thứ tự trên Menu")]
        public int MenuOrder { get; set; }

        [Display(Name = "Kích hoạt")]
        public bool IsActive { get; set; }

    }
}
