using System;
using System.Data.Entity;
using System.Linq;
using DoAnPBL3.DTO;

namespace DoAnPBL3
{
    public class QLGym : DbContext
    {     
        public QLGym()
            : base("name=QLGym")
        {
            Database.SetInitializer<QLGym>(new CreateDB());
        }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<CTHD> CTHDs { get; set; }
        public virtual DbSet<GoiTap> GoiTaps { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LichSu_GH> LichSu_GHs { get; set; }
        public virtual DbSet<LoaiHang> LoaiHangs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<TheHV> TheHVs { get; set; }
    }
  
}