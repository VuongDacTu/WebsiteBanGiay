﻿using System;
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
  
    public class LienHesController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public LienHesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/LienHes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LienHes.ToListAsync());
        }

        // GET: Admin/LienHes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lienHe = await _context.LienHes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lienHe == null)
            {
                return NotFound();
            }

            return View(lienHe);
        }

        // GET: Admin/LienHes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/LienHes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SDT,Email,DiaChi,FaceBook,Instagram,TikTok,Id")] LienHe lienHe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lienHe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lienHe);
        }

        // GET: Admin/LienHes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lienHe = await _context.LienHes.FindAsync(id);
            if (lienHe == null)
            {
                return NotFound();
            }
            return View(lienHe);
        }

        // POST: Admin/LienHes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SDT,Email,DiaChi,FaceBook,Instagram,TikTok,Id")] LienHe lienHe)
        {
            if (id != lienHe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lienHe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LienHeExists(lienHe.Id))
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
            return View(lienHe);
        }

        // GET: Admin/LienHes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lienHe = await _context.LienHes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lienHe == null)
            {
                return NotFound();
            }

            return View(lienHe);
        }

        // POST: Admin/LienHes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lienHe = await _context.LienHes.FindAsync(id);
            if (lienHe != null)
            {
                _context.LienHes.Remove(lienHe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LienHeExists(int id)
        {
            return _context.LienHes.Any(e => e.Id == id);
        }
    }
}
