using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnPBL3.DTO;

namespace DoAnPBL3.BLL
{
    public class NhanVienBLL
    {
        QLGym db = new QLGym();
        private static NhanVienBLL _Instance;
        public static NhanVienBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new NhanVienBLL();
                }
                return _Instance;

            }
        }
        private NhanVienBLL()
        {
        }
        public List<CBBItem> GetCBBChucVu()
        {
            List<CBBItem> list = new List<CBBItem>();

            foreach(TaiKhoan i in db.TaiKhoans.Select(p => p))
            {
                list.Add(new CBBItem
                {
                    Value = Convert.ToInt32(i.MaTK),
                    Text = i.TenChucVu.ToString()
                   
                });
                
            }
            return list;
        }
        public List<NhanVien_View> GetAllNVView()
        {
            List<NhanVien_View> list = new List<NhanVien_View>();   
            foreach(NhanVien i in db.NhanViens.Select(p=>p))
            {              
                list.Add(new NhanVien_View
                {
                    MaNV = i.MaNV,
                    TenNV = i.TenNV,
                    GioiTinh = i.GioiTinh,
                    SDT = i.SDT,
                    NgaySinh = i.NgaySinh,
                    CCCD = i.CCCD,
                    ChucVu = i.TaiKhoan.TenChucVu
                });
            }    
            return list;
        }
        public List<NhanVien_View> GetNVViewBySearch(string txt)
        {
            List<NhanVien_View> list = new List<NhanVien_View>();
            foreach (NhanVien_View i in GetAllNVView())
            {
                if(i.TenNV.Contains(txt))
                {
                    list.Add(i);
                }    
            }
            return list;
        }
        public bool Check(string MaNV)
        {
            foreach(NhanVien i in db.NhanViens.Select(p=>p))
            {
                if(i.MaNV == MaNV)
                    return true;
            }    
            return false;
        }
        public void AddNV(NhanVien s)
        {
            db.NhanViens.Add(s);
            db.SaveChanges();
        }
        public void UpdateNV(NhanVien s) 
        {
            var c = db.NhanViens.Where(p => p.MaNV == s.MaNV).FirstOrDefault();
            if (c != null)
            {
                c.TenNV = s.TenNV;
                c.NgaySinh = s.NgaySinh;
                c.GioiTinh = s.GioiTinh;
                c.DiaChi = s.DiaChi;
                c.MaTK = s.MaTK;
                c.SDT = s.SDT;
                c.CCCD = s.CCCD;
                db.SaveChanges();
            }
        }
        public void AddUpdate(NhanVien s)
        {
            if(Check(s.MaNV))
            {
                UpdateNV(s);
            }
            else
            {
                AddNV(s);
            }
        }
        public void DelNV(List<string> ListDel)
        {
            foreach (string s in ListDel)
            {
                if (s != "")
                {
                    db.NhanViens.Remove(db.NhanViens.Find(s));
                    db.SaveChanges();
                }
            }
        }       
        public NhanVien GetNVByMaNV(string MaNV)
        {
            foreach (NhanVien i in db.NhanViens.Select(p => p))
            {
                if (i.MaNV == MaNV)
                {
                    return new NhanVien
                    {
                        MaNV = i.MaNV,
                        TenNV = i.TenNV,
                        NgaySinh = i.NgaySinh,
                        GioiTinh = i.GioiTinh,
                        DiaChi = i.DiaChi,
                        SDT = i.SDT,
                        CCCD = i.CCCD,
                        MaTK = i.MaTK,
                    };
                }
            }
            return null;
        }
        public int GetMaTKPByMaNV(string MaNV)
        {
            foreach (NhanVien i in db.NhanViens.Select(p => p))
            {
                if (i.MaNV == MaNV)
                {
                    return Convert.ToInt32(i.MaTK);
                }
            }
            return 0;
        }
        
    }
}
