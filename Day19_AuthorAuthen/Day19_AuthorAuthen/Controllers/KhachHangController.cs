using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Day19_AuthorAuthen.Controllers
{
    [Authorize]
    public class KhachHangController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult DangNhap()
        {
            return View();
        }
    }
}