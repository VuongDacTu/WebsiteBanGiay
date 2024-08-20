using DoAnWebBanGiay.Models.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace DoAnWebBanGiay.Areas.Admin.ViewComponents
{
    public class DonHangViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public DonHangViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int tt = _context.DonHangs.Where(x => x.TrangThaiXem != true).Count();
            return View(tt);
        }
    }
}
