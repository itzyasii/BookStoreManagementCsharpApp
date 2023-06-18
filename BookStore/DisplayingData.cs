using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class DisplayingData : Form
    {
        public DisplayingData()
        {
            InitializeComponent();
        }

        private void DisplayingData_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bookStoreDataDataSet2.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.bookStoreDataDataSet2.Books);

            //dataGridView1.Dock = DockStyle.Fill;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.Columns["BookID"].FillWeight = 100;
            //dataGridView1.Columns["Title"].FillWeight = 200;
            //dataGridView1.Columns["author"].FillWeight = 200;
            //dataGridView1.Columns["Genre"].FillWeight = 200;
            //dataGridView1.Columns["quantity"].FillWeight = 200;

        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //    dataGridView1.Columns["BookID"].FillWeight = 200;
            //    dataGridView1.Columns["Title"].FillWeight = 200;
            //    dataGridView1.Columns["author"].FillWeight = 200;
            //    dataGridView1.Columns["Genre"].FillWeight = 200;
            //    dataGridView1.Columns["quantity"].FillWeight = 200;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin ad = new Admin();
            ad.Show();
            this.Hide();

        }
    }
}
