using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Day15_EFCore.Entities
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public int MaHh { get; set; }
        [Required]
        [MaxLength(100)]
        public string TenHh { get; set; }
        public string Hinh { get; set; }
        public double DonGia { get; set; }
        public int SoLuongTon { get; set; }

        public int MaLoai { get; set; }
        
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }

        public IEnumerable<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
