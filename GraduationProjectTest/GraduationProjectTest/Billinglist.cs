using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace GraduationProjectTest
{
    public partial class Billinglist : Form
    {
        public int x = 0;
        public Billinglist()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            x = 0;
            dataGridView1.Rows.Clear();
            this.Hide();
        }

        public int rowIndex;
        public int columnIndex;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            columnIndex = dataGridView1.CurrentCell.ColumnIndex;
            rowIndex = dataGridView1.CurrentCell.RowIndex;

            if (x != 0 && rowIndex < x)
            {
                Program.xbview.view(dataGridView1.Rows[rowIndex].Cells[4].Value.ToString(), dataGridView1.Rows[rowIndex].Cells[5].Value.ToString(), dataGridView1.Rows[rowIndex].Cells[1].Value.ToString(), dataGridView1.Rows[rowIndex].Cells[2].Value.ToString(), dataGridView1.Rows[rowIndex].Cells[3].Value.ToString(), dataGridView1.Rows[rowIndex].Cells[6].Value.ToString(), dataGridView1.Rows[rowIndex].Cells[0].Value.ToString(), dataGridView1.Rows[rowIndex].Cells[7].Value.ToString());
                Program.xbview.Show();
            }
        }

        public void insert()
        {
            string now = DateTime.Now.ToShortDateString();
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Billing] where B_Date like '" + now + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Billing] where B_Date like '" + now + "'";
                // con1.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Insert(x,reader["B_ID"],reader["I_Name"],reader["I_Price"],reader["I_Quantity"],reader["B_Date"],reader["B_Time"],reader["I_Cashier"],reader["B_Netamount"]);
                        x++;
                    }
                }
            }

            Program.xdata.Close();
        }

        private void Billinglist_Load(object sender, EventArgs e)
        {

        }
    }
}
