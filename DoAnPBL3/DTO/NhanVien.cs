using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnPBL3.DTO
{
    [Table("NhanVien")]
    public class NhanVien
    {
        public NhanVien()
        {
            this.HoaDons = new HashSet<HoaDon>();
            this.TheHVs = new HashSet<TheHV>();
            this.LichSu_GHs = new HashSet<LichSu_GH>();
        }
        

        [Key][StringLength(9)][Required]
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string DiaChi { get; set; }
        [StringLength(9)]
        public string MaTK { get; set; }
        public string SDT { get; set; }
       
        public string Chucvu { get; set; }
        public string CCCD { get; set; }
        [ForeignKey("MaTK")]
        public virtual TaiKhoan TaiKhoan { get; set; }
        public virtual ICollection<LichSu_GH> LichSu_GHs { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
        public virtual ICollection<TheHV> TheHVs { get; set; }
    }
}
