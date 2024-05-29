using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qly_Danhba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Modify modify;
        Information information;
        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            {
                modify = new Modify();

                // Thiết lập các cột cho DataGridView
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "MaDN",
                    HeaderText = "Mã định danh",
                    Name = "MaDN"
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TenCq",
                    HeaderText = "Tên cơ quan",
                    Name = "TenCq"
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "SDT",
                    HeaderText = "SĐT",
                    Name = "SDT"
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "NguoiDaiDien",
                    HeaderText = "Người đại diện",
                    Name = "NguoiDaiDien"
                });

                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "GhiChu",
                    HeaderText = "Ghi chú",
                    Name = "GhiChu"
                });

                try
                {
                    dataGridView1.DataSource = modify.getAllInformation();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string MaDN = this.textBox1.Text;
            string tenCq = this.textBox3.Text;
            string SDT = this.textBox2.Text;
            string nguoiDaiDien = this.textBox4.Text;
            string ghiChu = this.textBox5.Text;
            information = new Information(MaDN, tenCq, SDT, nguoiDaiDien, ghiChu);
            if (modify.insert(information))
            {
                dataGridView1.DataSource = modify.getAllInformation();
            }
            else
            {

                MessageBox.Show("Lỗi " + "không thêm vào được.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string MaDN = this.textBox1.Text;
            string tenCq = this.textBox3.Text;
            string SDT = this.textBox2.Text;
            string nguoiDaiDien = this.textBox4.Text;
            string ghiChu = this.textBox5.Text;
            information = new Information(MaDN, tenCq, SDT, nguoiDaiDien, ghiChu);
            if (modify.update(information))
            {
                dataGridView1.DataSource = modify.getAllInformation();
            }
            else
            {

                MessageBox.Show("Lỗi " + "không sửa được.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string MaDN = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (modify.delete(MaDN))
            {
                dataGridView1.DataSource = modify.getAllInformation();
            }
            else
            {
                MessageBox.Show("Lỗi " + "không xóa được.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["MaDN"].Value.ToString();
                textBox3.Text = row.Cells["tenCq"].Value.ToString();
                textBox2.Text = row.Cells["SDT"].Value.ToString();
                textBox4.Text = row.Cells["nguoiDaiDien"].Value.ToString();
                textBox5.Text = row.Cells["ghiChu"].Value.ToString();
            }
        }
    }
}
