using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnPBL3.DTO
{
    [Table("CTHD")]
    public class CTHD
    {
        
        [StringLength(9)]
        [Key]
        public string MaHD { get; set; }
        
        public int SoLuong { get; set; }
        
        [StringLength(9)]
        public string MaSP { get; set; }
        
        public double Gia { get; set; }
        [ForeignKey("MaHD")]
        public virtual HoaDon HoaDon { get; set; }
        [ForeignKey("MaSP")]
        public virtual SanPham SanPham { get; set; }

    }
}
