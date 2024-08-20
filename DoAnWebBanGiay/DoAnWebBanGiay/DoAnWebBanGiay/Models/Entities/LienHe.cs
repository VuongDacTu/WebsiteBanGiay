using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DoAnWebBanGiay.Models.Entities
{
    public class LienHe: BaseEntity
    {
 
        public string? SDT { get; set; }
        public string? Email { get; set; }

        [DisplayName("Địa chỉ")]
        public string? DiaChi { get; set; }
        public string? FaceBook { get; set; }
        public string? Instagram { get; set; }
        public string?  TikTok { get; set; }

    }
}
