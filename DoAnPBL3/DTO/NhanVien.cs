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
        [Key][StringLength(9)][Required]
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string DiaChi { get; set; }
        [Required]
        public string MaTK { get; set; }
        public string SDT { get; set; }
        [ForeignKey("MaTK")]
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
