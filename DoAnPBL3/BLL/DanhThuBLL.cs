using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnPBL3.DTO;

namespace DoAnPBL3.BLL
{
    public class DanhThuBLL
    {
        QLGym db = new QLGym();
        private static DanhThuBLL _Instance;
        public static DanhThuBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DanhThuBLL();
                }
                return _Instance;

            }
        }
        private DanhThuBLL()
        {
        }
        public List<CTHD_View> GetHDViewByDate(DateTime bd,DateTime kt)
        {
            List<CTHD_View> list = new List<CTHD_View>();
            foreach(CTHD i in db.CTHDs.Select(p=>p))
            {
                if(i.NgayInHD >= bd && i.NgayInHD <=kt)
                {
                    list.Add(new CTHD_View
                    {
                        MaCTHD = i.MaCTHD,
                        MaSP = i.MaSP,
                        TenSP = i.SanPham.TenSP,
                        SoLuong = i.SoLuong,
                        DonGia = i.Gia,
                        NgayInHD = i.NgayInHD,
                        MaKH = i.HoaDon.MaKH,
                        TenKH = i.HoaDon.KhachHang.TenKH,
                        MaNV = i.HoaDon.MaNV,
                        DanhSo = (i.SoLuong * i.Gia)
                    });
                }    
            }

            return list;
        }
        public List<CBBItem2> GetCBBMaHD()
        {
            List<CBBItem2> list = new List<CBBItem2>();
            foreach(HoaDon i in db.HoaDons.Select(p=>p))
            {
                list.Add(new CBBItem2
                {
                    Value = i.MaHD,
                    Text = i.MaHD,
                });
            }
            return list;
        }
        public List<CBBItem2> GetCBBKH()
        {
            List<CBBItem2> list = new List<CBBItem2>();
            foreach (KhachHang i in db.KhachHangs.Select(p => p))
            {
                list.Add(new CBBItem2
                {
                    Value = i.MaKH,
                    Text = i.MaKH,
                });
            }
            return list;
        }
        public List<CBBItem2> GetCBBNV()
        {
            List<CBBItem2> list = new List<CBBItem2>();
            foreach (NhanVien i in db.NhanViens.Select(p => p))
            {
                list.Add(new CBBItem2
                {
                    Value = i.MaNV,
                    Text = i.MaNV
                });
            }
            return list;
        }
        public List<CBBItem2> GetCBBSanPham()
        {
            List<CBBItem2> list = new List<CBBItem2>();
            foreach (SanPham i in db.SanPhams.Select(p => p))
            {
                list.Add(new CBBItem2
                {
                    Value=i.MaSP,
                    Text = i.TenSP,
                });
            }
            return list;
        }
        public List<HoaDon_View> GetHDView()
        {
            List<HoaDon_View> list = new List<HoaDon_View>();
            foreach(HoaDon i in db.HoaDons.Select(p=>p))
            {
                list.Add(new HoaDon_View
                {
                    MaHD = i.MaHD,
                    NgayBan = i.NgayBan,
                    TenNV = i.NhanVien.TenNV,
                    TenKH = i.KhachHang.TenKH,
                    TongHD = i.TongHD,
                });
            }
            return list;
        }
        public HoaDon_View GetHDViewBySearch(string MaHD)
        {         
            foreach (HoaDon_View i in GetHDView())
            {
                if (i.MaHD == MaHD)
                {
                    return i;
                }
            }
            return null;
        }
        public void AddHD(HoaDon s)
        {
            db.HoaDons.Add(s);
            db.SaveChanges();
        }
        //public void DellHD(List<string> listDel)
        //{
        //    foreach (string s in listDel)
        //    {
        //        if(s !=null)
        //        {
        //            db.HoaDons.Remove(db.HoaDons.Find(s));
        //            db.SaveChanges();
        //        }    
        //    }    
        //}
    }
}
