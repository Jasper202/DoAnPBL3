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
    public partial class ThemNhanVien : Form
    {
        public delegate void MyDel(string txt);
        public MyDel d { get; set; }

        private string MaNV { get; set; }
        public ThemNhanVien(string m)
        {
            MaNV = m;
            InitializeComponent();
            SetCBBChucVu();
            GUI();

        }
        public void SetCBBChucVu()
        {
            cbbVTNV.Items.AddRange(NhanVienBLL.Instance.GetCBBChucVu().ToArray());
        }   
        public void GUI()
        {
            if (MaNV == "") return;
            NhanVien s = NhanVienBLL.Instance.GetNVByMaNV(MaNV);
            txtMaNV.Enabled = false;
            txtMaNV.Text = s.MaNV;
            txtTenNV.Text = s.TenNV;
            if(s.GioiTinh)
            {
                rdoNVNam.Checked = true;
            }    
            else
            {
                rdoNVNam.Checked = false;
            }    
            txtSDTNV.Text = s.SDT;
            txtDiachiNV.Text = s.DiaChi;
            NgaySinhNV.Value = s.NgaySinh;
            txtSoCCCNV.Text = s.CCCD;
            foreach (CBBItem i in cbbVTNV.Items)
            {
                if (i.Value == NhanVienBLL.Instance.GetMaTKPByMaNV(s.MaNV))
                {
                    cbbVTNV.SelectedItem = i;
                    break;
                }
            }
        }

        private void btnLuuNV_Click_1(object sender, EventArgs e)
        {
            NhanVien s = new NhanVien
            {
                MaNV = txtMaNV.Text,
                TenNV = txtTenNV.Text,
                GioiTinh = rdoNVNam.Checked,
                NgaySinh = NgaySinhNV.Value.Date,
                DiaChi = txtDiachiNV.Text,
                SDT = txtSDTNV.Text,
                CCCD = txtSoCCCNV.Text,
                MaTK = (((CBBItem)cbbVTNV.SelectedItem).Value).ToString(),
            };
            NhanVienBLL.Instance.AddUpdate(s);
            d("");
            this.Dispose();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

