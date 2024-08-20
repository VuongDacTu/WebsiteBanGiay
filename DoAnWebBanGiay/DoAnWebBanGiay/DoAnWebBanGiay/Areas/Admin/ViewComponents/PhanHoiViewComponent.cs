using DoAnWebBanGiay.Models.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnWebBanGiay.Areas.Admin.ViewComponents
{
    public class PhanHoiViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public PhanHoiViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var phanhoi = await _context.PhanHois.Where(x => x.TrangThaiXem != true).ToListAsync();
            return View(phanhoi);
        }
    }
}
