using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace GraduationProjectTest
{
    public partial class viewexpenses : Form
    {
        public viewexpenses()
        {
            InitializeComponent();
        }

        private void viewexpenses_Load(object sender, EventArgs e)
        {
            int x = 0;
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [expenses] ", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);

                // Program.xdata.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [expenses] ";
                // Program.xdata.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Insert(x,reader["type"], reader["amount"], reader["date"]);
                        x++;
                    }
                }
            }
            Program.xdata.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
