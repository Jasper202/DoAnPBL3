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
    public partial class GiaHanGoiTap : Form
    {
        public delegate void MyDel(string txt);
        public MyDel d2 { get; set; }
        private string MaHV { get; set; }
        private string MaKH { get; set; }
        public GiaHanGoiTap(string txt)
        {
            MaHV = txt; 
            InitializeComponent();
            SetCBBGoiTap();
            txtGiaHanMaHV.Text = MaHV;
            txtGiaHanMaHV.Enabled = false;

        }
        public void SetCBBGoiTap()
        {
            cboGiaHanGoiTap.Items.AddRange(GoiTapBLL.Instance.GetCBBGoiTap().ToArray());
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (GoiTapBLL.Instance.checkMaLS(textBox1.Text))
            {
                double gia = 0;
                if (((CBBItem2)cboGiaHanGoiTap.SelectedItem).Value == "GT01")
                {
                    gia = 300000;
                }
                if (((CBBItem2)cboGiaHanGoiTap.SelectedItem).Value == "GT02")
                {
                    gia = 750000;
                }
                if (((CBBItem2)cboGiaHanGoiTap.SelectedItem).Value == "GT03")
                {
                    gia = 1350000;
                }
                if (((CBBItem2)cboGiaHanGoiTap.SelectedItem).Value == "GT04")
                {
                    gia = 1890000;
                }
                if (((CBBItem2)cboGiaHanGoiTap.SelectedItem).Value == "GT05")
                {
                    gia = 2400000;
                }
                LichSu_GH s = new LichSu_GH
                {
                    MaLS = textBox1.Text,
                    MaHV = txtGiaHanMaHV.Text,
                    NgayGH = DateTime.Now,
                    ThoigianGH = ((CBBItem2)cboGiaHanGoiTap.SelectedItem).Text,
                    MaNV = "NV01",
                    Gia = gia,
                };
                GoiTapBLL.Instance.addLSGH(s);
                GoiTapBLL.Instance.GiaHan(HVBLL.Instance.GetHVByMaHV(MaHV), cboGiaHanGoiTap.SelectedIndex);
                d2("");
                this.Dispose();
            }
            else
                MessageBox.Show("Mã lịch sử gia hạn trùng, vui lòng nhập lại");
        }
    }
}
