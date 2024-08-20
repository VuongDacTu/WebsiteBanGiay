using DoAnWebBanGiay.Models.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DoAnWebBanGiay.Controllers
{
    public class ThuongHieuController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ThuongHieuController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? idThuongHieu, string name,string color,double minPrice, double maxPrice, int page = 1)
        {
            ViewBag.Anhsp = await _context.AnhSPs.ToListAsync();
            int limit = 10;
            var sp = await _context.SanPhams.ToPagedListAsync(page, limit);
            if (idThuongHieu != null)
            {
                sp = await _context.SanPhams.Where(x => x.IdThuongHieu == idThuongHieu).ToPagedListAsync(page, limit);
                if (name != null)
                {
                    sp = await _context.SanPhams.Where(x => x.IdThuongHieu == idThuongHieu && x.Ten.Contains(name)).ToPagedListAsync(page, limit);
                    if (color != null)
                    {
                        sp = await _context.SanPhams.Where(x => x.Mau == color && x.IdThuongHieu == idThuongHieu && x.Ten.Contains(name)).ToPagedListAsync(page, limit);
                    }
                    if (minPrice >= 0 && maxPrice >= 0)
                    {
                        sp = await _context.SanPhams.Where(x => x.Gia >= minPrice && x.Gia <= maxPrice && x.Ten.Contains(name)).ToPagedListAsync(page, limit);
                    }
                }
            }
            if(name != null)
            {
                sp = await _context.SanPhams.Where(x => x.Ten.Contains(name)).ToPagedListAsync(page, limit);
            }
            if(color != null)
            {
                sp = await _context.SanPhams.Where(x => x.Mau == color).ToPagedListAsync(page, limit);
            }
            if(minPrice > 0 && maxPrice > 0) 
            {
                sp = await _context.SanPhams.Where(x => x.Gia >= minPrice && x.Gia <= maxPrice).ToPagedListAsync(page, limit);
            }
            ViewBag.Name = name;
            ViewBag.idThuongHieu = idThuongHieu;
            return View(sp);
        }
        public async Task<IActionResult> ChiTietSP(int idSanPham)
        {
            if(idSanPham == 0)
            {
                return NotFound();
            }
            var chiTietSP = await _context.SanPhams.FindAsync(idSanPham);
            ViewBag.Anhsp = await _context.AnhSPs.ToListAsync();
            if (chiTietSP == null)
            {
                return NotFound();
            }
            ViewBag.ThuongHieu =  _context.ThuongHieus.FirstOrDefault(x => x.Id == chiTietSP.IdThuongHieu)?.Ten;
            return View(chiTietSP);
        }
    }

}
