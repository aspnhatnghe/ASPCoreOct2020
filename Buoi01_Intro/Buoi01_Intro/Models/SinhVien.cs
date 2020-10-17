using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi01_Intro.Models
{
    public class SinhVien
    {
        public int MaSinhVien { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public int LayTuoi => DateTime.Now.Year - NgaySinh.Year;
        public int Tuoi
        {
            get
            {
                return DateTime.Now.Year - NgaySinh.Year;
            }
        }
    }
}
