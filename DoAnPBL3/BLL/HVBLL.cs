using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoAnPBL3.DTO;

namespace DoAnPBL3.BLL
{
    internal class HVBLL
    {
        QLGym db = new QLGym();
        private static HVBLL _Instance;
        public static HVBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new HVBLL();
                }
                return _Instance;

            }
        }
        private HVBLL()
        {
        }
        public List<HV_View> GetAllHVView()
        {
            List<HV_View> list = new List<HV_View>();
            
            foreach (KhachHang j in KhachHangBLL.Instance.GetAllKH())
            {
                foreach (TheHV i in db.TheHVs.Select(p => p))
                {
                    if (i.MaKH == j.MaKH)
                    {
                        try
                        {
                            list.Add(new HV_View
                            {
                                MaHV = i.MaHV,
                                TenHV = j.TenKH,
                                GioiTinh = j.GioiTinh,
                                SDT = j.SDT,
                                GoiTap = i.GoiTap.TenGT,
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
        public List<HV_View> GetHVViewByName(string txt)
        {
            List<HV_View> list = new List<HV_View>();
            foreach (HV_View i in GetAllHVView())
            {
                if (i.TenHV.ToLower().Contains(txt.ToLower()))
                {
                    list.Add(i);
                }
            }
            return list;
        }
        public bool CheckMaKH(string MaKH)
        {
            foreach (TheHV i in db.TheHVs.Select(p => p))
            {
                if (i.MaKH == MaKH)
                    return true;
            }
            return false;
        }
        public bool CheckMaHV(string MaHV)
        {
            foreach (TheHV i in db.TheHVs.Select(p => p))
            {
                if (i.MaHV == MaHV)
                    return true;
            }
            return false;
        }
        public void AddHVKH(TheHV s, KhachHang i)
        {
            db.KhachHangs.Add(i);
            db.TheHVs.Add(s);
            db.SaveChanges();
        }
        public void AddHV(TheHV s)
        {
            db.TheHVs.Add(s);
            db.SaveChanges();
        }
        public TheHV GetHVByMaHV(string MaHV)
        {
            foreach (TheHV i in db.TheHVs.Select(p => p))
            {
                if (i.MaHV == MaHV)
                {
                    return new TheHV
                    {
                        MaHV = i.MaHV,
                        NgayDK = i.NgayDK,
                        NgayKT = i.NgayKT,
                        MaGT = i.MaGT,
                        MaKH = i.MaKH,
                        MaNV = i.MaNV,
                        Tongtien = i.Tongtien,
                    };
                }
            }
            return null;
        }
        public TheHV GetHVByMaKH(string MaKH)
        {
            foreach (TheHV i in db.TheHVs.Select(p => p))
            {
                if (i.MaKH == MaKH)
                {
                    return new TheHV
                    {
                        MaHV = i.MaHV,
                        NgayDK = i.NgayDK,
                        NgayKT = i.NgayKT,
                        MaGT = i.MaGT,
                        MaKH = i.MaKH,
                        MaNV = i.MaNV,
                        Tongtien = i.Tongtien,
                    };
                }
            }
            return null;
        }

        public void UpdateHV(TheHV i)
        {
            var c = db.TheHVs.Where(p => p.MaHV == i.MaHV).FirstOrDefault();
            if (c != null)
            {
                c.MaGT = i.MaGT;
                c.NgayDK = i.NgayDK;
                c.NgayKT = i.NgayKT;
                c.MaNV = i.MaNV;
                c.MaKH = i.MaKH;
                db.SaveChanges();
            }
        }
        public void AddUpdateHV(TheHV i, KhachHang s)
        {
            if (KhachHangBLL.Instance.Check(s.MaKH))
            {
                if (CheckMaHV(i.MaHV))
                {
                    UpdateHV(i);
                    //KhachHangBLL.Instance.UpdateKH(s);
                    db.SaveChanges();
                }
                else
                {
                    AddHV(i);
                }
            }
            else
            {
                if (CheckMaHV(i.MaHV))
                {
                    System.Windows.Forms.MessageBox.Show("Mã hội viên trùng");
                }
                else AddHVKH(i, s);
            }

        }
        public void DelHV(List<string> ListDel)
        {
            foreach (string s in ListDel)
            {
                if (s != "")
                {
                    //var c = db.LichSu_GHs.Where(p => p.MaHV == s).Select(p => p.MaLS);
                    //db.LichSu_GHs.Remove(db.LichSu_GHs.Find(c));
                    //db.SaveChanges();
                }
            }
            foreach (string s in ListDel)
            {
                if (s != "")
                {
                    db.TheHVs.Remove(db.TheHVs.Find(s));
                    db.SaveChanges();
                }
            }
        }
    }
}
