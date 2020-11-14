using Day09_Validation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Day09_Validation.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult DangKy()
        {
            return View();
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