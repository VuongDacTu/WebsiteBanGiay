using DoAnWebBanGiay.Models.DataAccess;
using DoAnWebBanGiay.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace DoAnWebBanGiay.Controllers
{
    public class LienHeController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public LienHeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string status)
        {
            // lay ra nguoi dung dang dang nhap
            var cus = JsonConvert.DeserializeObject<NguoiDung>(HttpContext.Session.GetString("CustomerLogin") ??"");
            if( cus!= null)
            {
                ViewBag.Id = cus.Id;
                ViewBag.Name = cus.HoTen;
                ViewBag.Status = status;
                ViewBag.Email = cus.Email;
            }


            return View( await _context.LienHes.ToListAsync());
        }

        public async Task<IActionResult> submit(string id, string message)
        {
            if (!message.IsNullOrEmpty())
            {
                _context.PhanHois.Add(new PhanHoi
                {
                    NoiDung = message,
                    IdNguoiDung = id,
                    TrangThaiXem = false
                });
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new
                {
                    status = "Ban da gui thanh cong!"
                });
            }
            return RedirectToAction("Index", new
            {
                status = "tin nhan khong duoc de trong!"
            });
        }
    }
}
