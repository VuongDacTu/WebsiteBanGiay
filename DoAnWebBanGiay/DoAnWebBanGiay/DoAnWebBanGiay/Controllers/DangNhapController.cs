using DoAnWebBanGiay.Models.DataAccess;
using DoAnWebBanGiay.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Security.Cryptography;
using System.Text;

namespace DoAnWebBanGiay.Controllers
{
    public class DangNhapController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DangNhapController(ApplicationDbContext context)
        {
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
                var user = await _context.NguoiDungs.Where(x => x.TaiKhoan == nguoiDung.TaiKhoan).FirstOrDefaultAsync(x => x.MatKhau == mk);
                if (user != null)
                {
                    if(user.IsActive == false)
                    {
                        ViewBag.Error = "Tài khoản đã bị khoá!";
                        return View(nguoiDung);
                    }
                    if (user.Role != "Customer")
                    {
                        ViewBag.Error = "Bạn không phải Admin!";
                        return View(nguoiDung);
                    }
                    HttpContext.Session.SetString("CustomerLogin", user.ToJson()); //chuyen doi tuong user sang dang JSON
                    return RedirectToAction("Index","Home");
                }
                ViewBag.Error = "Tài khoản hoặc mật khẩu không đúng";
                return View(nguoiDung);
            }
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                var taiKhoan = _context.NguoiDungs.FirstOrDefault(x => x.TaiKhoan == nguoiDung.TaiKhoan);
                if(taiKhoan != null)
                {
                    ViewBag.Error = "Tài khoản đã tồn tại";
                    return View(nguoiDung);
                }
                string guid = Guid.NewGuid().ToString();
                nguoiDung.Id = guid.Substring(guid.Length - 10);

                // cho phep tk hoat dong luon sau khi tao
                nguoiDung.IsActive = true;
                nguoiDung.IsDelete = false;
                nguoiDung.Role = "Customer";
                nguoiDung.MatKhau = GetSHA26Hash(nguoiDung.MatKhau);
                _context.NguoiDungs.Add(nguoiDung);
                await _context.SaveChangesAsync();

                // dang ky xong tra ve trang dang nhap
                return RedirectToAction("Login");
            }
            return View(nguoiDung);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("CustomerLogin");
            return RedirectToAction("Index","Home");
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
