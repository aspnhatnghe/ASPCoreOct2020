using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace D06_MVCBasic.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calculate(double SoHang1, double SoHang2, string PhepToan)
        {
            double ketQua = 0;
            switch(PhepToan)
            {
                case "+": ketQua = SoHang1 + SoHang2; break;
                case "-": ketQua = SoHang1 - SoHang2; break;
                case "*": ketQua = SoHang1 * SoHang2; break;
                case "/": ketQua = SoHang1 / SoHang2; break;
                case "%": ketQua = SoHang1 % SoHang2; break;
                case "^": ketQua = Math.Pow(SoHang1, SoHang2); break;
            }

            ViewBag.A = SoHang1;
            ViewBag.B = SoHang2;
            ViewBag.PhepToan = PhepToan;
            ViewBag.KQ = ketQua;
            return View("Index");
            //return Content($"{SoHang1} {PhepToan} {SoHang2} = {ketQua}");
        }
    }
}