using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Day02_HTML_CSS.Models;
using Microsoft.AspNetCore.Http;

namespace Day02_HTML_CSS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public IActionResult XuLyDangKy(string HoTen, string MatKhau,int GioiTinh, string ThongTinThem, List<string> SoThich, string QueQuan)
        //{
            
        //    return Content($"{HoTen} - {QueQuan}");
        //}
        public IActionResult XuLyDangKy(NguoiDung nguoiDung, IFormFile Hinh)
        {
            //gọi service xử lý nghiệp vụ
            return Json(nguoiDung);
            //return Content($"{nguoiDung.HoTen} - {nguoiDung.QueQuan}");
        }
    }
}
