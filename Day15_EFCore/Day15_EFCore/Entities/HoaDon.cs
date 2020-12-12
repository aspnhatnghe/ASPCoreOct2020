using System;
using System.Collections;
using System.Collections.Generic;

namespace Day15_EFCore.Entities
{
    public class HoaDon
    {
        public Guid MaHd { get; set; }
        public string MaKH { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayLap { get; set; }

        public IEnumerable<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }

    public class ChiTietHoaDon
    {
        public HangHoa HangHoa { get; set; }
        public HoaDon HoaDon { get; set; }
        public Guid MaHd { get; set; }
        public int MaHh { get; set; }
        public int SoLuong { get; set; }
    }
}
