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
    }
  
}