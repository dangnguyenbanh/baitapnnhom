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
    public partial class frmUserMain : Form
    {
        public frmUserMain()
        {
            InitializeComponent();
            ChangeBackgroundColor(Color.FromArgb(25, 36, 56));
            ChangeButtonColor(btnLogOut, Color.FromArgb(41, 240, 157));
        }

        private void ChangeBackgroundColor(Color color)
        {
            // Thay đổi màu nền của Form
            this.BackColor = color;
        }

        private void frmUserMain_Load(object sender, EventArgs e)
        {

        }

        private void ChangeButtonColor(Button button, Color color)
        {
            // Thay đổi màu nền của Button
            button.BackColor = color;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult check;
            check = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?",
                "Đăng xuất", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (check == DialogResult.Yes)
            {
                MessageBox.Show("Đăng xuất thành công!");
                this.Hide();
                frmMain frmMain = new frmMain();
                frmMain.Show();
            }
        }

        private void btnFunctions_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUser frmUser = new frmUser();
            frmUser.Show();
        }
    }
}
