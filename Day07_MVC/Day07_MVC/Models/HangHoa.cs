
using System.ComponentModel.DataAnnotations;

namespace Day07_MVC.Models
{
    public class HangHoa
    {
        [Display(Name ="Mã số")]
        public int MaHh { get; set; }

        [Display(Name = "Tên hàng hóa")]
        public string TenHh{ get; set; }
        [Display(Name = "Hình")]
        public string Hinh{ get; set; }

        [Display(Name = "Đơn giá")]
        public double DonGia{ get; set; }
        [Display(Name = "Số lượng")]
        public int SoLuong{ get; set; }
        [Display(Name = "Thành tiền")]
        public double ThanhTien => DonGia * SoLuong;
    }
}
