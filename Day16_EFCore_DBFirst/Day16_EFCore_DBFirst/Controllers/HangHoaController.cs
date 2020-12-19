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
            return View(new List<HangHoaTimKiemVM>());
        }

        const int SO_SAN_PHAM_1_TRANG = 5;

        [HttpPost]
        public IActionResult TimKiem(string TuKhoa, double? GiaTu, double? GiaDen, int page = 1)
        {
            var data = _context.HangHoa.AsQueryable();
            if (!string.IsNullOrEmpty(TuKhoa))
            {
                data = data.Where(hh => hh.TenHh.Contains(TuKhoa));
            }
            if (GiaTu.HasValue)
            {
                data = data.Where(hh => hh.DonGia >= GiaTu);
            }
            if (GiaDen.HasValue)
            {
                data = data.Where(hh => hh.DonGia <= GiaDen);
            }

            ViewBag.CurrentPage = page;
            ViewBag.TotalPage = Math.Ceiling(1.0 * data.Count() / SO_SAN_PHAM_1_TRANG);

            var dsHangHoa = data
                .Skip((page - 1) * SO_SAN_PHAM_1_TRANG)
                .Take(SO_SAN_PHAM_1_TRANG)
                .Select(hh => new HangHoaTimKiemVM
                {
                    MaHh = hh.MaHh,
                    TenHh = hh.TenHh,
                    DonGia = hh.DonGia,
                    GiamGia = hh.GiamGia,
                    Hinh = hh.Hinh,
                    NgaySx = hh.NgaySx,
                    TenLoai = hh.MaLoaiNavigation.TenLoai
                });
            return View(dsHangHoa.ToList());
        }
        #endregion

        public enum Sort
        {
            ASC, DESC
        }
        public IActionResult SapXepPhanTrang(int page = 1, Sort sort = Sort.ASC)
        {
            var dsHangHoa = _context.HangHoa.AsQueryable();
            if (sort == Sort.ASC)
            {
                dsHangHoa = dsHangHoa.OrderBy(p => p.TenHh);
            }
            else
            {
                dsHangHoa = dsHangHoa.OrderByDescending(p => p.TenHh);
            }

            var data = dsHangHoa.Skip((page - 1) * SO_SAN_PHAM_1_TRANG)
                .Take(SO_SAN_PHAM_1_TRANG)
                .Select(hh => new HangHoaTimKiemVM
                {
                    MaHh = hh.MaHh,
                    TenHh = hh.TenHh,
                    DonGia = hh.DonGia,
                    GiamGia = hh.GiamGia,
                    Hinh = hh.Hinh,
                    NgaySx = hh.NgaySx,
                    TenLoai = hh.MaLoaiNavigation.TenLoai
                });

            return View(data.ToList());
        }

        #region ThongKe
        public IActionResult ThongKe()
        {
            //Thống kê doanh thu theo loại
            var data = _context.ChiTietHd
                .GroupBy(cthd => cthd.MaHhNavigation.MaLoaiNavigation.TenLoai)
                .Select(g => new
                {
                    TenLoai = g.Key,
                    DoanhThu = g.Sum(cthd => cthd.SoLuong * cthd.DonGia)
                });
            return Json(data);
        }

        public IActionResult ThongKeLoai()
        {
            //Thống kê doanh thu theo loại
            var data = _context.ChiTietHd
                .GroupBy(cthd => new
                {
                    cthd.MaHhNavigation.MaLoaiNavigation.TenLoai,
                    cthd.MaHhNavigation.MaNccNavigation.TenCongTy
                })
                .Select(g => new
                {
                    TenLoai = g.Key.TenLoai,
                    TenCongTy = g.Key.TenCongTy,
                    DoanhThu = g.Sum(cthd => cthd.SoLuong * cthd.DonGia)
                });
            return Json(data);
        }
        #endregion
    }
}