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
    public partial class manager_password : Form
    {
        public manager_password()
        {
            InitializeComponent();
        }

        private void buttonlogin1_Click(object sender, EventArgs e)
        {
            string con = Program.xsource;
                SqlConnection cn = new SqlConnection(con);
            bool blnfound = false;

            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from Employees", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["E_Username"].ToString() == textBox1.Text && textBox1.Text != "" && dr["E_Job"].ToString()=="Manager")
                {
                    if (dr["E_Password"].ToString() == textBox2.Text)
                    {
                        blnfound = true;

                    }
                }
            }
            if (blnfound == false)
            {
                MessageBox.Show("wrong username or password please try again ", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            {
                try
                {  DataTable dt = new DataTable();
                string name = "";
                using (var command = Program.xdata.CreateCommand())
                    {
                        command.CommandText = "SELECT E_Firstname FROM [Employees] where E_username like '" + textBox1.Text + "'";

                        Program.xdata.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                name = reader["E_Firstname"].ToString();
                            }
                        }
                    }

                Program.xdata.Close();

                    dr.Close();
                    cn.Close();
                    Program.xmanager.name(name);
                    Program.xmanager.mesag();
                    Program.xmanager.Show();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    this.Hide();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void button2ex_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
