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
    {
        protected override void Seed(QLGym context)
        {
            context.TaiKhoans.AddRange(new TaiKhoan[]
            {
                new TaiKhoan{MaTK= "TK01", TenDN="Tay", MatKhau="123", Quyen= 1},
                new TaiKhoan{MaTK= "TK02", TenDN="Nhat", MatKhau="456", Quyen= 0},
                new TaiKhoan{MaTK= "TK03", TenDN="Hieu", MatKhau="789", Quyen= 0},

            });
            context.NhanViens.AddRange(new NhanVien[]
            {
                new NhanVien{MaNV= "NV01",TenNV="Tây",NgaySinh= DateTime.Now, GioiTinh=true, DiaChi="Quang Nam", MaTK="TK01",SDT="0941638715",  },
                new NhanVien{MaNV= "NV02",TenNV="Nhật",NgaySinh= DateTime.Now, GioiTinh=false, DiaChi="Da Nang", MaTK="TK02", SDT="0941638716",},
                new NhanVien{MaNV= "NV03",TenNV="Hiệu",NgaySinh= DateTime.Now, GioiTinh=true, DiaChi="Tam Ky", MaTK="TK03", SDT="0941638717" },
            });

        }
    }
}
