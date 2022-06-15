using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnPBL3.DTO
{
    public class NhanVien_View
    {
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public bool GioiTinh { get; set; }          
        public string SDT { get; set; }
        public DateTime NgaySinh { get; set; }
        public string CCCD { get; set; }
        public string ChucVu { get; set; }

    }
}
