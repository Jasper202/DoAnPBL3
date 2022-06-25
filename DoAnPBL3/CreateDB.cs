using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnPBL3.DTO;

namespace DoAnPBL3
{
    public class CreateDB :
    //CreateDatabaseIfNotExists<QLGym>
    DropCreateDatabaseIfModelChanges<QLGym>
    //DropCreateDatabaseIfModelChanges<QLGym>
    //DropCreateDatabaseAlways<QLGym>
    {
        protected override void Seed(QLGym context)
        {
            context.TaiKhoans.AddRange(new TaiKhoan[]
            {
                new TaiKhoan{MaTK= "1", TenDN="Tay", MatKhau="123", Quyen= 1,TenChucVu="Quản Lý"},
                new TaiKhoan{MaTK= "2", TenDN="Nhat", MatKhau="123", Quyen= 0,TenChucVu="Lễ Tân"},
                new TaiKhoan{MaTK= "3", TenDN="Hieu", MatKhau="123", Quyen= 0,TenChucVu="Lễ Tân"},
                new TaiKhoan{MaTK= "4", TenDN="Trieu", MatKhau="123", Quyen= 0,TenChucVu="Thu Ngân"},
                new TaiKhoan{MaTK= "5", TenDN="Truong", MatKhau="123", Quyen= 0,TenChucVu="Bảo Vệ"},
                new TaiKhoan{MaTK= "6", TenDN="Vinh", MatKhau="123", Quyen= 0,TenChucVu="Tạp Vụ"},
                new TaiKhoan{MaTK= "7", TenDN="Phuc", MatKhau="123", Quyen= 0,TenChucVu="Marketing-Truyền Thông"}
            });
            context.NhanViens.AddRange(new NhanVien[]
            {
                new NhanVien { MaNV = "NV01", TenNV = "Tây", NgaySinh = new DateTime(2002, 9, 7), GioiTinh = true, DiaChi = "Quảng Nam", MaTK = "1", SDT = "0941638715", CCCD = "10220011231" },
                new NhanVien { MaNV = "NV02", TenNV = "Nhật", NgaySinh = new DateTime(2002, 6, 3), GioiTinh = false, DiaChi = "Đà Nẵng", MaTK = "2", SDT = "0941738716", CCCD = "10220011231" },
                new NhanVien { MaNV = "NV03", TenNV = "Hiệu", NgaySinh = new DateTime(2002, 4, 5), GioiTinh = true, DiaChi = "Tam Kỳ", MaTK = "3", SDT = "0941638717", CCCD = "10220011231" },
                new NhanVien { MaNV = "NV04", TenNV = "Triều", NgaySinh = new DateTime(2002, 3, 6), GioiTinh = true, DiaChi = "Quảng Ngãi", MaTK = "4", SDT = "0941658718", CCCD = "10220011231" },
                new NhanVien { MaNV = "NV05", TenNV = "Trường", NgaySinh = new DateTime(2002, 8, 2), GioiTinh = false, DiaChi = "Huế", MaTK = "5", SDT = "0941638219", CCCD = "10220011231" },
                new NhanVien { MaNV = "NV06", TenNV = "Vinh", NgaySinh = new DateTime(2002, 6, 9), GioiTinh = true, DiaChi = "Quảng Trị", MaTK = "6", SDT = "0941238711", CCCD = "10220011231" },
                new NhanVien { MaNV = "NV07", TenNV = "Phúc", NgaySinh = new DateTime(2002, 1, 7), GioiTinh = true, DiaChi = "Quảng Bình", MaTK = "7", SDT = "0941618712", CCCD = "10220011231" },
            });
            context.KhachHangs.AddRange(new KhachHang[]
            {
                new KhachHang { MaKH="KH01", TenKH="Tiến Đạt",NgaySinh=new DateTime(1999,3,9),GioiTinh=false,DiaChi="Quảng Nam",SDT="091135345",CCCD="123456789" },
                new KhachHang { MaKH="KH02", TenKH="Ngọc Đạt",NgaySinh=new DateTime(1998,4,8),GioiTinh=true,DiaChi="Đà Nẵng",SDT="09235345",CCCD="123532462" },
                new KhachHang { MaKH="KH03", TenKH="Tiên Sang",NgaySinh=new DateTime(1995,5,7),GioiTinh=false,DiaChi="Huế",SDT="094135345",CCCD="1532352462" },
                new KhachHang { MaKH="KH04", TenKH="Quang Nguyên",NgaySinh=new DateTime(1997,6,6),GioiTinh=false,DiaChi="Quảng Nam",SDT="092435345",CCCD="1237235462" },
                new KhachHang { MaKH="KH05", TenKH="Ngọc Đạt",NgaySinh=new DateTime(2002,7,5),GioiTinh=true,DiaChi="Huế",SDT="092415345",CCCD="123543462" },
                new KhachHang { MaKH="KH06", TenKH="Văn Phát",NgaySinh=new DateTime(1996,8,4),GioiTinh=false,DiaChi="Đà Nẵng",SDT="092435345",CCCD="17352352462" },
                new KhachHang { MaKH="KH07", TenKH="Hoàn Hảo",NgaySinh=new DateTime(1997,9,3),GioiTinh=false,DiaChi="Huế",SDT="092413345",CCCD="1235238462" },
                new KhachHang { MaKH="KH08", TenKH="Lê Như",NgaySinh=new DateTime(2000,10,2),GioiTinh=false,DiaChi="Đà Nẵng",SDT="0924135345",CCCD="1236352462" },
                new KhachHang { MaKH="KH09", TenKH="Thị Lợi",NgaySinh=new DateTime(2000,11,1),GioiTinh=false,DiaChi="Tam Kỳ",SDT="092135345",CCCD="1235222462" },
                new KhachHang { MaKH="KH10", TenKH="Phan Uyên",NgaySinh=new DateTime(1999,12,2),GioiTinh=true,DiaChi="Đà Nẵng",SDT="0924135345",CCCD="123235262" },
                new KhachHang { MaKH="KH11", TenKH="Đình Nam",NgaySinh=new DateTime(1998,1,3),GioiTinh=true,DiaChi="Quảng Nam",SDT="092135345",CCCD="1232352962" },
                new KhachHang { MaKH="KH12", TenKH="Công Huy",NgaySinh=new DateTime(2002,2,4),GioiTinh=false,DiaChi="Đà Nẵng",SDT="0924135345",CCCD="1235252462" },
                new KhachHang { MaKH="KH13", TenKH="Văn Viên",NgaySinh=new DateTime(2001,3,5),GioiTinh=true,DiaChi="Huế",SDT="092413534",CCCD="1232351462" },
                new KhachHang { MaKH="KH14", TenKH="Tuấn Kiệt",NgaySinh=new DateTime(1999,4,6),GioiTinh=false,DiaChi="Đà Nẵng",SDT="092135345",CCCD="1235295462" },
                new KhachHang { MaKH="KH15", TenKH="Văn Huy",NgaySinh=new DateTime(2000,5,7),GioiTinh=false,DiaChi="Tam Kỳ",SDT="094135345",CCCD="1235351462" }
            });
            context.SanPhams.AddRange(new SanPham[]
            {
                new SanPham{ MaSP="SP01",TenSP="Whey Protein",MaLH="LH01",DonGia=100000,SoLuongCon=70,NgayNhap=new DateTime(2022,3,5),HanSuDung=new DateTime(2023,8,7)},
                new SanPham{ MaSP="SP02",TenSP="BCAA",MaLH="LH02",DonGia=200000,SoLuongCon=80,NgayNhap=new DateTime(2022,7,5),HanSuDung=new DateTime(2023,3,7)},
                new SanPham{ MaSP="SP03",TenSP="Pre Workout",MaLH="LH03",DonGia=300000,SoLuongCon=60,NgayNhap=new DateTime(2022,2,4),HanSuDung=new DateTime(2024,2,3)},
                new SanPham{ MaSP="SP04",TenSP="Mass",MaLH="LH04",DonGia=400000,SoLuongCon=28,NgayNhap=new DateTime(2022,7,3),HanSuDung=new DateTime(2023,8,12)},
                new SanPham{ MaSP="SP05",TenSP="TNH",MaLH="LH05",DonGia=500000,SoLuongCon=35,NgayNhap=new DateTime(2022,8,5),HanSuDung=new DateTime(2023,7,11)},
                new SanPham{ MaSP="SP06",TenSP="Cali",MaLH="LH03",DonGia=700000,SoLuongCon=22,NgayNhap=new DateTime(2022,8,5),HanSuDung=new DateTime(2023,8,11)},
                new SanPham{ MaSP="SP07",TenSP="Bro",MaLH="LH04",DonGia=350000,SoLuongCon=20,NgayNhap=new DateTime(2022,8,5),HanSuDung=new DateTime(2023,9,11)},
            });
            context.LoaiHangs.AddRange(new LoaiHang[]
            {
                new LoaiHang{MaLH="LH01",TenLH="Tăng cơ",HangSX="ABC"},
                new LoaiHang{MaLH="LH02",TenLH="Sữa tăng cân",HangSX="BCD"},
                new LoaiHang{MaLH="LH03",TenLH="BS Vitamin",HangSX="DEF"},
                new LoaiHang{MaLH="LH04",TenLH="BS Omega3",HangSX="GHT"},
                new LoaiHang{MaLH="LH05",TenLH="Thực phẩm thay thế",HangSX="MKI"},
            });
            context.HoaDons.AddRange(new HoaDon[]
            {
                new HoaDon{MaHD="HD01",NgayBan=new DateTime(2022,5,7), MaNV="NV01",MaKH="KH03",TongHD=300000},
                new HoaDon{MaHD="HD02",NgayBan=new DateTime(2022,5,6),MaNV="NV04",MaKH="KH01",TongHD=100000},
                new HoaDon{MaHD="HD03",NgayBan=new DateTime(2022,5,3),MaNV="NV03",MaKH="KH04",TongHD=200000},
                new HoaDon{MaHD="HD04",NgayBan=new DateTime(2022,5,4),MaNV="NV02",MaKH="KH02",TongHD=300000},
                new HoaDon{MaHD="HD05",NgayBan=new DateTime(2022,5,2),MaNV="NV05",MaKH="KH05",TongHD=500000},
            });
            context.CTHDs.AddRange(new CTHD[]
                {
                    new CTHD{MaCTHD = "CT01", MaHD = "HD01", SoLuong = 1,NgayInHD=new DateTime(2022,6,8), MaSP = "SP03", Gia = 300000},
                    new CTHD{MaCTHD = "CT02", MaHD = "HD02", SoLuong = 2,NgayInHD=new DateTime(2022,6,7), MaSP = "SP01", Gia = 100000},
                    new CTHD{MaCTHD = "CT03", MaHD = "HD03", SoLuong = 3,NgayInHD=new DateTime(2022,6,6), MaSP = "SP02", Gia = 200000},
                    new CTHD{MaCTHD = "CT04", MaHD = "HD04", SoLuong = 4,NgayInHD=new DateTime(2022,6,5), MaSP = "SP01", Gia = 100000},
                    new CTHD{MaCTHD = "CT05", MaHD = "HD04", SoLuong = 2,NgayInHD=new DateTime(2022,6,4), MaSP = "SP02", Gia = 200000},
                    new CTHD{MaCTHD = "CT06", MaHD = "HD05", SoLuong = 3,NgayInHD=new DateTime(2022,6,3), MaSP = "SP04", Gia = 400000},
                    new CTHD{MaCTHD = "CT07", MaHD = "HD05", SoLuong = 5,NgayInHD=new DateTime(2022,6,2), MaSP = "SP01", Gia = 100000},
                });
            context.GoiTaps.AddRange(new GoiTap[]
                {
                    new GoiTap{MaGT = "GT01", TenGT = "Gói 1 tháng", ThoiHan = "1 Tháng", Gia = 300000},
                    new GoiTap{MaGT = "GT02", TenGT = "Gói 3 tháng", ThoiHan = "1 Tháng", Gia = 750000},
                    new GoiTap{MaGT = "GT03", TenGT = "Gói 6 tháng", ThoiHan = "1 Tháng", Gia = 1350000},
                    new GoiTap{MaGT = "GT04", TenGT = "Gói 9 tháng", ThoiHan = "1 Tháng", Gia = 1890000},
                    new GoiTap{MaGT = "GT05", TenGT = "Gói 12 tháng", ThoiHan = "1 Tháng", Gia = 2400000},


                });
            context.TheHVs.AddRange(new TheHV[]
            {
                new TheHV{MaHV = "HV01", NgayDK = new DateTime(2022,8,5), NgayKT = new DateTime(2022,11,5), MaGT = "GT02", MaKH ="KH02", MaNV= "NV01", Tongtien = 750000},
                new TheHV{MaHV = "HV02", NgayDK = new DateTime(2022,8,5), NgayKT = new DateTime(2022,2,5), MaGT = "GT03", MaKH ="KH03", MaNV= "NV01", Tongtien = 1350000},
                new TheHV{MaHV = "HV03", NgayDK = new DateTime(2022,1,5), NgayKT = new DateTime(2023,1,5), MaGT = "GT05", MaKH ="KH04", MaNV= "NV02", Tongtien = 2400000},
                new TheHV{MaHV = "HV04", NgayDK = new DateTime(2022,8,5), NgayKT = new DateTime(2022,11,5), MaGT = "GT02", MaKH ="KH05", MaNV= "NV03", Tongtien = 750000},
                new TheHV{MaHV = "HV05", NgayDK = new DateTime(2022,8,5), NgayKT = new DateTime(2022,2,5), MaGT = "GT02", MaKH ="KH06", MaNV= "NV01", Tongtien = 1500000},

            });
            context.LichSu_GHs.AddRange(new LichSu_GH[]
            {
                new LichSu_GH { MaLS ="LS01", MaHV = "HV01", NgayGH = new DateTime(2022,8,5), ThoigianGH = "3 tháng", MaNV = "NV01", Gia = 750000},
                new LichSu_GH { MaLS ="LS02", MaHV = "HV02", NgayGH = new DateTime(2022,8,5), ThoigianGH = "6 tháng", MaNV = "NV01", Gia = 1350000},
                new LichSu_GH { MaLS ="LS03", MaHV = "HV03", NgayGH = new DateTime(2022,1,5), ThoigianGH = "12 tháng", MaNV = "NV02", Gia = 2400000},
                new LichSu_GH { MaLS ="LS04", MaHV = "HV04", NgayGH = new DateTime(2022,8,5), ThoigianGH = "3 tháng", MaNV = "NV03", Gia = 750000},
                new LichSu_GH { MaLS ="LS05", MaHV = "HV05", NgayGH = new DateTime(2022,8,5), ThoigianGH = "3 tháng", MaNV = "NV01", Gia = 750000},
                new LichSu_GH { MaLS ="LS06", MaHV = "HV05", NgayGH = DateTime.Now, ThoigianGH = "3 tháng", MaNV = "NV01", Gia = 750000},
            });

        }
    }
}
