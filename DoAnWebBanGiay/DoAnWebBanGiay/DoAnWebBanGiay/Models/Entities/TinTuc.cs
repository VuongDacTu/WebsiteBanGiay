using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DoAnWebBanGiay.Models.Entities
{
    public class TinTuc : BaseEntity
    {
        [DisplayName("Nội dung")]
        public string? NoiDung { get; set; }
        [DisplayName("Ảnh")]

        public string? Anh { get; set; }

        [DisplayName("Ngày đăng")]
        public DateTime? NgayDang { get; set; }

        [DisplayName("Tiêu đề")]
        public string? TieuDe { get; set; }
    }
}
