using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QuanLyThe
{
    public partial class frmUser : Form
    {
        public SqlConnection connect;
        string a = "Data Source = CHIEUPHAN;Initial Catalog = QuanLyTheThuVien;Integrated Security = true";
        public frmUser()
        {
            
            
            InitializeComponent();
            ChangeBackgroundColor(Color.FromArgb(25, 36, 56));
        }
        private void ChangeButtonColor(Button button, Color color)
        {
            // Thay đổi màu nền của Button
            button.BackColor = color;
        }

        private void ChangeBackgroundColor(Color color)
        {
            // Thay đổi màu nền của Form
            this.BackColor = color;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                
                
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = false;
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBox3.Enabled = true;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
            }
            
        }
        public int genaralID()
        {
            int nam = DateTime.Now.Year;
            int thang = DateTime.Now.Month;
            int ngay = DateTime.Now.Day;
            int gio = DateTime.Now.Hour;
            int phut = DateTime.Now.Minute;
            int giay = DateTime.Now.Second;
            return nam + thang + ngay + gio + phut + giay;
        }
        DateTime today = DateTime.Now.Date;
        private void button1_Click(object sender, EventArgs e)
        {
            ChangeButtonColor(button1, Color.Blue);
            try
            {
                connect = new SqlConnection(a);
                connect.Open();
                string InsertString = "insert into MuonSach Values('" + genaralID() + "' ,' " + textBox1.Text + "','" + textBox2.Text + "','" + today + "','" + today.AddDays(14) + "')";
                SqlCommand cmd = new SqlCommand(InsertString, connect);
                cmd.ExecuteNonQuery();
                string InsertKH = "insert into KhachHang Values('" + genaralID() + "' ,' " + textBox1.Text + "','" + textBox2.Text + "','Chưa Trả')";
                SqlCommand cmd1 = new SqlCommand(InsertKH, connect);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Thanh Cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void ChucNangUser_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyTheThuVienDataSet.Sach' table. You can move, or remove it, as needed.
            this.sachTableAdapter.Fill(this.quanLyTheThuVienDataSet.Sach);
            connect = new SqlConnection(a);
            connect.Open();
            string ShowString = "select * from Sach";
            SqlDataAdapter adapter = new SqlDataAdapter(ShowString, connect);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeButtonColor(button2, Color.Blue);
            connect = new SqlConnection(a);
            connect.Open();
            string ShowString = "select * from Sach where TheLoai = "+ textBox3.Text +" ";
            SqlDataAdapter adapter = new SqlDataAdapter(ShowString, connect);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}
