using DoAnWebBanGiay.Models.DataAccess;
using DoAnWebBanGiay.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Security.Cryptography;
using System.Text;

namespace DoAnWebBanGiay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DangNhapController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DangNhapController(ApplicationDbContext context) {
        _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                var mk = GetSHA26Hash(nguoiDung.MatKhau);
                var user = await _context.NguoiDungs.Where(x => x.TaiKhoan == nguoiDung.TaiKhoan).FirstOrDefaultAsync(x => x.MatKhau ==  mk );
                if(user != null)
                {
                    if (user.IsActive == false)
                    {
                        ViewBag.Error = "Tài khoản đã bị khoá!";
                        return View(nguoiDung);
                    }
                    if (user.Role != "Admin")
                    {
                        ViewBag.Error = "Đây không phải tài khoản Admin!";
                        return View(nguoiDung);
                    }
                    HttpContext.Session.SetString("AdminLogin",user.ToJson()); //chuyen doi tuong user sang dang JSON
                    return Redirect("/Admin/Home/Index");
                }
                ViewBag.Error = "Tài khoản hoặc mật khẩu không đúng";
                return View(nguoiDung);
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AdminLogin");
            return RedirectToAction("Login");
        }
        // ma hoa mat khau
        static string GetSHA26Hash(string input)
        {
            string hash = "";
            using (var sha256 = new SHA256Managed())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
            return hash;
        }

    }
}
