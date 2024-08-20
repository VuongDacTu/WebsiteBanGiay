﻿using DoAnWebBanGiay.Models.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnWebBanGiay.ViewComponents
{
    public class PhanLoaiThuongHieuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public PhanLoaiThuongHieuViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var plsp = await _context.ThuongHieus.ToListAsync();
            return View(plsp);
        }
    }
}
