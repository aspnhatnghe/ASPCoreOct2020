using System.ComponentModel.DataAnnotations;

namespace Day07_MVC.Models
{
    public class SinhVien
    {
        [Display(Name ="Mã SV")]
        public int MaSV { get; set; }
        [Display(Name ="Họ tên")]
        public string HoTen { get; set; }
        [Display(Name ="Điểm")]
        public double Diem { get; set; }
        [Display(Name = "Xếp loại")]
        public string XepLoai
        {
            get
            {
                if (Diem < 5) return "Yếu";
                if (Diem < 7) return "Trung bình";
                if (Diem < 8.5) return "Khá";
                return "Giỏi";
            }
        }
    }
}
