using DoAnWebBanGiay.Models.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnWebBanGiay.ViewComponents
{
    public class BannerViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public BannerViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var banner = await _context.Banners.ToListAsync();
            return View(banner);
        }
    }
}
