using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day16_EFCore_DBFirst.Entities;
using Day16_EFCore_DBFirst.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Day16_EFCore_DBFirst.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly eStore20Context _context;

        public HangHoaController(eStore20Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.HangHoa
                .Select(hh => new HangHoaVM
                {
                    MaHh = hh.MaHh,
                    TenHh = hh.TenHh,
                    DonGia = hh.DonGia,
                    Hinh = hh.Hinh,
                    GiamGia = hh.GiamGia,
                    MaLoai = hh.MaLoai,
                    TenLoai = hh.MaLoaiNavigation.TenLoai,
                    MaNcc = hh.MaNcc,
                    NhaCungCap = hh.MaNccNavigation.TenCongTy,
                    MoTaDonVi = hh.MoTaDonVi
                });
            return View(data.ToList());
        }


        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var hangHoa = _context.HangHoa
                .SingleOrDefault(hh => hh.MaHh == id);
            if (hangHoa != null)
            {
                ViewBag.MaLoai = new SelectList(_context.Loai, "MaLoai", "TenLoai", hangHoa.MaLoai);
                return View(hangHoa);
            }
            TempData["ThongBao"] = $"Tìm không thấy hàng hóa có mã {id}";
            return RedirectToAction("Index");
        }
        #endregion
    }
}