using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThe
{
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
            ChangeBackgroundColor(Color.FromArgb(25, 36, 56));
        }
        private void ChangeBackgroundColor(Color color)
        {
            // Thay đổi màu nền của Form
            this.BackColor = color;
        }
        private void frmAdmin_Load(object sender, EventArgs e)
        {

        }

        private void frmAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
