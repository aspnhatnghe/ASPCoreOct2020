using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Day08_Async_UploadFile.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day08_Async_UploadFile.Controllers
{
    public class DemoController : Controller
    {
        public string DemoSync()
        {
            var demo = new Demo();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            demo.Test01();
            demo.Test02();
            demo.Test03();
            stopWatch.Stop();

            return $"Chạy hết {stopWatch.ElapsedMilliseconds}ms";
        }

        public async Task<string> DemoABC()
        {
            var demo = new Demo();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var a = demo.Test01Async();
            var b = demo.Test02Async();
            var c = demo.Test03Async();
            await a; await b; await c;
            stopWatch.Stop();

            return $"Chạy hết {stopWatch.ElapsedMilliseconds}ms";
        }

        public IActionResult Upload()
        {
            return View();
        }
        public IActionResult SingleFile(IFormFile MyFile)
        {
            if (MyFile != null)
            {
                var fileName = $"{DateTime.Now.Ticks}{MyFile.FileName}";
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "HinhAnh", MyFile.FileName);
                using (var file = new FileStream(fullPath, FileMode.Create))
                {
                    MyFile.CopyTo(file);
                    ViewBag.ThongBao = "Upload thành công";
                }
            }
            else
            {
                ViewBag.ThongBao = "Upload thất bại";
            }
            return View("Upload");
        }

        public IActionResult MultipleFile(List<IFormFile> MyFile)
        {
            if (MyFile != null)
            {
                foreach(var my_file in MyFile)
                {
                    var fileName = $"{DateTime.Now.Ticks}{my_file.FileName}";
                    var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "HinhAnh", fileName);
                    using (var file = new FileStream(fullPath, FileMode.Create))
                    {
                        my_file.CopyTo(file);
                    }
                }
            }
            return View("Upload");
        }
    }
}