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
    public partial class SignUp : Form
    {
        QLGym db = new QLGym();
        public SignUp()
        {
            InitializeComponent();
            SetCBBChucVu();
            
        }
        public void SetCBBChucVu()
        {
            cbbVTNV.Items.AddRange(NhanVienBLL.Instance.GetCBBChucVu().ToArray());
        }
        private void btnSignup_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            if (NhanVienBLL.Instance.Check(txtMaNV.Text))
            {
                if (!(TaiKhoanBLL.Instance.checkTenDN(txtTenDN.Text)))
                {
                    int quyen = 0;
                    if (cbbVTNV.SelectedIndex == 0)
                    {
                        quyen = 1;
                    }
                    TaiKhoan t = new TaiKhoan
                    {
                        MaTK = (db.TaiKhoans.Count()+1).ToString(),
                        TenDN = txtTenDN.Text,
                        MatKhau = txtMK.Text,
                        Quyen = quyen,
                        TenChucVu = ((CBBItem)cbbVTNV.SelectedItem).Text,
                    };
                    
                    TaiKhoanBLL.Instance.addTK(t);
                    TaiKhoanBLL.Instance.changeMaTk(txtMaNV.Text);
                    MessageBox.Show("Tạo TK thành công");
                    l.Visible = true;
                    this.Visible = false;
                }
                else MessageBox.Show("Tên tài khoản trùng");
            } 
            else MessageBox.Show("Không tồn tại mã nhân viên");

        }
    }
}
