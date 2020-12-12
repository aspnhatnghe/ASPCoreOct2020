using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day15_EFCore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day15_EFCore.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly MyDbContext _context;

        public HangHoaController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var hangHoas = _context.HangHoas.Include(hh => hh.Loai);

            return View(hangHoas);
        }
    }
}