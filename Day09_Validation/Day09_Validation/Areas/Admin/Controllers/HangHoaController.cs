using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Day09_Validation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HangHoaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}