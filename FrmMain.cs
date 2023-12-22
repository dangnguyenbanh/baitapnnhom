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
    public partial class frmMain : Form
    {
        //CHỈNH Ở ĐÂY NÈ EM, XOÁ Ở ĐÂY RỒI LÀM VỚI CÁI BUTTON 1 (btnLogin)
        private const string AdminUsername = "admin";
        private const string AdminPassword = "password";
        private const string UserUsername = "user";
        private const string UserPassword = "1";
        //
        public frmMain()
        {
            InitializeComponent();
            ChangeBackgroundColor(Color.FromArgb(25, 36, 56));
            ChangeButtonColor(btnLogin, Color.FromArgb(41, 240, 157));
        }
        private void ChangeBackgroundColor(Color color)
        {
            // Thay đổi màu nền của Form
            this.BackColor = color;
        }
        private void ChangeButtonColor(Button button, Color color)
        {
            // Thay đổi màu nền của Button
            button.BackColor = color;
        }

        private bool CheckLogin(string username, string password)
        {
            // Kiểm tra đăng nhập với tên đăng nhập và mật khẩu cứng
            return username == AdminUsername && password == AdminPassword;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeButtonColor(btnLogin, Color.Blue);
            //khởi tạo construction cho form con
            frmAdmin frmAdmin = new frmAdmin();
            frmUserMain frmUserMain = new frmUserMain();
            //
            string enteredUsername = txtUsername.Text;
            string enteredPassword = txtPassword.Text;
            if (CheckLogin(enteredUsername, enteredPassword))
            {
                
                frmAdmin.Show();
                //MessageBox.Show("Đăng nhập thành công!");
                // Thực hiện các hành động sau khi đăng nhập thành công
                this.Hide();
            }
            else if (enteredUsername == UserUsername && enteredPassword == UserPassword)
            {
                frmUserMain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công. Vui lòng kiểm tra lại tên đăng nhập và mật khẩu.");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //tạo nút ẩn hoặc hiện password
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //xử lý sự kiện bấm Enter thì đăng nhập  
        }
    }
}
