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
    public partial class viewavaitems : Form
    {
        public viewavaitems()
        {
            InitializeComponent();
        }

        private void viewavaitems_Load(object sender, EventArgs e)
        {
            int x = 0;
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] ", Program.xdata);
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
                command.CommandText = "SELECT * FROM [Items] ";
              
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        dataGridView1.Rows.Insert(x, reader["I_Name"], reader["I_Company"], reader["I_Type"], reader["I_Quantity"], reader["I_Expirydate"], reader["I_Tax"], reader["I_Wholesaleprice"], reader["I_sellingprice"]);
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
