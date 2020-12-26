using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoAuthen.Controllers
{
    [Authorize]
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ABC()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult XYZ()
        {
            return View();
        }
    }
}