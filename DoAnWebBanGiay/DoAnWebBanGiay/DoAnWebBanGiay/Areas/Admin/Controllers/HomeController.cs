using DoAnWebBanGiay.Models.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DoAnWebBanGiay.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string year = "")
        {
            int selectedyear = -1;
            Int32.TryParse(year, out selectedyear);
            if (year == "" || selectedyear == -1)
            {
                year = DateTime.Now.Year.ToString();
                Int32.TryParse(year, out selectedyear);
            }
        
            ViewBag.TongDoanhThu = string.Format("{0:0,0} VND", ThongKeTongDoanhThu());
            ViewBag.TangTruong = 0;
 

            return View();
        }
        public IActionResult Filtter(string year = "")
        {
            var url = $"/Admin/Home?year={year.Trim()}";
            if (year == "")
            {
                url = $"/Admin/Home";
            }
            return Json(new { status = "success", redirectUrl = url });
        }
        public decimal ThongKeTongDoanhThu()
        {
            decimal TongDoanhThu = (decimal)_context.ChiTietDonHangs.Include(x => x.sanPham).Sum(n => n.SoLuong * (n.Gia - n.sanPham.GiaNhap));
            return TongDoanhThu;
        }
    }
}
