using Day13_ADONET.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Day13_ADONET.Controllers
{
    public class LoaiController : Controller
    {
        private LoaiDataAccessLayer loaiDal;

        public LoaiController()
        {
            loaiDal = new LoaiDataAccessLayer();
        }

        public IActionResult Index()
        {
            return View(loaiDal.GetAll());
        }

        public IActionResult Edit(int id)
        {
            var loai = loaiDal.GetLoai(id);
            if (loai != null)
            {
                return View(loai);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(int id, Loai loai, IFormFile HinhUpdate)
        {
            if(id != loai.MaLoai)
            {
                return RedirectToAction("Edit", new { id = id });
            }
            if(HinhUpdate != null)
            {
                var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", "Loai", HinhUpdate.FileName);
                using (var file = new FileStream(fullPath, FileMode.Create))
                {
                    HinhUpdate.CopyTo(file);
                }
                //cập nhật field Hình
                loai.Hinh = HinhUpdate.FileName;
            }
            var result = loaiDal.UpdateLoai(loai);
            if(result)
            {
                return RedirectToAction("Index");
            }
            TempData["ThongBao"] = $"Cập nhật loại {id} thất bại";
            return RedirectToAction("Edit", new { id = id });
        }

        #region Tạo mới
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Loai loai, IFormFile Hinh)
        {
            if (ModelState.IsValid)
            {
                if (Hinh != null)
                {
                    var fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", "Loai", Hinh.FileName);
                    using (var file = new FileStream(fullPath, FileMode.Create))
                    {
                        Hinh.CopyTo(file);
                    }
                    //cập nhật field Hình
                    loai.Hinh = Hinh.FileName;
                }

                var maLoai = loaiDal.AddLoai(loai);
                if (maLoai.HasValue)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        #endregion

        public IActionResult Delete(int id)
        {
            var result = loaiDal.RemoveLoai(id);

            TempData["ThongBao"] = $"Xóa loại {id} {(result ? "thành công" : "thất bại")}.";

            return RedirectToAction("Index");
        }
    }
}