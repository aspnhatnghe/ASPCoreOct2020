﻿using Day16_EFCore_DBFirst.Entities;
using Day16_EFCore_DBFirst.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Day16_EFCore_DBFirst.Controllers
{
    public class AjaxController : Controller
    {
        private readonly eStore20Context _context;
        public AjaxController(eStore20Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string Keyword)
        {
            var data = _context.HangHoa.AsQueryable();
            if (!string.IsNullOrEmpty(Keyword))
            {
                data = data.Where(hh => hh.TenHh.Contains(Keyword));
            }

            var dsHangHoa = data.Select(hh => new HangHoaAjaxVM
            {
                TenHh = hh.TenHh,
                MaHh = hh.MaHh,
                DonGia = hh.DonGia.Value,
                Hinh = hh.Hinh
            });

            return PartialView("PartialHangHoa", dsHangHoa);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string ServerTime()
        {
            return DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        [HttpGet]
        public IActionResult JsonSearch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult JsonSearch(string Keyword, double? From, double? To)
        {
            var data = _context.HangHoa.AsQueryable();
            if (!string.IsNullOrEmpty(Keyword))
            {
                data = data.Where(hh => hh.TenHh.Contains(Keyword));
            }
            if (From.HasValue)
            {
                data = data.Where(hh => hh.DonGia >= From);
            }
            if (To.HasValue)
            {
                data = data.Where(hh => hh.DonGia <= To);
            }

            var dsHangHoa = data.Select(hh => new
            {
                hh.MaHh,
                hh.TenHh,
                hh.DonGia,
                hh.MaLoaiNavigation.TenLoai
            });

            return Json(dsHangHoa);
        }
    }
}