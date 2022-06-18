using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnPBL3.DTO;

namespace DoAnPBL3.BLL
{
    public class SanPhamBLL
    {
        QLGym db = new QLGym();
        private static SanPhamBLL _Instance;
        public static SanPhamBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SanPhamBLL();
                }
                return _Instance;

            }
        }
        public List<CBBItem2> GetCBBLoaiSP()
        {
            List<CBBItem2> list = new List<CBBItem2>();

            
            foreach (LoaiHang i in db.LoaiHangs.Select(p => p))
            {
                
                list.Add(new CBBItem2
                {
                    Value = i.MaLH,
                    Text = i.TenLH.ToString()

                });

            }
            return list;
        }
        public List<SanPham_View> GetAllSPView()
        {
            List<SanPham_View> list = new List<SanPham_View>();
            foreach (SanPham i in db.SanPhams.Select(p => p))
            {
                list.Add(new SanPham_View
                {
                    MaSP = i.MaSP,
                    TenSP = i.TenSP,
                    LoaiSP = i.LoaiHang.TenLH,
                    SoLuong = i.SoLuongCon,
                    NgayNhap = i.NgayNhap,
                    DonGia = i.DonGia,
                    HangSX = i.LoaiHang.HangSX
                });
            }
            return list;
        }
        public List<SanPham_View> GetSPViewByName(string txt)
        {
            List<SanPham_View> list = new List<SanPham_View>();
            foreach (SanPham_View i in GetAllSPView())
            {
                if (i.TenSP.ToLower().Contains(txt.ToLower()))
                {
                    list.Add(i);
                }
            }
            return list;
        }
        public bool Check(string MaSP)
        {
            foreach (SanPham i in db.SanPhams.Select(p => p))
            {
                if (i.MaSP == MaSP)
                    return true;
            }
            return false;
        }
        public void AddSP(SanPham s)
        {
            db.SanPhams.Add(s);
            db.SaveChanges();
        }
        public void UpdateSP(SanPham s)
        {
            var c = db.SanPhams.Where(p => p.MaSP == s.MaSP).FirstOrDefault();
            if (c != null)
            {
                c.MaSP = s.MaSP;
                c.TenSP = s.TenSP;
                c.MaLH = s.MaLH;
                c.DonGia = s.DonGia;
                c.SoLuongCon = s.SoLuongCon;
                c.NgayNhap = s.NgayNhap;
                c.HanSuDung = s.HanSuDung;
                db.SaveChanges();
            }
        }
        public void AddUpdate(SanPham s)
        {
            if (Check(s.MaSP))
            {
                UpdateSP(s);
            }
            else
            {
                AddSP(s);
            }
        }
        public void DelSP(List<string> ListDel)
        {
            foreach (string s in ListDel)
            {
                if (s != "")
                {
                    db.SanPhams.Remove(db.SanPhams.Find(s));
                    db.SaveChanges();
                }
            }
        }
        public SanPham GetSPByMaSP(string MaSP)
        {
            foreach (SanPham i in db.SanPhams.Select(p => p))
            {
                if (i.MaSP == MaSP)
                {
                    return new SanPham
                    {
                        MaSP = i.MaSP,
                        TenSP = i.TenSP,
                        LoaiHang = i.LoaiHang,
                        DonGia = i.DonGia,
                        NgayNhap = i.NgayNhap,
                        HanSuDung = i.HanSuDung,
                        SoLuongCon = i.SoLuongCon
                    };
                }
            }
            return null;
        }
        public string GetMaLHPByMaSP(string MaSP)
        {
            foreach (SanPham i in db.SanPhams.Select(p => p))
            {
                if (i.MaSP == MaSP)
                {
                    return i.MaLH;
                }
            }
            return "";
        }
    }
}
