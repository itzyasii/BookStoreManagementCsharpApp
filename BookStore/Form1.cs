using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bookStoreDataDataSet3.Books' table. You can move, or remove it, as needed.
            this.booksTableAdapter.Fill(this.bookStoreDataDataSet3.Books);

            panel1.Visible = false;
            




        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Books(BookID, Title, author, Genre, quantity) VALUES (@bID, @title, @author, @genre, @qty)";
            using (SqlConnection con = new SqlConnection("Data Source=(localdb)\\Local;Initial Catalog=BookStoreData;Integrated Security=True"))
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                {
                    MessageBox.Show("Fields Cannot be Empty!", "Fill all the fields", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }
                else
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@bID", textBox1.Text);
                        cmd.Parameters.AddWithValue("@title", textBox2.Text);
                        cmd.Parameters.AddWithValue("@author", textBox3.Text);
                        cmd.Parameters.AddWithValue("@genre", textBox4.Text);
                        cmd.Parameters.AddWithValue("@qty", textBox5.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        MessageBox.Show("Data Added Successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }


            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            this.Refresh();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            this.booksTableAdapter.Fill(this.bookStoreDataDataSet3.Books);
            this.Refresh();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                DataRow selectedRow = ((DataRowView)dataGridView1.SelectedRows[0].DataBoundItem).Row;

                DeleteRowFromDatabase(selectedRow);
                selectedRow.Delete();
            }
            else
            {
                MessageBox.Show("Select row to delete!", "Deletion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteRowFromDatabase(DataRow row)
        {
            string deleteQuery = "DELETE FROM Books WHERE BookID = @bookID";

            using (SqlConnection con = new SqlConnection("Data Source=(localdb)\\Local;Initial Catalog=BookStoreData;Integrated Security=True"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {
                    cmd.Parameters.AddWithValue("@bookID", row["BookID"]);
                    cmd.ExecuteNonQuery();
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
