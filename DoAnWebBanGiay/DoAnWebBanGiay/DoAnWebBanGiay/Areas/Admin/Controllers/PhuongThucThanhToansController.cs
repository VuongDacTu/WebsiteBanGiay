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
    public class PhuongThucThanhToansController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public PhuongThucThanhToansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/PhuongThucThanhToans
        public async Task<IActionResult> Index()
        {
            return View(await _context.PhuongThucThanhToans.ToListAsync());
        }

        // GET: Admin/PhuongThucThanhToans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phuongThucThanhToan = await _context.PhuongThucThanhToans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phuongThucThanhToan == null)
            {
                return NotFound();
            }

            return View(phuongThucThanhToan);
        }

        // GET: Admin/PhuongThucThanhToans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/PhuongThucThanhToans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ten,Id")] PhuongThucThanhToan phuongThucThanhToan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phuongThucThanhToan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phuongThucThanhToan);
        }

        // GET: Admin/PhuongThucThanhToans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phuongThucThanhToan = await _context.PhuongThucThanhToans.FindAsync(id);
            if (phuongThucThanhToan == null)
            {
                return NotFound();
            }
            return View(phuongThucThanhToan);
        }

        // POST: Admin/PhuongThucThanhToans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ten,Id")] PhuongThucThanhToan phuongThucThanhToan)
        {
            if (id != phuongThucThanhToan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phuongThucThanhToan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhuongThucThanhToanExists(phuongThucThanhToan.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(phuongThucThanhToan);
        }

        // GET: Admin/PhuongThucThanhToans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phuongThucThanhToan = await _context.PhuongThucThanhToans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phuongThucThanhToan == null)
            {
                return NotFound();
            }

            return View(phuongThucThanhToan);
        }

        // POST: Admin/PhuongThucThanhToans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phuongThucThanhToan = await _context.PhuongThucThanhToans.FindAsync(id);
            if (phuongThucThanhToan != null)
            {
                _context.PhuongThucThanhToans.Remove(phuongThucThanhToan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhuongThucThanhToanExists(int id)
        {
            return _context.PhuongThucThanhToans.Any(e => e.Id == id);
        }
    }
}
