using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnPBL3.BLL;
using DoAnPBL3.DTO;

namespace DoAnPBL3
{
    public partial class ThemSanPham : Form
    {
        public delegate void MyDel(string txt);
        public MyDel d { get; set; }

        private string MaSP { get; set; }
        public ThemSanPham(string masp)
        {
            MaSP = masp;
            InitializeComponent();
            SetCBBLoaiSP();
            GUI();
        }
        public void SetCBBLoaiSP()
        {
            cboLoaiSP.Items.AddRange(SanPhamBLL.Instance.GetCBBLoaiSP().ToArray());
        }
        public void GUI()
        {
            if (MaSP == "") return;
            SanPham s = SanPhamBLL.Instance.GetSPByMaSP(MaSP);
            txtMaSP.Enabled = false;
            txtMaSP.Text = s.MaSP;
            txtDonGiaSP.Text = s.DonGia.ToString();
            txtSoLuongSP.Text = s.SoLuongCon.ToString();
            dateNgayNhap.Value = s.NgayNhap;
            dateHansudung.Value = s.HanSuDung;
            
            foreach (CBBItem2 i in cboLoaiSP.Items)
            {
                if (i.Value == SanPhamBLL.Instance.GetMaLHPByMaSP(s.MaSP))
                {
                    cboLoaiSP.SelectedItem = i;
                    break;
                }
            }
        }
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            SanPham s = new SanPham
            {
                MaSP = txtMaSP.Text,
                TenSP = txtTenSP.Text,
                DonGia = Convert.ToDouble(txtDonGiaSP.Text),
                NgayNhap = dateNgayNhap.Value.Date,
                HanSuDung = dateHansudung.Value.Date,
                SoLuongCon = Convert.ToInt32(txtSoLuongSP.Text),
                MaLH = (((CBBItem2)cboLoaiSP.SelectedItem).Value).ToString(),
            };
            SanPhamBLL.Instance.AddUpdate(s);
            d("");
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtTenSP_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
