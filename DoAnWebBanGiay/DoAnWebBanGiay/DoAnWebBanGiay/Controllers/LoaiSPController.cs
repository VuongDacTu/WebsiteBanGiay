using DoAnWebBanGiay.Models.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DoAnWebBanGiay.Controllers
{
    public class LoaiSPController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoaiSPController(ApplicationDbContext context) 
        {
            _context=context;
        }
        public async Task<IActionResult> Index(int idLoaiSP, int page = 1)
        {
            int limit = 9;
            
            var sanPham = await _context.SanPhams.ToPagedListAsync(page, limit);
            if(idLoaiSP != 0)
            {
                sanPham = await _context.SanPhams.Where(x => x.IdLoaiSP == idLoaiSP).ToPagedListAsync(page, limit);
            }
            ViewBag.AnhSP = await _context.AnhSPs.ToListAsync();
            return View(sanPham);
        }
    }
}
