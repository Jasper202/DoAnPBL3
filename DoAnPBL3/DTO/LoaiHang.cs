using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnPBL3.DTO
{
    [Table("LoaiHang")]
    public class LoaiHang
    {
        public LoaiHang()
        {
            this.SanPhams = new HashSet<SanPham>();
        }
        [Key]
        [StringLength(9)]
        [Required]
        
        public string MaLH { get; set; }
        public string TenLH { get; set; }
        public string HangSX { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }

    }
}
