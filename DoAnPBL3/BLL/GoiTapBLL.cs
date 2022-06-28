using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnPBL3.DTO;

namespace DoAnPBL3.BLL
{
    public class GoiTapBLL
    {
        QLGym db = new QLGym();
        private static GoiTapBLL _Instance;
        public static GoiTapBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new GoiTapBLL();
                }
                return _Instance;

            }
        }
        private GoiTapBLL()
        {
        }
        public List<GoiTap_View> GetAllGTView()
        {
            List<GoiTap_View> list = new List<GoiTap_View>();

            foreach (KhachHang j in KhachHangBLL.Instance.GetAllKH())
            {
                foreach (TheHV i in db.TheHVs.Select(p => p))
                {
                    if (i.MaKH == j.MaKH)
                    {
                        try
                        {
                            list.Add(new GoiTap_View
                            {
                                MaHV = i.MaHV,
                                TenHV = j.TenKH,
                                SDT = j.SDT,
                                GoiTap = i.GoiTap.TenGT,
                                NgayDK = i.NgayDK,
                                NgayKT = i.NgayKT,
                            });
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message);
                        }
                    }

                }

            }

            return list;
        }
        public List<GoiTap_View> GetGTViewByMaGT(string txt)
        {
            List<GoiTap_View> list = new List<GoiTap_View>();
            foreach (GoiTap_View i in GetAllGTView())
            {
                if (i.MaHV.Contains(txt))
                {
                    list.Add(i);
                }
            }
            return list;
        }
        public List<CBBItem2> GetCBBGoiTap()
        {
            List<CBBItem2> list = new List<CBBItem2>();

            foreach (GoiTap i in db.GoiTaps.Select(p => p))
            {
                list.Add(new CBBItem2
                {
                    Value = i.MaGT,
                    Text = i.TenGT.ToString()

                });

            }
            return list;
        }
        public void addLSGH(LichSu_GH s)
        {
            db.LichSu_GHs.Add(s);
            db.SaveChanges();
        }
        public bool checkMaLS(string maLS)
        {
            foreach (LichSu_GH i in db.LichSu_GHs.Select(p => p))
            {
                if (i.MaLS == maLS)
                    return false;
            }
            return true;
        }
        public double getGia(string ma)
        {
            foreach (GoiTap i in db.GoiTaps.Select(p => p))
            {
                if (i.MaGT == ma)
                {
                    return i.Gia;
                }
            }
            return 0;
        }
        public int getThang(string ma)
        {
            int i = 0;
            if (ma == "GT01")
            {
                i = 1;
            }
            if (ma == "GT02")
            {
                i = 3;
            }
            if (ma == "GT03")
            {
                i = 6;
            }
            if (ma == "GT04")
            {
                i = 9;
            }
            if (ma == "GT05")
            {
                i = 12;
            }
            return i;
        }
        public void GiaHan(TheHV s, int x)
        {
            var c = db.TheHVs.Where(p => p.MaHV == s.MaHV).FirstOrDefault();
            if (c != null)
            {
                if (x == 0)
                {
                    c.NgayKT = c.NgayKT.AddMonths(1);
                    c.Tongtien += 300000;
                    c.MaGT = "GT01";
                    db.SaveChanges();
                }
                else
                if (x == 1)
                {
                    c.NgayKT = c.NgayKT.AddMonths(3);
                    c.Tongtien += 750000;
                    c.MaGT = "GT02";
                    db.SaveChanges();
                }
                else
                if (x == 2)
                {
                    c.NgayKT = c.NgayKT.AddMonths(6);
                    c.Tongtien += 1350000;
                    c.MaGT = "GT03";
                    db.SaveChanges();
                }
                else
                if (x == 3)
                {
                    c.NgayKT = c.NgayKT.AddMonths(9);
                    c.Tongtien += 1890000;
                    c.MaGT = "GT04";
                    db.SaveChanges();
                }
                else
                if (x == 4)
                {
                    c.NgayKT = c.NgayKT.AddMonths(12);
                    c.Tongtien += 2400000;
                    c.MaGT = "GT05";
                    db.SaveChanges();
                }

            }
        }
    }
}
