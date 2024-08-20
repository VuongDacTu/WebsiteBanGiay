using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnWebBanGiay.Models.Entities
{
    public class ChiTietDonHang : BaseEntity
    {
        public int? IdSanPham { get; set; }
        public string? IdDonHang { get; set; }

        [DisplayName("Số lượng")]
        public int? SoLuong { get; set; }

        [DisplayName("Giá")]
        public double? Gia { get; set; }
        public string? Size { get; set; }

        [ForeignKey(nameof(IdSanPham))]
        public SanPham?  sanPham { get; set; }

        [ForeignKey(nameof(IdDonHang))]
        public DonHang? donHang { get; set; }
    }
}

