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
using DoAnPBL3.View;
using DoAnPBL3.DTO;

namespace DoAnPBL3
{
    public partial class Bill : Form
    {
        QLGym db = new QLGym();
        public delegate void MyDel();
        public MyDel d { get; set; }           

        public Bill()
        {         
            InitializeComponent();
            Load();
            SetCBBNV();
            SetCBBKH();
            SetCBBMaHD();
            SetCBBSanPham();          
        }
        public void Load()
        {
            dgvHDBanHang.DataSource = DanhThuBLL.Instance.GetHDView();
        }
        public void SetCBBSanPham()
        {
            cbbMatHang.Items.AddRange(DanhThuBLL.Instance.GetCBBSanPham().ToArray());
        }
        public void SetCBBNV()
        {
            cbbMaNV.Items.AddRange(DanhThuBLL.Instance.GetCBBNV().ToArray());
        }
        public void SetCBBKH()
        {
            cbbMaKH.Items.AddRange((DanhThuBLL.Instance.GetCBBKH().ToArray()));
        }    
        public void SetCBBMaHD()
        {
            cboMaHDBan.Items.AddRange(DanhThuBLL.Instance.GetCBBMaHD().ToArray());
        }
        private void cbbMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (KhachHang i in db.KhachHangs.Select(p => p))
            {
                if (i.MaKH == ((CBBItem2)cbbMaKH.SelectedItem).Text)
                {
                    txtTenKhach.Text = i.TenKH;
                }
            }
        }
        private void cbbMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(SanPham i in db.SanPhams.Select(p=>p))
            {
                if(i.MaSP == ((CBBItem2)cbbMatHang.SelectedItem).Value)
                {
                    txtDonGiaBan.Text = i.DonGia.ToString();
                }    
            }                          
        }    
        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == (char)8))
            {
                e.Handled = true;
            }
        }

        private void butThanhTien_Click(object sender, EventArgs e)
        {
            txtThanhTien.Text = (Convert.ToDouble(txtDonGiaBan.Text) * Convert.ToDouble(txtSoLuong.Text)).ToString();
        }
        public void Reset()
        {
            txtMaHDBan.Text = "";
            txtTenKhach.Text = "";
            //cbbMaNV.SelectedIndex = -1;
            //cbbMaKH.SelectedIndex = -1;
            txtTenKhach.Text = "";
            //cbbMaNV.SelectedIndex = -1;
            txtDonGiaBan.Text = "";
            txtSoLuong.Text = "";
            txtThanhTien.Text = "";
        }           
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvHDBanHang.DataSource = DanhThuBLL.Instance.GetHoadonViewbySearch(((CBBItem2)cboMaHDBan.SelectedItem).Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            HoaDon s = new HoaDon
            {
                MaHD = txtMaHDBan.Text,
                NgayBan = dtpNgayBan.Value,
                MaNV = ((CBBItem2)cbbMaNV.SelectedItem).Text,
                MaKH = ((CBBItem2)cbbMaKH.SelectedItem).Text,
                TongHD = Double.Parse(txtThanhTien.Text)
            };
            DanhThuBLL.Instance.AddHD(s);
            dgvHDBanHang.DataSource = DanhThuBLL.Instance.GetHDView();
            ReloadCTHD();
            Reset();
        }
        public void ReloadCTHD()
        {                   
            CTHD s = new CTHD
            {
                MaCTHD = "3",
                MaHD = txtMaHDBan.Text,
                SoLuong = Convert.ToInt32(txtSoLuong.Text),
                NgayInHD = dtpNgayBan.Value,
                MaSP = ((CBBItem2)cbbMatHang.SelectedItem).Value,             
                Gia = Convert.ToDouble(txtDonGiaBan.Text),              
            };
            DanhThuBLL.Instance.AddCTHD(s);
            d();
        }


    }
}
