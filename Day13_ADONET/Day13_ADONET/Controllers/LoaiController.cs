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

        public IActionResult Update(int id)
        {
            var loai = loaiDal.GetLoai(id);
            return View(loai);
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
    }
}