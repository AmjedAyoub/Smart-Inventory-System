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
    
    public partial class Showemployee : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Showemployee()
        {
            InitializeComponent();
        }

        public void Showemployee_Load(object sender, EventArgs e)
        {
            int x=0;
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Employees] ", Program.xdata);
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
                command.CommandText = "SELECT * FROM [Employees] ";
                // Program.xdata.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader["E_Firstname"] + " " + reader["E_Lastname"];
                        dataGridView1.Rows.Insert(x,name, reader["E_Hiredate"], reader["E_Email"], reader["E_Contactnum"], reader["E_Job"], reader["E_Sallary"], reader["E_Drop"], reader["E_Username"], reader["E_Password"]);
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
