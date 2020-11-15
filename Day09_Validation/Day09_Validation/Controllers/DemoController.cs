using Day09_Validation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Day09_Validation.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult NoLayout()
        {
            return View();
        }

        public IActionResult Test01()
        {
            return View();
        }

        public int SinhMaNgauNghien()
        {
            var random = new Random();
            var soNgauNhien = random.Next(1000, 10000);

            HttpContext.Session.SetInt32("MaBaoMat", soNgauNhien);
            return soNgauNhien;
        }
        public IActionResult DangKy()
        {
            var random = new Random();
            var soNgauNhien = random.Next(1000, 10000);

            //Lưu giá trị lên session
            HttpContext.Session.SetInt32("MaBaoMat", soNgauNhien);

            ViewBag.SoNgauNhien = soNgauNhien;

            return View();
        }

        public string KiemTraMaBaoMat(int MaBaoMat)
        {
            if (HttpContext.Session.GetInt32("MaBaoMat") == MaBaoMat)
                return "true";
            else
                return "false";
        }

        public IActionResult KiemTraMaNhanVien(string EmployeeId)
        {
            //giả sữ dữ liệu đã/đang có
            var userIds = new string[]
            {
                "admin", "nhatnghe", "hocvien"
            };

            //LINQ
            var danhSach = userIds.Select(p => p.ToLower()).ToList();

            if (danhSach.Contains(EmployeeId.ToLower()))
            {
                return Json(false);
            }
            return Json(true);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Employee employee)
        {
            if (ModelState.IsValid)
            {
            }
            else
            {
                ModelState.AddModelError("loi", "Còn lỗi");
            }
            return View();
        }
    }
}