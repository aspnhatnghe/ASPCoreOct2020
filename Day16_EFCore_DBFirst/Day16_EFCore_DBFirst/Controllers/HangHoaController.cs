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
                ViewBag.MaNcc = new SelectList(_context.NhaCungCap, "MaNcc", "TenCongTy", hangHoa.MaNcc);
                return View(hangHoa);
            }
            TempData["ThongBao"] = $"Tìm không thấy hàng hóa có mã {id}";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                //xử lý upload hình (nếu có)

                _context.Update(hangHoa);
                await _context.SaveChangesAsync();
                TempData["ThongBao"] = $"Cập nhật hàng hóa {hangHoa.TenHh} thành công.";
                return RedirectToAction("Index");
            }
            return View();
        }
        #endregion

        public IActionResult Delete(int id)
        {
            var hangHoa = _context.HangHoa
                .SingleOrDefault(hh => hh.MaHh == id);
            var message = string.Empty;
            if (hangHoa != null)
            {
                try
                {
                    _context.Remove(hangHoa);
                    _context.SaveChanges();
                    message = $"Xóa hàng hóa {hangHoa.TenHh} thành công";
                }
                catch
                {
                    message = $"Xóa hàng hóa {hangHoa.TenHh} không thành công.";
                }
            }
            else
            {
                message = $"Không tìm thấy hàng hóa có mã {id}";
            }
            TempData["ThongBao"] = message;
            return RedirectToAction("Index");
        }


        #region Tim kiếm
        [HttpGet]
        public IActionResult TimKiem()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TimKiem(string TuKhoa, double GiaTu, double GiaDen)
        {
            return View();
        }
        #endregion
    }
}