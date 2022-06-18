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

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //12345
        }
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
                foreach (DataGridViewRow i in dataGridView_NV.SelectedRows)
                {
                    LNV.Add(i.Cells["MaNV"].Value.ToString());
                }
                NhanVienBLL.Instance.DelNV(LNV);
            }
            ShowNV("");
        }
        //private void btnDel_NV_Click(object sender, EventArgs e)
        //{
        //    //List<string> LNV = new List<string>();
        //    if (dataGridView_NV.SelectedRows.Count == 1)
        //    {
        //        foreach (DataGridViewRow i in dataGridView_NV.SelectedRows)
        //        {
        //            string maNV = i.Cells["MaNV"].Value.ToString();
        //            NhanVienBLL.Instance.DelNV(maNV);
        //        }
        //       // NhanVienBLL.Instance.DelNV(maNV);
        //    }
        //    ShowNV("");
        //}

        private void btnSearch_NV_Click(object sender, EventArgs e)
        {
            string txt = txtSearch_NV.Text;
            dataGridView_NV.DataSource = NhanVienBLL.Instance.GetNVViewBySearch(txt);
        }
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
                foreach (DataGridViewRow i in dataGridView_SP.SelectedRows)
                {
                    LSP.Add(i.Cells["MaSP"].Value.ToString());
                }
                SanPhamBLL.Instance.DelSP(LSP);
            }
            ShowSP("");
        }

        private void btnSearch_SP_Click(object sender, EventArgs e)
        {
            string txt = txtSearch_SP.Text;
            dataGridView_SP.DataSource = SanPhamBLL.Instance.GetSPViewByName(txt);
        }
    }
}
