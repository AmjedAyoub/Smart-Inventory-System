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
    public partial class changepass : Form
    {
        public changepass()
        {
            InitializeComponent();
        }

        private void changepass_Load(object sender, EventArgs e)
        {
            label5.Text = Program.xcash.cashiername;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string id = "";
            string con = Program.xsource;
            SqlConnection cn = new SqlConnection(con);
            bool blnfound = false;

            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from Employees", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["E_Username"].ToString() == label5.Text && label5.Text != "")
                {
                    if (dr["E_Password"].ToString() == textBox1.Text)
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
                textBox3.Text = "";
            }


            else
            {
                try
                {
                     using (var command = Program.xdata.CreateCommand())
                    {
                        command.CommandText = "SELECT E_ID FROM [Employees] where E_Password like '" + textBox1.Text + "'";
                        Program.xdata.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                id = reader["E_ID"].ToString();
                            }
                        }
                    }

                    //con1.Close();
                    dr.Close();
                    cn.Close();
                    if (textBox2.Text == textBox3.Text)
                    {
                        string q1 = Program.xsource;
                        SqlConnection cn11 = new SqlConnection(q1);
                        SqlCommand cmd11 = new SqlCommand("UPDATE [Employees] SET E_Password=@textBox2 WHERE E_ID = '" + id + "'", cn11);
                        cmd11.Parameters.AddWithValue("@textBox2", textBox2.Text);
                        cn11.Open();
                        SqlDataReader dr11 = cmd11.ExecuteReader();


                        MessageBox.Show("Your data has been altered successfully");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Your data don't match");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                    }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

                Program.xdata.Close();
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            this.Hide();
        }
    }
}
