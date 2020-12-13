using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day16_EFCore_DBFirst.ViewModels
{
    public class HangHoaTimKiemVM
    {
        public int MaHh { get; set; }
        public string TenHh { get; set; }
        public string TenLoai { get; set; }
        public double? DonGia { get; set; }
        public string Hinh { get; set; }
        public double GiamGia { get; set; }
        public DateTime NgaySx { get; set; }
    }
}
