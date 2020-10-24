using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using D03_CSS.Models;

namespace D03_CSS.Controllers
{
    public class HomeController : Controller
    {

        // host:port/Home/SanPham
        public IActionResult SanPham()
        {
            var dsHangHoa = new List<HangHoa>();

            //random danh sách
            var rd = new Random();
            var soSP = rd.Next(10, 100);
            var listHinh = new string[]
            {
                "iphone-12-144944.jpg",
                "iphone-x-256gb-gray.jpg",
                "samsung-galaxy-a8-star-2018.jpg",
                "Samsung-Galaxy-S20-Pink-7.jpg"
            };

            for(var i = 0; i < soSP; i++)
            {
                dsHangHoa.Add(new HangHoa {
                    Hinh = listHinh[rd.Next(0, listHinh.Length)],
                    MaHh = Guid.NewGuid(),
                    Tenhh = $"IPhone {rd.Next()}",
                    DonGia = rd.NextDouble() * 10000000,
                    HangMoi = rd.Next() % 2 == 1
                });
            }

            return View(dsHangHoa);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
    }
}
