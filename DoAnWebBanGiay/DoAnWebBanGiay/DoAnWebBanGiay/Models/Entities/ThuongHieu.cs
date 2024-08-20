using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DoAnWebBanGiay.Models.Entities
{
    public class ThuongHieu : BaseEntity
    {
        [DisplayName("Tên thương hiệu")]
        public string? Ten { get; set; }
        public bool? IsDelete { get; set; }
    }
}
