using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnPBL3.DTO;

namespace DoAnPBL3
{
    public class CreateDB:
        CreateDatabaseIfNotExists<QLGym>
        //DropCreateDatabaseIfModelChanges<QLGym>
        //DropCreateDatabaseAlways<QLGym>
    {
        protected override void Seed(QLGym context)
        {
            context.TaiKhoans.AddRange(new TaiKhoan[]
            {
                new TaiKhoan{MaTK= "TK001", TenDN="Tay", MatKhau="123", Quyen= 1},
                new TaiKhoan{MaTK= "TK002", TenDN="Nhat", MatKhau="456", Quyen= 0},
                new TaiKhoan{MaTK= "TK003", TenDN="Hieu", MatKhau="789", Quyen= 0},

            });
            context.NhanViens.AddRange(new NhanVien[]
            {
                new NhanVien{MaNV= "NV001",TenNV="Tây",NgaySinh= DateTime.Now, GioiTinh=true, DiaChi="Quang Nam", MaTK="TK001",SDT="0941638715",Chucvu="Quanli", CCCD = "10220011231"  },
                new NhanVien{MaNV= "NV002",TenNV="Nhật",NgaySinh= DateTime.Now, GioiTinh=false, DiaChi="Da Nang", MaTK="TK002", SDT="0941638716",Chucvu="Quanli", CCCD = "10220011231"},
                new NhanVien{MaNV= "NV003",TenNV="Hiệu",NgaySinh= DateTime.Now, GioiTinh=true, DiaChi="Tam Ky", MaTK="TK003", SDT="0941638717", Chucvu="Quanli", CCCD = "10220011231" },
            });

        }
    }
}
