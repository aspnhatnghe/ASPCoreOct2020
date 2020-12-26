using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Day19_AuthorAuthen.Data;
using Day19_AuthorAuthen.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Day19_AuthorAuthen.Controllers
{
    [Authorize]
    public class KhachHangController : Controller
    {
        private readonly eStore20Context _context;

        public KhachHangController(eStore20Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        [AllowAnonymous, HttpGet]
        public IActionResult DangNhap(string ReturnUrl = null)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [AllowAnonymous, HttpPost]
        public async Task<IActionResult> DangNhap(LoginVM loginVM, string ReturnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var kh = _context.KhachHang.SingleOrDefault(p => p.MaKh == loginVM.Username && p.MatKhau == loginVM.Password);

                if (kh != null)
                {
                    //tạo bộ claim cho user
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, kh.HoTen),
                        new Claim(ClaimTypes.Email, kh.Email),
                        new Claim("ID", kh.MaKh),
                        new Claim(ClaimTypes.Role, "Admin"),
                        new Claim(ClaimTypes.Role, "BanHang")
                    };

                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(claimsPrincipal);

                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Profile");
                }
            }
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        public async Task<IActionResult> DangXuat()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("DangNhap");
        }

        [Authorize(Roles ="Admin,KhachHang")]
        public IActionResult ThongKe()
        {
            return View();
        }

        [Authorize(Roles = "KhachHang")]
        public IActionResult TraCuuDonHang()
        {
            return View();
        }
    }
}