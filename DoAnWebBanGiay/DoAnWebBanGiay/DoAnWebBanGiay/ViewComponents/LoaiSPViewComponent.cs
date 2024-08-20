using DoAnWebBanGiay.Models.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnWebBanGiay.ViewComponents
{
    public class LoaiSPViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public LoaiSPViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var plsp = await _context.LoaiSPs.ToListAsync();
            return View(plsp);
        }
    }
}
