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
    public partial class manbuyinglist : Form
    {
        public manbuyinglist()
        {
            InitializeComponent();
        }

        private void manbuyinglist_Load(object sender, EventArgs e)
        {
            int x = 0;
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Buy] ", Program.xdata);
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
                command.CommandText = "SELECT * FROM [Buy] ";
                // Program.xdata.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // string name = reader["I_Name"] + " " + reader["I_Company"];
                        dataGridView1.Rows.Insert(x, reader["I_Name"], reader["I_Quantity"], reader["Buy_Price"], reader["B_date"]);
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
