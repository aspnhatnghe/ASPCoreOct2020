using Day20_WebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Day20_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly eStore20Context _context;

        public LoaiController(eStore20Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _context.Loai.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var loai = await _context.Loai.SingleOrDefaultAsync(p => p.MaLoai == id);
            if (loai != null)
                return Ok(loai);
            return NotFound();
        }

        [HttpPost] //Tạo mới
        public IActionResult Create(Loai model)
        {
            try
            {
                var loai = _context.Add(model);
                _context.SaveChanges();
                return this.Ok(loai);
            }
            catch
            {
                return this.StatusCode(500);
            }
        }


        [HttpPut("{id}")] //Cập nhật
        public IActionResult UpdateLoai(int id, Loai model)
        {
            if (id != model.MaLoai)
                return this.BadRequest();
            try
            {
                var loai = _context.Update(model);
                _context.SaveChanges();
                return this.Ok(loai);
            }
            catch
            {
                return this.StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoaiAsync(int id)
        {
            var loai = await _context.Loai.SingleOrDefaultAsync(p => p.MaLoai == id);
            if (loai == null) return NotFound();
            try
            {
                _context.Remove(loai);
                await _context.SaveChangesAsync();
                return this.Ok();
            }
            catch
            {
                return this.StatusCode(500);
            }
        }
    }
}