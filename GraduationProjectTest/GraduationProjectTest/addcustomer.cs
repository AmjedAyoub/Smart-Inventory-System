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
    public partial class addcustomer : Form
    {
        public addcustomer()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            string q2 = Program.xsource;
            SqlConnection cn2 = new SqlConnection(q2);
            SqlCommand cmd2 = new SqlCommand("INSERT INTO [Customer](C_FirstName,C_LastName,C_Email,C_Contactnumber,C_City,C_Stname,C_Bildingnum,C_Floor,C_Apartment)VALUES (@textBox1,@textBox6,@textBox5,@textBox4,@textBox2,@textBox8,@textBox7,@textBox3,@textBox9)", cn2);
            cmd2.Parameters.AddWithValue("@textBox1", textBox1.Text);
            cmd2.Parameters.AddWithValue("@textBox6", textBox6.Text);
            cmd2.Parameters.AddWithValue("@textBox5", textBox5.Text);
            cmd2.Parameters.AddWithValue("@textBox4", textBox4.Text);
            cmd2.Parameters.AddWithValue("@textBox2", textBox2.Text);
            cmd2.Parameters.AddWithValue("@textBox8", textBox8.Text);
            cmd2.Parameters.AddWithValue("@textBox7", textBox7.Text);
            cmd2.Parameters.AddWithValue("@textBox3", textBox3.Text);
            cmd2.Parameters.AddWithValue("@textBox9", textBox9.Text);
            cn2.Open();
            SqlDataReader dr2 = cmd2.ExecuteReader();
            MessageBox.Show("Your data has been saved successfully");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();    
        }

        private void addcustomer_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
