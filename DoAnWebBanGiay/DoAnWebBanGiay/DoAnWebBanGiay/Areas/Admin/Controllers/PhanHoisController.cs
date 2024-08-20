using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnWebBanGiay.Models.DataAccess;
using DoAnWebBanGiay.Models.Entities;

namespace DoAnWebBanGiay.Areas.Admin.Controllers
{
    public class PhanHoisController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public PhanHoisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/PhanHois
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PhanHois.Include(p => p.nguoiDung);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/PhanHois/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanHoi = await _context.PhanHois
                .Include(p => p.nguoiDung)
                .FirstOrDefaultAsync(m => m.Id == id);
            phanHoi.TrangThaiXem = true;
            await _context.SaveChangesAsync();
            if (phanHoi == null)
            {
                return NotFound();
            }

            return View(phanHoi);
        }

        // GET: Admin/PhanHois/Create
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanHoi = await _context.PhanHois
                .Include(p => p.nguoiDung)
                .FirstOrDefaultAsync(m => m.Id == id);
   
            if (phanHoi == null)
            {
                return NotFound();
            }

            return View(phanHoi);
        }

        // POST: Admin/PhanHois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phanHoi = await _context.PhanHois.FindAsync(id);
            if (phanHoi != null)
            {
                _context.PhanHois.Remove(phanHoi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhanHoiExists(int id)
        {
            return _context.PhanHois.Any(e => e.Id == id);
        }
    }
}
