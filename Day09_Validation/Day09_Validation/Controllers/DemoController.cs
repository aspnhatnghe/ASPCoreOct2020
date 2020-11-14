using Day09_Validation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day09_Validation.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Employee employee)
        {
            if(ModelState.IsValid)
            {
            }
            else
            {
                ModelState.AddModelError("loi", "Còn lỗi");
            }
            return View();
        }
    }
}