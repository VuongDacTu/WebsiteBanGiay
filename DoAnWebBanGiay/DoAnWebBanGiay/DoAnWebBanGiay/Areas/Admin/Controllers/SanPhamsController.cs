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
using Newtonsoft.Json;

namespace DoAnWebBanGiay.Areas.Admin.Controllers
{
    public class SanPhamsController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public SanPhamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/SanPhams
        public async Task<IActionResult> Index(int page = 1)
        {
            int limit = 10;
            var applicationDbContext = _context.SanPhams.Include(s => s.loaiSP).Include(s => s.thuongHieu);
            ViewBag.AnhSP = await _context.AnhSPs.ToListAsync();
            return View(await applicationDbContext.ToPagedListAsync(page,limit));
        }

        // GET: Admin/SanPhams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.loaiSP)
                .Include(s => s.thuongHieu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: Admin/SanPhams/Create
        public IActionResult Create()
        {
            ViewData["IdLoaiSP"] = new SelectList(_context.LoaiSPs, "Id", "Ten");
            ViewData["IdThuongHieu"] = new SelectList(_context.ThuongHieus, "Id", "Ten");
            return View();
        }

        // POST: Admin/SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ten,MoTa,Size,SoLuong,Gia,GiamGia,TrangThai,IdLoaiSP,IdThuongHieu,NgayTao,NguoiTao,NgayCapNhat,NguoiCapNhat,IsDelete,Mau,GiaNhap,Id,ThanhTien")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                var admin = JsonConvert.DeserializeObject<NguoiDung>(HttpContext.Session.GetString("AdminLogin"));
                sanPham.NguoiTao = admin.TaiKhoan;
                sanPham.NgayTao = DateTime.Now;
                sanPham.IsDelete = false;
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                int id = _context.SanPhams.OrderByDescending(s => s.Id).FirstOrDefault()?.Id??0;

                if(id != 0)
                {
                    var anhSP = new AnhSP
                    {
                        IdSanPham = id,
                        NgayTao = DateTime.Now,
                    };

                    // phuong thuc upload anh
                    var files = HttpContext.Request.Form.Files;
                    if (files.Count() > 0 && files[0].Length > 0)
                    {
                        var file = files[0];
                        var FileName = file.FileName;
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Adminassets\\Img\\sanpham", FileName);
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(stream);
                            anhSP.Anh = FileName;
                        }
                    }
                    _context.AnhSPs.Add(anhSP);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLoaiSP"] = new SelectList(_context.LoaiSPs, "Id", "Ten", sanPham.IdLoaiSP);
            ViewData["IdThuongHieu"] = new SelectList(_context.ThuongHieus, "Id", "Ten", sanPham.IdThuongHieu);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["IdLoaiSP"] = new SelectList(_context.LoaiSPs, "Id", "Ten", sanPham.IdLoaiSP);
            ViewData["IdThuongHieu"] = new SelectList(_context.ThuongHieus, "Id", "Ten", sanPham.IdThuongHieu);
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Ten,MoTa,Size,SoLuong,Gia,GiamGia,TrangThai,IdLoaiSP,IdThuongHieu,NgayTao,NguoiTao,NgayCapNhat,NguoiCapNhat,IsDelete,Mau,GiaNhap,Id")] SanPham sanPham)
        {
            if (id != sanPham.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var admin = JsonConvert.DeserializeObject<NguoiDung>(HttpContext.Session.GetString("AdminLogin")); // convert tu Json => object
                    sanPham.NguoiCapNhat = admin.TaiKhoan;
                    sanPham.NgayCapNhat = DateTime.Now;
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.Id))
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
            ViewData["IdLoaiSP"] = new SelectList(_context.LoaiSPs, "Id", "Ten", sanPham.IdLoaiSP);
            ViewData["IdThuongHieu"] = new SelectList(_context.ThuongHieus, "Id", "Ten", sanPham.IdThuongHieu);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.loaiSP)
                .Include(s => s.thuongHieu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: Admin/SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var sanPham = await _context.SanPhams.FindAsync(id);
            var anhsp = _context.AnhSPs.Where(x => x.IdSanPham == id).ToList();
            if(anhsp != null)
            {
                foreach (var item in anhsp)
                {
                    _context.AnhSPs.Remove(item);
                }
            }
            _context.SaveChanges();
            if (sanPham != null)
            {
                _context.SanPhams.Remove(sanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(int id)
        {
            return _context.SanPhams.Any(e => e.Id == id);
        }
    }
}
