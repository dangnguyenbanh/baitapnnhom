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
    public partial class ThemXoaSua : Form
    {
        int s,m;
        ErrorProvider errorProvider1;
        public SqlConnection connect;
        string a = "Data Source = Anhduy;Initial Catalog = QuanLyTheThuVien;Integrated Security = true";
        public ThemXoaSua()
        {
            errorProvider1 = new ErrorProvider();
            InitializeComponent();
        }
        public void Them(int M, string T, string TG, string NXB,string TL,int SL)
        {
            try
            {
                connect = new SqlConnection(a);
                connect.Open();
                string InsertString = "insert into Sach Values('" + M + "' ,' " + T + "','" + TG + "','" + NXB + "','" + TL + "','" + SL + "')";
                SqlCommand cmd = new SqlCommand(InsertString, connect);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thanh Cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Them(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, int.Parse(textBox6.Text));
        }

        public void Xoa(int S)
        {
            try
            {

                connect = new SqlConnection(a);
                connect.Open();
                string DeleteString = "delete * where MaSach = '" + S + "'";
                SqlCommand cmd = new SqlCommand(DeleteString, connect);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thanh cong");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Xoa(int.Parse(textBox1.Text));
        }

        public void Sua(int M, string T, string TG, string NXB, string TL, int SL,int MS)
        {
            try
            {
                connect = new SqlConnection(a);
                connect.Open();
                string InsertString = "Update Sach set MaSach = '" + M + "',TenSach = '" + T + "', TenTacGia =  '" + TG + "', NhaXuatBan = '" + NXB + "', TheLoai = '" + TL + "', SoLuong = '" + SL + "' where MaSach = '" + MS + "'";
                SqlCommand cmd = new SqlCommand(InsertString, connect);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thanh Cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Sua(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, int.Parse(textBox6.Text), int.Parse(textBox7.Text));
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out s) == false)
            {
                errorProvider1.SetError(textBox1, "So luong khong hop le");
            }
            else
                errorProvider1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(ctr, "Khong duoc de trong ma sach ");
            }
            else if (int.TryParse(textBox1.Text, out m) == false)
            {
                this.errorProvider1.SetError(ctr, "Ma sach khong chua ky tu");
            }
            else
                this.errorProvider1.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(ctr, "Khong duoc de trong ten sach");
            }
            else
                this.errorProvider1.Clear();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            if (ctr.Text.Trim().Length == 0)
            {
                this.errorProvider1.SetError(ctr, "Khong duoc de trong the loai sach");
            }
            else
                this.errorProvider1.Clear();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int n;
            n = e.RowIndex;
            try
            {
                textBox1.Text = dataGridView1.Rows[n].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[n].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[n].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[n].Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.Rows[n].Cells[2].Value.ToString();
                textBox6.Text = dataGridView1.Rows[n].Cells[2].Value.ToString();
                
                
            }
            catch
            {
                textBox1.Text = dataGridView1.Rows[n].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[n].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[n].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[n].Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.Rows[n].Cells[2].Value.ToString();
                textBox6.Text = dataGridView1.Rows[n].Cells[2].Value.ToString();
            }
        }
        

        private void ThemXoaSua_Load(object sender, EventArgs e)
        {
            connect = new SqlConnection(a);
            connect.Open();
            string ShowString = "select * from Sach";
            SqlDataAdapter adapter = new SqlDataAdapter(ShowString, connect);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connect = new SqlConnection(a);
            connect.Open();
            string ShowString = "select * from Sach";
            SqlDataAdapter adapter = new SqlDataAdapter(ShowString, connect);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        

        
    }
}
