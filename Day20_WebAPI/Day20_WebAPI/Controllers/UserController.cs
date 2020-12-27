using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Day20_WebAPI.Data;
using Day20_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Day20_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly eStore20Context _context;
        private readonly byte[] _secretKeyBytes;
        public UserController(eStore20Context context, IConfiguration configuration)
        {
            _context = context;
            var secretKey = configuration["AppSettings:SecretKey"];
            _secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginVM model)
        {
            var result = new ApiResult();
            var kh = _context.KhachHang.SingleOrDefault(p => p.MaKh == model.Username && p.MatKhau == model.Password);

            if(kh == null)
            {
                result.Success = false;
                result.Message = "Sai thông tin đăng nhập";
            }
            else
            {
                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, kh.HoTen),
                    new Claim(ClaimTypes.Email, kh.Email),
                    new Claim("MaKH", kh.MaKh),
                    new Claim(ClaimTypes.Role, "KhachHang")
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDesc = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddMinutes(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_secretKeyBytes), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDesc);

                result.Success = true;
                result.Message = "Đăng nhập thành công";
                result.Data = new { Token = tokenHandler.WriteToken(token) };
            }
            return Ok(result);
        }
    }
}