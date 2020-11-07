using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day07_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day07_MVC.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.DiaChi = "105 Bà Huyện Thanh Quan";
            ViewBag.HoTen = "Nhất Nghệ";
            ViewData["DienThoai"] = 3928102365;
            ViewData["Ngay Sinh"] = new DateTime(2000, 11, 21);

            var hangHoa = new HangHoa
            {
                MaHh = 1, 
                TenHh = "Iphone 12 256Gb Gold",
                DonGia = 29990000,
                SoLuong = 3
            };
            ViewBag.DienThoai = hangHoa;

            return View();
        }

        public IActionResult DanhSach()
        {
            var data = new List<HangHoa>();
            data.Add(new HangHoa
            {
                MaHh = 1, TenHh = "Iphone 12",
                DonGia = 2999000, SoLuong = 3,
                Hinh = "iphone12.png"
            });
            data.Add(new HangHoa
            {
                MaHh = 2, TenHh = "IPad 2020",
                DonGia = 1399000, SoLuong = 7,
                Hinh = "ipad-8-wifi-32gb-2020.png"
            });

            return View(data);
        }

        public IActionResult ChiTiet()
        {
            var hangHoa = new HangHoa
            {
                MaHh = 2,
                TenHh = "IPad 2020",
                DonGia = 1399000,
                SoLuong = 7,
                Hinh = "ipad-8-wifi-32gb-2020.png"
            };

            return View(hangHoa);
        }

        public IActionResult ThemHangHoa()
        {
            return View();
        }
    }
}