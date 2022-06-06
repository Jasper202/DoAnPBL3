using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnPBL3.DTO
{
    [Table("TheHV")]
    public class TheHV
    {
        public TheHV()
        {
            this.LichSu_GHs = new HashSet<LichSu_GH>();
        }
        public virtual ICollection<LichSu_GH> LichSu_GHs { get; set; }
        [Key]
        [StringLength(9)]
        [Required]
        public string MaHV { get; set; }
        public DateTime NgayDK { get; set; }
        public DateTime NgayKT { get; set; }
        [StringLength(9)]
        public string MaGT { get; set; }
        

        [StringLength(9)]
        public string MaKH { get; set; }
        

        [StringLength(9)]
        public string MaNV { get; set; }
        [ForeignKey("MaKH")]
        public virtual KhachHang KhachHang { get; set; }
        [ForeignKey("MaNV")]
        public virtual NhanVien NhanVien { get; set; }
        [ForeignKey("MaGT")]
        public virtual GoiTap GoiTap { get; set; }
    }
}
