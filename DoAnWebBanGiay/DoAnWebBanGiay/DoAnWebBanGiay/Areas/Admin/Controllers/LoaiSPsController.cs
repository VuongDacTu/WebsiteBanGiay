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
    
    public class LoaiSPsController : BaseController   
    {
        private readonly ApplicationDbContext _context;

        public LoaiSPsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/LoaiSPs
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoaiSPs.ToListAsync());
        }

        // GET: Admin/LoaiSPs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSP = await _context.LoaiSPs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loaiSP == null)
            {
                return NotFound();
            }

            return View(loaiSP);
        }

        // GET: Admin/LoaiSPs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiSPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ten,IsDelete,Id")] LoaiSP loaiSP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiSP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiSP);
        }

        // GET: Admin/LoaiSPs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSP = await _context.LoaiSPs.FindAsync(id);
            if (loaiSP == null)
            {
                return NotFound();
            }
            return View(loaiSP);
        }

        // POST: Admin/LoaiSPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ten,IsDelete,Id")] LoaiSP loaiSP)
        {
            if (id != loaiSP.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiSP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiSPExists(loaiSP.Id))
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
            return View(loaiSP);
        }

        // GET: Admin/LoaiSPs/Delete/5
        public async Task<IActionResult> Delete(int? id, string status)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSP = await _context.LoaiSPs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loaiSP == null)
            {
                return NotFound();
            }
            ViewBag.Status = status;    
            return View(loaiSP);
        }

        // POST: Admin/LoaiSPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiSP = await _context.LoaiSPs.FindAsync(id);
            var sp = _context.SanPhams.FirstOrDefault(x => x.IdLoaiSP == id);
            if(sp != null)
            {
                return RedirectToAction("Delete", new {status = "Loại sản phẩm đang được sử dụng! Không thể xóa"});
            }
            if (loaiSP != null)
            {
                _context.LoaiSPs.Remove(loaiSP);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiSPExists(int id)
        {
            return _context.LoaiSPs.Any(e => e.Id == id);
        }
    }
}
