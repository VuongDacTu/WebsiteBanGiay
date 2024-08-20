using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DoAnWebBanGiay.Models.Entities
{
    public class NguoiDung 
    {
        [Key]
        public string? Id { get; set; } = null!;

        [DisplayName("Họ tên")]
        public string? HoTen { get; set; } = null!;
        public bool? GioiTinh { get; set; }
        public string? SDT { get; set; } = null!;
        [EmailAddress]
        public string? Email { get; set; }

        [DisplayName("Địa chỉ")]
        public string? DiaChi { get; set; }
        [Required(ErrorMessage = "Tai khoan khong duoc rong")]


        [DisplayName("Tài khoản")]
        public string? TaiKhoan { get; set; }
        public string? MatKhau { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

        [DisplayName("Ảnh")]
        public string? Anh { get; set; }

        [DisplayName("Quyền")]
        public string? Role { get; set; }
    }
}
