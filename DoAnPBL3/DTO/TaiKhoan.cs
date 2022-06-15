using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnPBL3.DTO
{
    [Table("TaiKhoan")]
    public class TaiKhoan
    {
        public TaiKhoan()
        {
            this.NhanViens = new HashSet<NhanVien>();
        }
        [Key]
        public string MaTK { get; set; }
        public string TenDN { get; set; }
        public string MatKhau { get; set; }
        public int Quyen { get; set; }
        public string TenChucVu { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }

    }
}
