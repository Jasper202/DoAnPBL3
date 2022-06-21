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
            KhachHang s = KhachHangBLL.Instance.GetKHByMaKH(MaKH);
            txtThemMaKH.Enabled = false;
            txtThemMaKH.Text = s.MaKH;
            txtThemTenKH.Text = s.TenKH;          
            if (s.GioiTinh)
            {
                rdoKHNam.Checked = true;
            }
            else
            {
                rdoKHNu.Checked = true;
            }
            txtThemSDTKH.Text = s.SDT;
            txtThemDiaChiKH.Text = s.DiaChi;
            dateNSKH.Value = s.NgaySinh;
            txtCCCD.Text = s.CCCD;          
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
             KhachHang s = new KhachHang
             {       
                MaKH = txtThemMaKH.Text,
                TenKH = txtThemTenKH.Text,
                //GioiTinh = rdoNVNam.Checked,
                NgaySinh = dateNSKH.Value.Date,
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