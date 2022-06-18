using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnPBL3.DTO;
namespace DoAnPBL3.BLL
{
    public class KhachHangBLL
    {
        QLGym db = new QLGym();
        private static KhachHangBLL _Instance;
        public static KhachHangBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new KhachHangBLL();
                }
                return _Instance;

            }
        }
        private KhachHangBLL()
        {
        }      
        public List<KhachHang_View> GetAllKHView()
        {
            List<KhachHang_View> list = new List<KhachHang_View>();
            foreach (KhachHang i in db.KhachHangs.Select(p => p))
            {
                list.Add(new KhachHang_View
                {
                    MaKH = i.MaKH,
                    TenKH = i.TenKH,
                    DiaChi = i.DiaChi,
                    SDT = i.SDT,
                    NgaySinh = i.NgaySinh,                 
                });
            }
            return list;
        }
        public List<KhachHang_View> GetKHViewBySearch(string txt)
        {
            List<KhachHang_View> list = new List<KhachHang_View>();
            foreach (KhachHang_View i in GetAllKHView())
            {
                if (i.TenKH.Contains(txt))
                {
                    list.Add(i);
                }
            }
            return list;
        }
        public bool Check(string MaKH)
        {
            foreach (KhachHang i in db.KhachHangs.Select(p => p))
            {
                if (i.MaKH == MaKH)
                    return true;
            }
            return false;
        }
        public void AddKH(KhachHang s)
        {
            db.KhachHangs.Add(s);
            db.SaveChanges();
        }
        public void UpdateKH(KhachHang s)
        {
            var c = db.KhachHangs.Where(p => p.MaKH == s.MaKH).FirstOrDefault();
            if (c != null)
            {
                c.TenKH = s.TenKH;
                c.NgaySinh = s.NgaySinh;
                c.GioiTinh = s.GioiTinh;
                c.DiaChi = s.DiaChi;             
                c.SDT = s.SDT;
                c.CCCD = s.CCCD;
                db.SaveChanges();
            }
        }
        public void AddUpdateKH(KhachHang s)
        {
            if (Check(s.MaKH))
            {
                UpdateKH(s);
            }
            else
            {
                AddKH(s);
            }
        }
        public void DelKH(List<string> ListDel)
        {
            foreach (string s in ListDel)
            {
                if (s != "")
                {
                    db.KhachHangs.Remove(db.KhachHangs.Find(s));
                    db.SaveChanges();
                }
            }
        }
    }
}
