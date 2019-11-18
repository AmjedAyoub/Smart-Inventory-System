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
    public partial class insertpassword : Form
    {
        public insertpassword()
        {
            InitializeComponent();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string con = Program.xsource;
                SqlConnection cn = new SqlConnection(con);
            bool blnfound = false;

            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from Employees", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["E_Username"].ToString() == label2.Text && label2.Text != "")
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
            }


            else
            {
                try
                {
                     DataTable dt = new DataTable();
                     using (var command = Program.xdata.CreateCommand())
                    {
                        command.CommandText = "SELECT E_Firstname FROM [Employees] where E_Password like '" + textBox1.Text + "'";

                        Program.xdata.Open();

                    }

                     Program.xdata.Close();
                    dr.Close();
                    cn.Close();
                    textBox1.Text = "";
   //**************************************************************************************************
                    //the
                    //code
                    //to open
                    //the
                    //cash
 //**************************************************************************************************                  
                    this.Hide();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }

        }

        private void insertpassword_Load(object sender, EventArgs e)
        {
            label2.Text = Program.xcash.cashiername;
        }
        
    }
}
