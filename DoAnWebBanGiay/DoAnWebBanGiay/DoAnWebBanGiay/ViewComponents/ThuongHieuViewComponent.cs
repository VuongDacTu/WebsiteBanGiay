using DoAnWebBanGiay.Models.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnWebBanGiay.ViewComponents
{
    public class ThuongHieuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public ThuongHieuViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var thuonghieu = await _context.ThuongHieus.ToListAsync();
            return View(thuonghieu);
        }
    }
}
