using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace D06_MVCBasic.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/")]
        [Route("ABC")]
        public int A()
        {
            return new Random().Next();
        }

        [Route("xo-so/so-may-man")]
        [Route("[controller]/xo-so")]
        public int AX()
        {
            return new Random().Next(100, 1000);
        }

        [Route("{loai}/{tensp}")]
        public string XuLy(string loai, string tensp)
        {
            return $"{loai}: {tensp}";
        }

    }
}