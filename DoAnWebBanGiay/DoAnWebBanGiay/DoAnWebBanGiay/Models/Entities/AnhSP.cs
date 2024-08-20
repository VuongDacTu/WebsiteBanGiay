using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnWebBanGiay.Models.Entities
{
    public class AnhSP:BaseEntity
    {
        [DisplayName("Ảnh")]
        public string? Anh { get; set; }

        public int? IdSanPham { get; set; }

        [DisplayName("Ngày tạo")]
        public DateTime? NgayTao { get; set; }

        [DisplayName("Người tạo")]
        public string? NguoiTao { get; set; }

        [DisplayName("Mô tả")]
        public string? Mota {  get; set; }
        [ForeignKey(nameof(IdSanPham))]
        public SanPham? sanPham { get; set; }
    }
}
