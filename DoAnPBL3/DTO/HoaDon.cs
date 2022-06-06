using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnPBL3.DTO
{
    [Table("HoaDon")]
    public class HoaDon
    {
        public HoaDon()
        {
            this.CTHDs = new HashSet<CTHD>();
        }

        [Key]
        [StringLength(9)]
        [Required]
        public string MaHD { get; set; }
        public DateTime NgayHD { get; set; }
        [StringLength(9)]
        public string MaNV { get; set; }
        

        [StringLength(9)]
        public string MaKH { get; set; }
        
        public double TongHD { get; set; }
        [ForeignKey("MaKH")]
        public virtual KhachHang KhachHang { get; set; }
        [ForeignKey("MaNV")]
        public virtual NhanVien NhanVien { get; set; }
        public ICollection<CTHD> CTHDs { get; set; }
    }
}
