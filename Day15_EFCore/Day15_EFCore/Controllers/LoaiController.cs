using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day15_EFCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Day15_EFCore.Controllers
{
    public class LoaiController : Controller
    {
        private readonly MyDbContext _context;

        public LoaiController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Loais.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Loai loai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loai);
                _context.SaveChanges();
                return Redirect("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            if(loai != null)
            {
                return View(loai);
            }
            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult Edit(Loai loai)
        {
            if (ModelState.IsValid)
            {
                _context.Update(loai);
                _context.SaveChanges();
                return Redirect("Index");
            }
            return View();
        }
    }
}