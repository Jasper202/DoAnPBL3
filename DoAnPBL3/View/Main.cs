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
using DoAnPBL3.View;

namespace DoAnPBL3
{

    public partial class Main : Form
    {
        QLGym db = new QLGym();
        public Main()
        {
            InitializeComponent();
            Load();

        }
        public void Load()
        {
            dataGridView_NV.DataSource = NhanVienBLL.Instance.GetAllNVView();
            dataGridView_SP.DataSource = SanPhamBLL.Instance.GetAllSPView();
            dataGridView_KH.DataSource = KhachHangBLL.Instance.GetAllKHView();
            dataGridView_HV.DataSource = HVBLL.Instance.GetAllHVView();
            dataGridView_GT.DataSource = GoiTapBLL.Instance.GetAllGTView();
            SetCBBGoiTap();
        }



        private void btnMenu1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private bool isCollapsed;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panel1.Height += 15;
                if (panel1.Size == panel1.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                panel1.Height -= 15;
                if (panel1.Size == panel1.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }
        private bool isCollapsed2;
        private void btn_Menu2_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isCollapsed2)
            {
                panel2.Height += 15;
                if (panel2.Size == panel2.MaximumSize)
                {
                    timer2.Stop();
                    isCollapsed2 = false;
                }
            }
            else
            {
                panel2.Height -= 15;
                if (panel2.Size == panel2.MinimumSize)
                {
                    timer2.Stop();
                    isCollapsed2 = true;
                }
            }
        }


        //QUẢN LÍ NHÂN VIÊN
        public void ShowNV(string txt)
        {
            dataGridView_NV.DataSource = NhanVienBLL.Instance.GetNVViewBySearch(txt);
        }

        private void btnAdd_NV_Click(object sender, EventArgs e)
        {
            ThemNhanVien f = new ThemNhanVien("");
            f.d = new ThemNhanVien.MyDel(ShowNV);
            f.Show();
        }

        private void btnUp_NV_Click(object sender, EventArgs e)
        {
            if (dataGridView_NV.SelectedRows.Count == 1)
            {
                NhanVien_View _select = dataGridView_NV.SelectedRows[0].DataBoundItem as NhanVien_View;
                ThemNhanVien f = new ThemNhanVien(_select.MaNV);
                f.d = new ThemNhanVien.MyDel(ShowNV);
                f.Show();
            }
        }

        private void btnDel_NV_Click(object sender, EventArgs e)
        {
            List<string> LNV = new List<string>();
            if (dataGridView_NV.SelectedRows.Count >= 0)
            {
                try
                {
                    foreach (DataGridViewRow i in dataGridView_NV.SelectedRows)
                    {
                        LNV.Add(i.Cells["MaNV"].Value.ToString());
                    }
                    NhanVienBLL.Instance.DelNV(LNV);
                    ShowNV("");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa nhân viên này");
                }
            }

        }

        private void btnSearch_NV_Click(object sender, EventArgs e)
        {
            string txt = txtSearch_NV.Text;
            dataGridView_NV.DataSource = NhanVienBLL.Instance.GetNVViewBySearch(txt);
        }

        private void dataGridView_NV_Click(object sender, EventArgs e)
        {
            if (dataGridView_NV.SelectedRows.Count == 1)
            {
                NhanVien_View _select = dataGridView_NV.SelectedRows[0].DataBoundItem as NhanVien_View;
                txtMa_NV.Text = _select.MaNV;
                txtTen_NV.Text = _select.TenNV;
                if (_select.GioiTinh)
                {
                    rbtnNam_NV.Checked = true;
                }
                else
                {
                    rbtnNu_NV.Checked = true;
                }
                txtSDT_NV.Text = _select.SDT;
                txtCCCD_NV.Text = _select.CCCD;
                txtVitri_NV.Text = _select.ChucVu;

            }

        }
        /// QUẢN LÝ SẢN PHẨM

        public void ShowSP(string txt)
        {
            dataGridView_SP.DataSource = SanPhamBLL.Instance.GetSPViewByName(txt);
            //dataGridView_NV.DataSource = NhanVienBLL.Instance.GetNVViewBySearch(txt);
        }
        private void btnAdd_SP_Click(object sender, EventArgs e)
        {
            ThemSanPham f = new ThemSanPham("");
            f.d = new ThemSanPham.MyDel(ShowSP);
            f.Show();
        }

        private void btnUp_SP_Click(object sender, EventArgs e)
        {
            if (dataGridView_SP.SelectedRows.Count == 1)
            {
                SanPham_View _select = dataGridView_SP.SelectedRows[0].DataBoundItem as SanPham_View;
                ThemSanPham f = new ThemSanPham(_select.MaSP);
                f.d = new ThemSanPham.MyDel(ShowSP);
                f.Show();
            }
        }

        private void btnDel_SP_Click(object sender, EventArgs e)
        {
            List<string> LSP = new List<string>();
            if (dataGridView_SP.SelectedRows.Count >= 0)
            {
                try
                {
                    foreach (DataGridViewRow i in dataGridView_SP.SelectedRows)
                    {
                        LSP.Add(i.Cells["MaSP"].Value.ToString());
                    }
                    SanPhamBLL.Instance.DelSP(LSP);
                    ShowSP("");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể sản phẩm này");
                }

            }

        }

        private void btnSearch_SP_Click(object sender, EventArgs e)
        {

            dataGridView_SP.DataSource = SanPhamBLL.Instance.GetSPViewByName(txtSearch_SP.Text);
        }
        private void dataGridView_SP_Click(object sender, EventArgs e)
        {
            if (dataGridView_SP.SelectedRows.Count == 1)
            {
                SanPham_View sp = dataGridView_SP.SelectedRows[0].DataBoundItem as SanPham_View;
                txtMa_SP.Text = sp.MaSP;
                txtTen_SP.Text = sp.TenSP;
                txtSoLuong_SP.Text = sp.SoLuong.ToString();
                txtGia_SP.Text = sp.DonGia.ToString();
                txtHangSX_SP.Text = sp.HangSX;
                if (sp.SoLuong > 0)
                {
                    txtTinhtrang_SP.Text = "Còn hàng";
                }
                else
                {
                    txtTinhtrang_SP.Text = "Hết hàng";
                }
                dateNgayNhap_SP.Value = sp.NgayNhap;
                cbbLoai_SP.Text = sp.LoaiSP;
            }
        }

        /// QUẢN LÝ KHÁCH HÀNG
        public void ShowKH(string txt)
        {
            dataGridView_KH.DataSource = KhachHangBLL.Instance.GetKHViewBySearch(txt);
        }

        private void btnAdd_KH_Click(object sender, EventArgs e)
        {
            ThemKhachHang f = new ThemKhachHang("");
            f.d1 = new ThemKhachHang.MyDel(ShowKH);
            f.Show();
        }

        private void btnUp_KH_Click(object sender, EventArgs e)
        {
            if (dataGridView_NV.SelectedRows.Count == 1)
            {
                KhachHang_View _select = dataGridView_KH.SelectedRows[0].DataBoundItem as KhachHang_View;
                ThemKhachHang f = new ThemKhachHang(_select.MaKH);
                f.d1 = new ThemKhachHang.MyDel(ShowKH);
                f.Show();
            }
        }

        private void btnDel_KH_Click(object sender, EventArgs e)
        {
            List<string> LKH = new List<string>();
            if (dataGridView_KH.SelectedRows.Count >= 0)
            {
                try
                {
                    foreach (DataGridViewRow i in dataGridView_KH.SelectedRows)
                    {
                        LKH.Add(i.Cells["MaKH"].Value.ToString());
                    }
                    KhachHangBLL.Instance.DelKH(LKH);
                    ShowKH("");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa khách hàng này");
                }
            }

        }

        private void dataGridView_KH_Click(object sender, EventArgs e)
        {
            if (dataGridView_KH.SelectedRows.Count == 1)
            {
                KhachHang_View _select = dataGridView_KH.SelectedRows[0].DataBoundItem as KhachHang_View;
                txtMa_KH.Text = _select.MaKH;
                txtTen_KH.Text = _select.TenKH;
                dateNS_KH.Value = _select.NgaySinh;
                txtSDT_KH.Text = _select.SDT;
                txtDiaChi_KH.Text = _select.DiaChi;
            }
        }

        private void btnSearch_KH_Click(object sender, EventArgs e)
        {

            dataGridView_KH.DataSource = KhachHangBLL.Instance.GetKHViewBySearch(txtSearchKH.Text);
        }


        //QUẢN LÍ HỘI VIÊN
        public void ShowHV(string txt)
        {
            dataGridView_HV.DataSource = HVBLL.Instance.GetHVViewByName(txt);
        }
        private void btn_Add_HV_Click(object sender, EventArgs e)
        {
            ThemHoiVien f = new ThemHoiVien("");
            f.d2 = new ThemHoiVien.MyDel(ShowHV);
            f.Show();
        }

        private void btn_Up_HV_Click(object sender, EventArgs e)
        {
            if (dataGridView_HV.SelectedRows.Count == 1)
            {
                HV_View _select = dataGridView_HV.SelectedRows[0].DataBoundItem as HV_View;
                ThemHoiVien f = new ThemHoiVien(_select.MaHV);
                f.d2 = new ThemHoiVien.MyDel(ShowHV);
                f.Show();
            }
        }

        private void btn_Del_HV_Click(object sender, EventArgs e)
        {
            List<string> LHV = new List<string>();
            if (dataGridView_HV.SelectedRows.Count >= 0)
            {
                try
                {
                    foreach (DataGridViewRow i in dataGridView_HV.SelectedRows)
                    {
                        LHV.Add(i.Cells["MaHV"].Value.ToString());
                    }
                    HVBLL.Instance.DelHV(LHV);
                    ShowHV("");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa hội viên này");
                }

            }

        }

        private void btnSearch_HV_Click(object sender, EventArgs e)
        {
            dataGridView_HV.DataSource = HVBLL.Instance.GetHVViewByName(txtSearchHV.Text);
        }

        private void dataGridView_HV_Click(object sender, EventArgs e)
        {
            if (dataGridView_HV.SelectedRows.Count == 1)
            {
                HV_View _select = dataGridView_HV.SelectedRows[0].DataBoundItem as HV_View;
                txtMa_HV.Text = _select.MaHV;
                txtTen_HV.Text = _select.TenHV;
                txtGoiTap_HV.Text = _select.GoiTap;
                dateHetHan_HV.Value = _select.NgayKT;
                txtSDT_HV.Text = _select.SDT;

                if (_select.GioiTinh)
                {
                    rbtnNam_HV.Checked = true;
                }
                else
                {
                    rbtnNu_HV.Checked = true;
                }
            }
        }


        //QUẢN LÍ GÓI TẬP

        public void ShowGT(string txt)
        {
            dataGridView_GT.DataSource = GoiTapBLL.Instance.GetGTViewByMaGT(txt);
        }
        private void button4_Click(object sender, EventArgs e)//tìm kiếm
        {
            dataGridView_GT.DataSource = GoiTapBLL.Instance.GetGTViewByMaGT(txtMa_GT.Text);
        }

        private void button5_Click(object sender, EventArgs e)//Gia hạn
        {
            if (dataGridView_GT.SelectedRows.Count == 1)
            {
                GoiTap_View _select = dataGridView_GT.SelectedRows[0].DataBoundItem as GoiTap_View;
                GiaHanGoiTap f = new GiaHanGoiTap(_select.MaHV);
                f.d2 = new GiaHanGoiTap.MyDel(ShowGT);
                f.Show();
            }

        }
        private void button6_Click(object sender, EventArgs e)//Xem gói tập
        {

            XemGoiTap f = new XemGoiTap();
            f.Show();
        }

        private void dateHan_GT_ValueChanged(object sender, EventArgs e)
        {

        }
        public void SetCBBGoiTap()
        {
            cbbGoi_GT.Items.AddRange(GoiTapBLL.Instance.GetCBBGoiTap().ToArray());
        }
        private void dataGridView_GT_Click(object sender, EventArgs e)
        {
            if (dataGridView_GT.SelectedRows.Count == 1)
            {
                GoiTap_View _select = dataGridView_GT.SelectedRows[0].DataBoundItem as GoiTap_View;
                txtMa_GT.Text = _select.MaHV;
                dateNgayDK.Value = _select.NgayDK;
                dateHan_GT.Value = _select.NgayKT;
                if (_select.GoiTap.ToLower() == "gói 1 tháng")
                {
                    cbbGoi_GT.SelectedIndex = 0;
                }
                if (_select.GoiTap.ToLower() == "gói 3 tháng")
                {
                    cbbGoi_GT.SelectedIndex = 1;
                }
                if (_select.GoiTap.ToLower() == "gói 6 tháng")
                {
                    cbbGoi_GT.SelectedIndex = 2;
                }
                if (_select.GoiTap.ToLower() == "gói 9 tháng")
                {
                    cbbGoi_GT.SelectedIndex = 3;
                }
                if (_select.GoiTap.ToLower() == "gói 12 tháng")
                {
                    cbbGoi_GT.SelectedIndex = 4;
                }
            }
        }

        private void butXemHD_Click(object sender, EventArgs e)
        {
            DateTime first = dateTimePicker3.Value;
            DateTime last = dateTimePicker2.Value;
            int result = DateTime.Compare(first, last);
            if(result <= 0)
            {
                dtgHoaDon.DataSource = DanhThuBLL.Instance.GetHDViewByDate(first, last);
            }        
            else
            {
                MessageBox.Show("Vui lòng nhập thời gian hợp lệ !!!");
            }    
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Bill f = new Bill();
            f.Show();
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Login f = new Login();
            f.Visible = true;
        }
    }
}
