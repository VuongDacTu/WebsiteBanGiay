using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnWebBanGiay.Models.DataAccess;
using DoAnWebBanGiay.Models.Entities;
using X.PagedList;

namespace DoAnWebBanGiay.Areas.Admin.Controllers
{

    public class NguoiDungsController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public NguoiDungsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/NguoiDungs
        public async Task<IActionResult> Index(string status,int page = 1)
        {
            ViewBag.Error = status;
            int limit = 10;
            return View(await _context.NguoiDungs.ToPagedListAsync(page,limit));
        }

        // GET: Admin/NguoiDungs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDung = await _context.NguoiDungs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            return View(nguoiDung);
        }

        // GET: Admin/NguoiDungs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDung = await _context.NguoiDungs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            return View(nguoiDung);
        }

        // POST: Admin/NguoiDungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var nguoiDung = await _context.NguoiDungs.FindAsync(id);
            if (nguoiDung != null)
            {
                nguoiDung.IsActive = false;
            }
            if(nguoiDung.TaiKhoan == "phamquangduong")
            {
                return RedirectToAction("Index", new {status = "Tài khoản này không thể bị khoá"});
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Active(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDung = await _context.NguoiDungs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            return View(nguoiDung);
        }

        [HttpPost, ActionName("Active")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActiveConfirmed(string id)
        {
            var nguoiDung = await _context.NguoiDungs.FindAsync(id);
            if (nguoiDung != null)
            {
                nguoiDung.IsActive = true;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool NguoiDungExists(string id)
        {
            return _context.NguoiDungs.Any(e => e.Id == id);
        }
    }
}
