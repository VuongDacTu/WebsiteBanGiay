using DoAnWebBanGiay.Models;
using DoAnWebBanGiay.Models.DataAccess;
using DoAnWebBanGiay.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using NuGet.Protocol;

namespace DoAnWebBanGiay.Controllers
{
    public class GioHangController :BaseController
    {
        private readonly ApplicationDbContext _context;
        public GioHangController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string status)
        {

            var ss = HttpContext.Session?.GetString("giohang")??"";

            var gioHang = JsonConvert.DeserializeObject<List<GioHang>>(ss); //lấy sản phầm của người đang sử dụng thêm vào giở hàng
            if (ss =="")
            {
                gioHang = new List<GioHang>()
                {
                    new GioHang()
                    {

                    }
                };
            }
            ViewBag.PTTT = _context.PhuongThucThanhToans.ToList();
            ViewBag.Status = status;    
            ViewBag.AnhSP = _context.AnhSPs.ToList();
            ViewBag.SanPham = _context.SanPhams.ToList();
            return View(gioHang);

        }
        public IActionResult ThemVaoGio(int idSP, int soLuong, double gia )
        {
            GioHang gioHang = new GioHang()
            {
                IdSanPham = idSP,
                SoLuong = soLuong,
                Gia = gia
            };
            // kiểm tra xem có sp nào trong giỏ hàng chưa
            var ss = HttpContext.Session?.GetString("giohang") ?? "";
            List<GioHang> gioHangs = JsonConvert.DeserializeObject<List<GioHang>>(ss)??new List<GioHang>() { };

            if (gioHangs.FirstOrDefault(x => x.IdSanPham == gioHang.IdSanPham) == null)
            {    
                gioHangs.Add(gioHang);
            }
            else
            {
                gioHangs.FirstOrDefault(x => x.IdSanPham == gioHang.IdSanPham).SoLuong += gioHangs.FirstOrDefault()?.SoLuong??0;
            }
            HttpContext.Session.SetString("giohang",gioHangs.ToJson());
            return RedirectToAction("Index");
        }
        public IActionResult XoaGioHang(int id)
        {
            var ss = HttpContext.Session?.GetString("giohang") ?? "";
            List<GioHang> gioHangs = JsonConvert.DeserializeObject<List<GioHang>>(ss) ?? new List<GioHang>() { };
            GioHang gh = gioHangs.FirstOrDefault(x => x.IdSanPham == id);
            if(gh == null)
            {
                return NotFound();
            }    
            gioHangs.Remove(gh);
            HttpContext.Session.SetString("giohang", gioHangs.ToJson());
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult ThanhToan(Dictionary<string, int> soLuong, string address, string tt)
        {

            if (tt == null)
            {
                return RedirectToAction("Index", new { status = "Vui lòng chọn phương thức thanh toán" });
            }
            // cap nhat lai gio hang
            var ss = HttpContext.Session?.GetString("giohang") ?? "";
            List<GioHang> gioHangs = JsonConvert.DeserializeObject<List<GioHang>>(ss) ?? new List<GioHang>() { };
            foreach(var item in soLuong)
            {
                var gh = gioHangs.FirstOrDefault(x => x.IdSanPham == int.Parse(item.Key));
                if(gh == null)
                {
                    return RedirectToAction("Index",new { status = "Lỗi! không tìm thấy đơn hàng nào trong giỏ" });
                }
                gh.SoLuong = item.Value;
            }
            HttpContext.Session.SetString("giohang", gioHangs.ToJson());
            //
            if(gioHangs == null) 
            {
                return RedirectToAction("Index", new { status = "Lỗi! không tìm thấy đơn hàng nào trong giỏ" });
            }
            string guid = Guid.NewGuid().ToString();
            var user = JsonConvert.DeserializeObject<NguoiDung>(HttpContext.Session.GetString("CustomerLogin"));
            var ss1 = HttpContext.Session?.GetString("giohang") ?? "";
            List<GioHang> ghs = JsonConvert.DeserializeObject<List<GioHang>>(ss1) ?? new List<GioHang>() { };
            double TongTien = 0;
            foreach(var item in ghs)
            {
                TongTien += item.Gia * item.SoLuong;
                var dhsl = _context.SanPhams.FirstOrDefault(x => x.Id == item.IdSanPham);
                if(dhsl.SoLuong < item.SoLuong)
                {
                    return RedirectToAction("Index", new { status = dhsl.Ten + " còn " + dhsl.SoLuong + "sản phẩm! Quá số lượng trong kho"});
                }
                dhsl.SoLuong -= item.SoLuong;
            }
            DonHang dh = new DonHang()
            {
                Id = guid,
                Ten = guid,
                NgayMua = DateTime.Now,
                IdNguoiDung = user.Id,
                TrangThaiDonHang = null,
                TongTien = TongTien,
                DiaChi = address,
                TrangThaiThanhToan = null,
                MoTa = "",
                PhiVanChuyen = 20000,
                //IdThanhToan = tt
            };
            _context.DonHangs.Add(dh);
            _context.SaveChanges();
            foreach (var item in ghs)
            {
                ChiTietDonHang ctdh = new ChiTietDonHang()
                {
                    IdSanPham = item.IdSanPham,
                    IdDonHang = guid,
                    SoLuong = item.SoLuong,
                    Gia = item.Gia,
                    Size = item.Size,   
                };
                _context.ChiTietDonHangs.Add(ctdh);

            }
            _context.SaveChanges();
            
            HttpContext.Session.Remove("giohang");
            return RedirectToAction("Index",new { status = "Thanh toán thành công !!!" });
        }
    }
}
