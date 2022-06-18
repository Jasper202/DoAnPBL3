using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnPBL3.DTO
{
    [Table("LichSu_GH")]
    public class LichSu_GH
    {
        [Key]
        [StringLength(9)]
        public string MaLS { get; set; }
        [StringLength(9)]
        public string MaHV { get; set; }
        
        public DateTime NgayGH { get; set; }
        public string ThoigianGH { get; set; }
        [StringLength(9)]
        public string MaNV { get; set; }
        
        public double Gia { get; set; }
        [ForeignKey("MaHV")]
        public virtual TheHV TheHV { get; set; }
        [ForeignKey("MaNV")]
        public virtual NhanVien NhanVien { get; set; }
        
    }
}
