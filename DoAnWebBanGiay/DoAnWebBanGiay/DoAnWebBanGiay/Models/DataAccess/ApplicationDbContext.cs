using DoAnWebBanGiay.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoAnWebBanGiay.Models.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public virtual DbSet<AnhSP> AnhSPs { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set;}
        public virtual DbSet<LienHe>  LienHes {  get; set; }
        public virtual DbSet<LoaiSP> LoaiSPs { get; set;}
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<PhanHoi> PhanHois { get; set;}
        public virtual DbSet<PhuongThucThanhToan> PhuongThucThanhToans { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<ThuongHieu> ThuongHieus { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set;}
    }
}
