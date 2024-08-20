using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnWebBanGiay.Models.Entities
{
    public class SanPham : BaseEntity
    {
        [DisplayName("Tên")]
        public string? Ten { get; set; }

        [DisplayName("Mô tả")]
  
        public string? MoTa { get; set; }
        public string? Size { get; set; }

        [DisplayName("Số lượng")]
        public int? SoLuong { get; set; }

        [DisplayName("Giá bán")]
        public double? Gia { get; set; }

        [DisplayName("Giảm giá(%)")]
        public double? GiamGia { get; set; }
        public bool? TrangThai { get; set; }

        [DisplayName("Loại sản phẩm")]
        public int? IdLoaiSP { get; set; } = 0;

        [DisplayName("Thương hiệu")]
        public int? IdThuongHieu { get; set; }
        public DateTime? NgayTao { get; set; }
        public string? NguoiTao { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public string? NguoiCapNhat { get; set; }
        public bool? IsDelete { get; set; }

        [DisplayName("Màu")]
        public string? Mau { get; set; }

        [DisplayName("Giá nhập")]
        public double? GiaNhap { get; set; }

        [ForeignKey(nameof(IdLoaiSP))]

        [DisplayName("Loại sản phẩm")]
        public LoaiSP? loaiSP { get; set; }

        [ForeignKey(nameof(IdThuongHieu))]


        [DisplayName("Thương hiệu")]
        public ThuongHieu? thuongHieu { get; set; }

        public double ThanhTien { get; set; }
    }
}
