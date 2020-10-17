using System;
using System.Collections.Generic;
using Buoi01_Intro.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi01_Intro.Controllers
{
    public class SinhVienController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MotSinhVien()
        {
            var sinhVien = new SinhVien();
            sinhVien.MaSinhVien = 1001;
            sinhVien.HoTen = "Trần Hưng Đạo";
            sinhVien.NgaySinh = new DateTime(2000, 11, 30);

            //sinhVien.Tuoi = 22;
            return View(sinhVien);
        }

        public IActionResult DanhSach()
        {
            var danhSach = new List<SinhVien>();
            danhSach.Add(new SinhVien
            {
                MaSinhVien = 1001,
                HoTen = "Trần Anh Hùng",
                NgaySinh = new DateTime(200,11,11)
            });
            var sv = new SinhVien()
            {
                MaSinhVien = 1002, HoTen = "Y Út",
                NgaySinh = new DateTime(1999,2,22)
            };
            danhSach.Add(sv);
            return View(danhSach);
        }
    }
}