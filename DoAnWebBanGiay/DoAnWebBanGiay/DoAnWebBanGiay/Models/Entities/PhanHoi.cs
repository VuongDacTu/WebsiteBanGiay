using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnWebBanGiay.Models.Entities
{
    public class PhanHoi : BaseEntity
    {
        [DisplayName("Nội dung")]
        public string? NoiDung { get; set; }
        public string? IdNguoiDung { get; set; }
        public bool? TrangThaiXem { get; set; }

        [ForeignKey(nameof(IdNguoiDung))]

        [DisplayName("Người dùng")]
        public NguoiDung? nguoiDung { get; set; }
    }
}
