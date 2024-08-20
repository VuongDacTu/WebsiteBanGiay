using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DoAnWebBanGiay.Models.Entities
{
    public class LoaiSP : BaseEntity
    {

        [DisplayName("Tên")]
        public string? Ten { get; set; } 
        public bool? IsDelete { get; set; }
    }
}
