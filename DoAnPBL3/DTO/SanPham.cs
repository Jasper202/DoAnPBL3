using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnPBL3.DTO
{
    [Table("SanPham")]
    public class SanPham
    {
        public SanPham()
        {
            this.CTHDs = new HashSet<CTHD>();
        }
        
        [Key]
        [StringLength(9)]
        [Required]
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        [StringLength(9)]
        public string MaLH { get; set; }
       
        public double DonGia { get; set; }
        public int SoLuongCon { get; set; }
        public DateTime NgayNhap { get; set; }
        public DateTime HanSuDung { get; set; }
        public string TinhTrang { get; set; }
        [ForeignKey("MaLH")]
        public virtual LoaiHang LoaiHang { get; set; }
        public virtual ICollection<CTHD> CTHDs { get; set; }
    }
}
