
using System.ComponentModel.DataAnnotations;

namespace Day13_ADONET.Models
{
    public class Loai
    {
        [Key]
        public int MaLoai { get; set; }
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }
        [MaxLength(50)]
        public string Hinh { get; set; }
        [DataType(DataType.MultilineText)]
        public string MoTa { get; set; }
    }
}
