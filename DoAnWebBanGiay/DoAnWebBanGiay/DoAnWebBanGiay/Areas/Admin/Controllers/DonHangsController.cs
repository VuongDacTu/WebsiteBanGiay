using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnWebBanGiay.Models.DataAccess;
using DoAnWebBanGiay.Models.Entities;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace DoAnWebBanGiay.Areas.Admin.Controllers
{
    public class DonHangsController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public DonHangsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/DonHangs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DonHangs.OrderByDescending(x => x.NgayMua).Include(d => d.nguoiDung).Include(d => d.phuongThucThanhToan);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/DonHangs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHangs
                .Include(d => d.nguoiDung)
                .Include(d => d.phuongThucThanhToan)
                .FirstOrDefaultAsync(m => m.Id == id);
            donHang.TrangThaiXem = true;
            _context.SaveChanges();
            ViewBag.ChiTiet = await _context.ChiTietDonHangs.Include(x=> x.sanPham).Where(x => x.IdDonHang == id).ToListAsync();
            ViewBag.AnhSP = await _context.AnhSPs.ToListAsync();
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // GET: Admin/DonHangs/Delete/5
        public async Task<IActionResult> Delete(string id, string status)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var donHang = await _context.DonHangs
                .Include(d => d.nguoiDung)
                .Include(d => d.phuongThucThanhToan)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (donHang == null)
            {
                return NotFound();
            }
            ViewBag.Status = status;
            return View(donHang);
        }

        // POST: Admin/DonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var donHang = await _context.DonHangs.FindAsync(id);
            var chiTiet = await _context.ChiTietDonHangs.Where(x => x.IdDonHang == id).ToListAsync();
            foreach (var item in chiTiet)
            {
                if (item != null)
                {
                    _context.ChiTietDonHangs.Remove(item);
                }


            }
            await _context.SaveChangesAsync();
            if (donHang.TrangThaiDonHang == null)
            {

                return RedirectToAction("Delete", new {status = "Đơn hàng cần được xác nhận lại trước khi xoá"});
            }
            if (donHang != null)
            {
                _context.DonHangs.Remove(donHang);
            }

            await _context.SaveChangesAsync();

            


            return RedirectToAction(nameof(Index));
        }

        private bool DonHangExists(string id)
        {
            return _context.DonHangs.Any(e => e.Id == id);
        }
        public IActionResult XacNhanDH(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang =  _context.DonHangs
                .FirstOrDefault(m => m.Id == id);
            if (donHang == null)
            {
                return NotFound();
            }
            donHang.TrangThaiDonHang = true;
            donHang.TrangThaiThanhToan = false;

            _context.SaveChanges();
            return RedirectToAction("Details", new { id = id });
        }
        public IActionResult HuyDH(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = _context.DonHangs
                .FirstOrDefault(m => m.Id == id);
            if (donHang == null)
            {
                return NotFound();
            }
            donHang.TrangThaiDonHang = false;
            donHang.TrangThaiThanhToan = false;
            _context.SaveChanges();
            return RedirectToAction("Details", new {id = id});
        }
        public IActionResult XacNhanTT(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = _context.DonHangs
                .FirstOrDefault(m => m.Id == id);
            if (donHang == null)
            {
                return NotFound();
            }
            donHang.TrangThaiThanhToan = true;
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = id });
        }
    }
}
