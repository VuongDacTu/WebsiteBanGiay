using DoAnWebBanGiay.Models.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnWebBanGiay.Controllers
{
    public class GioiThieuController : Controller
    {
        private readonly ApplicationDbContext _context;
        public  GioiThieuController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tintuc = await _context.TinTucs.ToListAsync();
            return View(tintuc);
        }
    }
}
