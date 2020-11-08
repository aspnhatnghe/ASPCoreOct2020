using System.ComponentModel.DataAnnotations;

namespace Day08_Async_UploadFile.Models
{
    
    public class HangHoa
    {
        [Display(Name = "Mã số")]
        public int MaHh { get; set; }

        [Display(Name = "Tên hàng hóa")]
        [Required(ErrorMessage ="Vui lòng nhập tên hàng hóa")]
        public string TenHh { get; set; }

        [Display(Name = "Hình")]
        public string Hinh { get; set; }

        [Display(Name = "Đơn giá")]
        [Range(0, double.MaxValue)]
        [Required(ErrorMessage = "Nhập đi")]
        public double DonGia { get; set; }               

        [Display(Name = "Số lượng")]
        [Range(0, 100, ErrorMessage ="Số lượng từ 0 .. 100")]
        public int SoLuong { get; set; }
        [Display(Name = "Thành tiền")]
        public double ThanhTien => DonGia * SoLuong;
    }
}
