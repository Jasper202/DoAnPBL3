using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnPBL3.DTO
{
    public class SanPham_View
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string LoaiSP { get; set; }
        public int SoLuong { get; set; }
        public Double DonGia { get; set; }
        public DateTime NgayNhap { get; set; }
        public string HangSX { get; set; }

    }
}
