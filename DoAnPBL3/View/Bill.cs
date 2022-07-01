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
        bool check = false; 
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
            cboMaHDBan.Items.Add(new CBBItem2 { Text = "All", Value = "0" });
            cboMaHDBan.Items.AddRange(DanhThuBLL.Instance.GetCBBMaHD().ToArray());
        }
        private void cbbMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenKhach.Text = KhachHangBLL.Instance.getTenKH(((CBBItem2)cbbMaKH.SelectedItem).Text);
        }
        private void cbbMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtDonGiaBan.Text = SanPhamBLL.Instance.getGiaSP(((CBBItem2)cbbMatHang.SelectedItem).Value).ToString();
            txtDonGiaBan.Enabled = false;
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
            if (txtSoLuong.Text == "" || txtDonGiaBan.Text == "")
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
            }
            else
            {
                txtThanhTien.Enabled = false;
                txtThanhTien.Text = (Convert.ToDouble(txtDonGiaBan.Text) * Convert.ToDouble(txtSoLuong.Text)).ToString();
            }    
            
        }
        public void Reset()
        {
            cbbMaKH.Enabled = false;
            dtpNgayBan.Enabled = false;
            cbbMaNV.Enabled = false;
            txtTenKhach.Enabled = false;
            
        }           
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (((CBBItem2)cboMaHDBan.SelectedItem).Text == "All")
            {
                dgvHDBanHang.DataSource = DanhThuBLL.Instance.GetHDView();
            }    
            else
            dgvHDBanHang.DataSource = DanhThuBLL.Instance.GetHoadonViewbySearch(((CBBItem2)cboMaHDBan.SelectedItem).Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            check = false;
            this.Dispose();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            if (txtTenKhach.Text == "" || cbbMaNV.SelectedItem == null || cbbMaKH.SelectedItem == null || cbbMatHang.SelectedItem == null)
            {
                MessageBox.Show("Chưa nhập đủ thông tin");
            }
            else
            {
                if (check)
                {
                    CTHD k = new CTHD
                    {
                        MaCTHD = DanhThuBLL.Instance.getMaCTHD(),
                        MaHD = DanhThuBLL.Instance.getMaHDNow(),
                        SoLuong = Convert.ToInt32(txtSoLuong.Text),
                        NgayInHD = dtpNgayBan.Value,
                        MaSP = ((CBBItem2)cbbMatHang.SelectedItem).Value,
                        Gia = Convert.ToDouble(txtDonGiaBan.Text),
                    };
                    DanhThuBLL.Instance.UpdateTongHD(DanhThuBLL.Instance.getMaHDNow(), Convert.ToDouble(txtThanhTien.Text));
                    DanhThuBLL.Instance.AddCTHD(k);
                    dgvHDBanHang.DataSource = DanhThuBLL.Instance.GetHDView();
                    d();
                }
                else
                {
                    HoaDon s = new HoaDon
                    {
                        MaHD = DanhThuBLL.Instance.getMaHD(),
                        NgayBan = dtpNgayBan.Value,
                        MaNV = ((CBBItem2)cbbMaNV.SelectedItem).Text,
                        MaKH = ((CBBItem2)cbbMaKH.SelectedItem).Text,
                        TongHD = Double.Parse(txtThanhTien.Text)
                    };

                    CTHD k = new CTHD
                    {
                        MaCTHD = DanhThuBLL.Instance.getMaCTHD(),
                        MaHD = DanhThuBLL.Instance.getMaHD(),
                        SoLuong = Convert.ToInt32(txtSoLuong.Text),
                        NgayInHD = dtpNgayBan.Value,
                        MaSP = ((CBBItem2)cbbMatHang.SelectedItem).Value,
                        Gia = Convert.ToDouble(txtDonGiaBan.Text),
                    };
                    DanhThuBLL.Instance.AddHD(s);
                    dgvHDBanHang.DataSource = DanhThuBLL.Instance.GetHDView();
                    DanhThuBLL.Instance.AddCTHD(k);
                    d();
                    Reset();
                    check = true;
                }    
                
            }
            txtTongTien.Text = DanhThuBLL.Instance.getSum();


        }

        private void dgvHDBanHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHDBanHang.SelectedRows.Count == 1)
            {
                txtTongTien.Text = DanhThuBLL.Instance.getTongHD(dgvHDBanHang.SelectedRows[0].Cells["MaHD"].Value.ToString()).ToString();
            }    
            
        }

        private void cboMaHDBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((CBBItem2)cboMaHDBan.SelectedItem).Text == "All")
            {
                txtTongTien.Text = DanhThuBLL.Instance.getSum();
            }    
            else txtTongTien.Text = DanhThuBLL.Instance.getTongHD(((CBBItem2)cboMaHDBan.SelectedItem).Value).ToString();
        }
    }
}
