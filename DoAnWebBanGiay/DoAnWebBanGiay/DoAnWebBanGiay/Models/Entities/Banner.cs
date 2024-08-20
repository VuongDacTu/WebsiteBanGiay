using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DoAnWebBanGiay.Models.Entities
{
    public class Banner:BaseEntity
    {
        [DisplayName("Tên")]
        public string? Ten { get; set; }

        [DisplayName("Ảnh")]
        public string? Anh { get; set; }

        [DisplayName("Nội dung")]
        public string? NoiDung { get; set; }
        public bool? IsActive { get; set; }
    }
}
