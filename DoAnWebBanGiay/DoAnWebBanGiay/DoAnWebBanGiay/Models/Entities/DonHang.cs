using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnWebBanGiay.Models.Entities
{
    public class DonHang
    {
        [Key]
        [StringLength(37, ErrorMessage = "Độ dài Id phải nhỏ hơn 37 ký tự")]
        public string Id { get; set; }

        [DisplayName("Tên")]
        public string? Ten { get; set; }

        [DisplayName("Ngày mua")]
        public DateTime? NgayMua { get; set; }
        public string? IdNguoiDung { get; set; }

        [DisplayName("Trạng thái đơn hàng")]
        public bool? TrangThaiDonHang { get; set; }
        public int? IdThanhToan { get; set; }
        [DisplayName("Tổng tiền")]

        public double? TongTien { get; set; }

        [DisplayName("Địa chỉ")]
        public string? DiaChi { get; set; }

        [DisplayName("Trạng thái thanh toán")]
        public bool? TrangThaiThanhToan { get; set; }

        [DisplayName("Mô tả")]
        public string? MoTa { get; set; }

        [DisplayName("Trạng thái xem")]
        public bool? TrangThaiXem {  get; set; }

        [DisplayName("Phí vận chuyển")]
        public double?  PhiVanChuyen { get; set; }


        [ForeignKey(nameof(IdNguoiDung))]
        public NguoiDung? nguoiDung { get; set; }

        [ForeignKey(nameof(IdThanhToan))]

        [DisplayName("Phương thức thanh toán")]
        public PhuongThucThanhToan? phuongThucThanhToan { get; set; }
    }
}
