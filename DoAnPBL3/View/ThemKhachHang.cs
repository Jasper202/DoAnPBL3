using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnPBL3.DTO;
using DoAnPBL3.BLL;

namespace DoAnPBL3
{
    public partial class ThemKhachHang : Form
    {
        public delegate void MyDel(string txt);
        public MyDel d1 { get; set; }

        private string MaKH { get; set; }
        public ThemKhachHang(string m)
        {
            MaKH = m;
            InitializeComponent();         
            GUI();

        }    
        public void GUI()
        {
            if (MaKH == "") return;
            //NhanVien s = NhanVienBLL.Instance.GetNVByMaNV(MaNV);
            //txtMaNV.Enabled = false;
            //txtMaNV.Text = s.MaNV;
            //txtTenNV.Text = s.TenNV;
            //if (s.GioiTinh)
            //{
            //    rdoNVNam.Checked = true;
            //}
            //else
            //{
            //    rdoNVNam.Checked = false;
            //}
            //txtSDTNV.Text = s.SDT;
            //txtDiachiNV.Text = s.DiaChi;
            //NgaySinhNV.Value = s.NgaySinh;
            //txtSoCCCNV.Text = s.CCCD;
            //foreach (CBBItem i in cbbVTNV.Items)
            //{
            //    if (i.Value == NhanVienBLL.Instance.GetMaTKPByMaNV(s.MaNV))
            //    {
            //        cbbVTNV.SelectedItem = i;
            //        break;
            //    }
            //}
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
             KhachHang s = new KhachHang
             {       
                MaKH = txtThemMaKH.Text,
                TenKH = txtThemTenKH.Text,
                //GioiTinh = rdoNVNam.Checked,
                NgaySinh = dateNS.Value.Date,
                DiaChi = txtThemDiaChiKH.Text,
                SDT = txtThemSDTKH.Text,
                CCCD = txtCCCD.Text,              
            };
            KhachHangBLL.Instance.AddUpdateKH(s);
            d1("");
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}