using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day02_HTML_CSS.Models
{
    public class NguoiDung
    {
        public string HoTen { get; set; }
        public string MatKhau { get; set; }
        public int GioiTinh { get; set; }
        public string ThongTinThem { get; set; }
        public List<string> SoThich { get; set; }
        public string QueQuan { get; set; }
    }
}
