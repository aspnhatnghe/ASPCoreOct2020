using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Buoi01_Intro.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public int Lucky()
        {
            var boSinhSoNgauNhien = new Random();
            return boSinhSoNgauNhien.Next();
        }

        // host/Demo/Hello
        // host/Demo/Hello?name=Nhất Nghệ
        public string Hello(string name)
        {
            return $"Xin chào bạn {name}.";
        }

        public IActionResult KetQua()
        {
            var abc = new
            {
                Sinh = 1990,
                DienThoai = 901091019,
                Ten = "Nhất Nghệ"
            };

            return Json(abc);
        }

        public IActionResult Chuoi()
        {
            var chuoiNgauNhien = new Random().Next();
            return Content(chuoiNgauNhien.ToString());
        }


        // host/Demo/XoSo
        public IActionResult XoSo()
        {
            return View();
        }

        // host/Demo/Lottery
        public IActionResult Lottery()
        {
            return View("XoSo");
            //return View("~/Views/Demo/XoSo.cshtml");
        }
    }
}