using DoAnWebBanGiay.Models.DataAccess;
using DoAnWebBanGiay.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DoAnWebBanGiay.Controllers
{
    public class HistoryController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public HistoryController(ApplicationDbContext context) 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var user = JsonConvert.DeserializeObject<NguoiDung>(HttpContext.Session?.GetString("CustomerLogin")??"");
            string id = user?.Id??"";
            var donHang = _context.DonHangs.OrderByDescending(x => x.NgayMua).Where(x => x.IdNguoiDung == id).ToList();
            return View(donHang);
        }
        public IActionResult Details(string id)
        {
            var chitiet = _context.ChiTietDonHangs.Include(x => x.sanPham).Where(x => x.IdDonHang == id).ToList();
            
            ViewBag.AnhSP = _context.AnhSPs.ToList();
            return View(chitiet);
        }
    }
}
