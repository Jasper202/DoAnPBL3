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
namespace DoAnPBL3
{
    public partial class Login : Form
    {
        QLGym db = new QLGym();
        public Login()
        {
            InitializeComponent();
           

        }
        Main m = new Main();
        PhanQuyenNhanVien nv = new PhanQuyenNhanVien(); 
        private void button1_Click(object sender, EventArgs e)
        {
            if (TaiKhoanBLL.Instance.checkTK(txtTenDN.Text,txtMK.Text))
            {
                if(TaiKhoanBLL.Instance.checkPQ(txtTenDN.Text, txtMK.Text))
                {
                    this.Visible = false;
                    m.ShowDialog();
                }    
                else
                {
                    this.Visible = false;
                    nv.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu, vui lòng nhập lại!");
            } 
                
            
             
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp signUp = new SignUp();
            this.Visible = false;
            signUp.ShowDialog();
        }
    }
}
