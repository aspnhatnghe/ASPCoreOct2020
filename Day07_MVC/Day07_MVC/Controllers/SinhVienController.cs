using Day07_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace Day07_MVC.Controllers
{
    public class SinhVienController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private string fileText = "datasv.txt";
        private string fileJson = "datasv.json";

        [HttpPost]
        public IActionResult Manage(SinhVien sv, string GhiFile)
        {
            if (GhiFile == "Ghi file JSON")
            {
                var jsonSv = JsonConvert.SerializeObject(sv);
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "JsonData", fileJson);

                System.IO.File.WriteAllText(fullPath, jsonSv);
                var desktopUrl = @"C:\Users\NN\Desktop\aaa.json";
                System.IO.File.WriteAllText(desktopUrl, jsonSv);
            }
            else
            {
                //ghi file text
                var data = new string[]
                {
                    sv.MaSV.ToString(),
                    sv.HoTen,
                    sv.Diem.ToString()
                };
                var fullPathText = Path.Combine(Directory.GetCurrentDirectory(), "Data", fileText);

                System.IO.File.WriteAllLines(fullPathText, data);
            }
            return View("Index");
        }

        public IActionResult DocJson()
        {
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "JsonData", fileJson);
            var content = System.IO.File.ReadAllText(fullPath);

            var sv = JsonConvert.DeserializeObject<SinhVien>(content);

            return View("Index", sv);
        }
    }
}