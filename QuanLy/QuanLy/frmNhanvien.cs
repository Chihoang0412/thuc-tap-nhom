using QuanLy.Controller;
using QuanLy.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLy
{
    public partial class frmNhanvien : Form
    {
        public frmNhanvien()
        {
            InitializeComponent();
        }
        NhanVienController nc = new NhanVienController();
        private void button1_Click(object sender, EventArgs e)
        {
            View();
        }
        private void View()
        {
            nc.SeachFullData();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = nc.DSNV;
        }
        int CrrMa;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           CrrMa = int.Parse(dataGridView1.CurrentRow.Cells["MaNV"].Value.ToString());
            textBox1.Text = dataGridView1.CurrentRow.Cells["TenNV"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["NgaySinh"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["DiaChi"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["GioiTinh"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["Luong"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Ban co muon xoa nhan vien nay khong?", "Chu y!", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                nc.Delete(CrrMa);
                MessageBox.Show("Xoa Thanh Cong Nhan Vien");
            }
            
            View();
        }
    }
}
