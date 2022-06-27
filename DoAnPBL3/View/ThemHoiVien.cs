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
    public partial class ThemHoiVien : Form
    {

        public delegate void MyDel(string txt);
        public MyDel d2 { get; set; }
        private string MaHV { get; set; }
        private string MaKH { get; set; }
        public ThemHoiVien(string maHV)
        {
            MaHV = maHV;
            if (HVBLL.Instance.GetHVByMaHV(maHV) != null)
            {
                MaKH = HVBLL.Instance.GetHVByMaHV(maHV).MaKH;
            }
            else
                MaKH = "";
            InitializeComponent();
            GUI();
        }
        public void GUI()
        {
            if (MaHV == "") return;
            KhachHang s = KhachHangBLL.Instance.GetKHByMaKH(MaKH);
            TheHV i = HVBLL.Instance.GetHVByMaHV(MaHV);
            txtMaHV.Enabled = false;
            txtMaKH.Enabled = false;
            txtMaHV.Text = i.MaHV;
            txtMaKH.Text = s.MaKH;
            if (s.GioiTinh)
            {
                rdoThemHVNam.Checked = true;
            }
            else
            {
                rdoThemHVNu.Checked = true;
            }
            txtThemSdt.Text = s.SDT;
            txtThemTenHV.Text = s.TenKH;
            dateTimePicker1.Value = s.NgaySinh;
            txtCCCD.Text = s.CCCD;
            txtDiachi.Text = s.DiaChi;
            if (i.MaGT == "GT01")
            {
                cboThemGoiTap.SelectedIndex = 0;
            }
            if (i.MaGT == "GT02")
            {
                cboThemGoiTap.SelectedIndex = 1;
            }
            if (i.MaGT == "GT03")
            {
                cboThemGoiTap.SelectedIndex = 2;
            }
            if (i.MaGT == "GT04")
            {
                cboThemGoiTap.SelectedIndex = 3;
            }
            if (i.MaGT == "GT05")
            {
                cboThemGoiTap.SelectedIndex = 4;
            }
            cboThemGoiTap.Enabled = false;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnLuuHV_Click(object sender, EventArgs e)
        {
            //try
            //{
                KhachHang s = new KhachHang
                {
                    MaKH = txtMaKH.Text,
                    TenKH = txtThemTenHV.Text,
                    GioiTinh = rdoThemHVNam.Checked,
                    NgaySinh = dateTimePicker1.Value,
                    DiaChi = txtDiachi.Text,
                    SDT = txtThemSdt.Text,
                    CCCD = txtCCCD.Text,
                };
                int k = 0;
                double tien = 0;
                string maGT = "";
                if (cboThemGoiTap.SelectedIndex == 0)
                {
                    k = 1;
                    tien = 300000;
                    maGT = "GT01";
                }
                else if (cboThemGoiTap.SelectedIndex == 1)
                {
                    k = 3;
                    tien = 750000;
                    maGT = "GT02";
                }
                else if (cboThemGoiTap.SelectedIndex == 2)
                {
                    k = 6;
                    tien = 1350000;
                    maGT = "GT03";
                }
                else if (cboThemGoiTap.SelectedIndex == 3)
                {
                    k = 9;
                    tien = 1890000;
                    maGT = "GT04";
                }
                else if (cboThemGoiTap.SelectedIndex == 4)
                {
                    k = 12;
                    tien = 2400000;
                    maGT = "GT05";
                }
                TheHV i = new TheHV
                {
                    MaHV = txtMaHV.Text,
                    NgayDK = DateTime.Now,
                    NgayKT = DateTime.Now.AddMonths(k),
                    Tongtien = tien,
                    MaGT = maGT,
                    MaKH = txtMaKH.Text,
                    MaNV = "NV01"
                };
                
                //if (KhachHangBLL.Instance.Check(MaKH))
                //{
                //    KhachHangBLL.Instance.UpdateKH(s);
                //}    
                HVBLL.Instance.AddUpdateHV(i, s);
            
                
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Chưa nhập thông tin hoặc nhập sai");
            //}
            d2("");
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (KhachHangBLL.Instance.Check(txtMaKH.Text))
            {
                TheHV i = HVBLL.Instance.GetHVByMaKH(txtMaKH.Text);
                if (i != null)
                {
                    txtMaHV.Text = i.MaHV;
                    txtMaHV.Enabled = false;
                }
                KhachHang s = KhachHangBLL.Instance.GetKHByMaKH(txtMaKH.Text);
                txtThemTenHV.Text = s.TenKH;
                txtDiachi.Text = s.DiaChi;
                txtCCCD.Text = s.CCCD;
                txtThemSdt.Text = s.SDT;
                dateTimePicker1.Value = s.NgaySinh;
                if (s.GioiTinh)
                {
                    rdoThemHVNam.Checked = true;
                }
                else
                {
                    rdoThemHVNu.Checked = true;
                }
            }
            else
                MessageBox.Show("Chưa có khách hàng này");
        }
    }
}
