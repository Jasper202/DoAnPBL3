using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnPBL3.View
{
    public partial class PhanQuyenNhanVien : Form
    {
        public PhanQuyenNhanVien()
        {
            InitializeComponent();
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
           
        }

        private void PhanQuyenNhanVien_Load(object sender, EventArgs e)
        {

        }
    }
}
