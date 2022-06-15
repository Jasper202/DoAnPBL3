using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnPBL3.DTO;

namespace DoAnPBL3.BLL
{
    public class TaiKhoanBLL
    {
        QLGym db = new QLGym();
        private static TaiKhoanBLL _Instance;
        public static TaiKhoanBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new TaiKhoanBLL();
                }
                return _Instance;

            }
        }
        //check tk
        public bool checkTK(string TenDN, string Mk)
        {
            var c = db.TaiKhoans.Where(x => x.TenDN == TenDN && x.MatKhau == Mk).FirstOrDefault();
            if (c != null)
                return true;
            else return false;

        }
        public bool checkTenDN(string TenDN)
        {
            var c = db.TaiKhoans.Where(x => x.TenDN == TenDN).FirstOrDefault();
            if (c != null)
                return true;
            else return false;
        }
        //check phân quyền
        public bool checkPQ(string TenDN, string Mk)
        {
            var c = from TaiKhoan in db.TaiKhoans
                    where TaiKhoan.TenDN == TenDN && TaiKhoan.MatKhau == Mk
                    select TaiKhoan.Quyen;
            if (c.First() == 1)
            {
                return true;
            }    
            else return false;
        }
        public void addTK(TaiKhoan t)
        {
            db.TaiKhoans.Add(t);
            db.SaveChanges();

        }
        public void changeMaTk(string maNV)
        {
            var c = db.NhanViens.Where(p => p.MaNV == maNV).FirstOrDefault();
            
            if (NhanVienBLL.Instance.Check(maNV))
            {
                c.MaTK = db.TaiKhoans.Count().ToString();
                db.SaveChanges();
            }    
        }
    }
}
