
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnWeb_KetNoiViecLam.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int id_user { get; set; }
        public string? Displayname { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

    }
}
