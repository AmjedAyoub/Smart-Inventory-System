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
    public partial class additem : Form
    {
        public additem()
        {
            InitializeComponent();
            typecomboBox1.Items.Add("Liquid");
            typecomboBox1.Items.Add("Solid");
            typecomboBox1.Items.Add("Gas");
            unitcomboBox2.Items.Add("Gram");
            unitcomboBox2.Items.Add("Kilogram");
            unitcomboBox2.Items.Add("Liter");
            unitcomboBox2.Items.Add("mL");
            unitcomboBox2.Items.Add("piece");
        }

        private void additem_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string q2 = Program.xsource;
            SqlConnection cn2 = new SqlConnection(q2);
            SqlCommand cmd2 = new SqlCommand("INSERT INTO [Items](I_Name,I_Company,I_Type,I_Quantity,I_Expirydate,I_Unit,I_Wholesaleprice,I_Tax,I_sellingprice,I_Date,I_Minvalue)VALUES (@textBox6,@textBox7,@typecomboBox1,@textBox2,@textBox1,@unitcomboBox2,@textBox5,@textBox4,@textBox3,@textBox8,@textBox9)", cn2);
            cmd2.Parameters.AddWithValue("@textBox6", textBox6.Text);
            cmd2.Parameters.AddWithValue("@textBox7", textBox7.Text);
            cmd2.Parameters.AddWithValue("@typecomboBox1", typecomboBox1.SelectedText);
            cmd2.Parameters.AddWithValue("@textBox2", textBox2.Text);
            cmd2.Parameters.AddWithValue("@textBox1", textBox1.Text);
            cmd2.Parameters.AddWithValue("@unitcomboBox2", unitcomboBox2.SelectedText);
            cmd2.Parameters.AddWithValue("@textBox5", textBox5.Text);
            cmd2.Parameters.AddWithValue("@textBox4", textBox4.Text);
            cmd2.Parameters.AddWithValue("@textBox3", textBox3.Text);
            cmd2.Parameters.AddWithValue("@textBox8", textBox8.Text);
            cmd2.Parameters.AddWithValue("@textBox9", textBox9.Text);
            cn2.Open();
            SqlDataReader dr2 = cmd2.ExecuteReader();
            MessageBox.Show("Your data has been saved successfully");
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox1.Clear();
            textBox2.Clear();
            unitcomboBox2.Text = " ";
            typecomboBox1.Text = " ";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string theDate1 = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            textBox1.Text = theDate1.ToString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string theDate2 = dateTimePicker2.Value.ToString("MM/dd/yyyy");
            textBox8.Text = theDate2.ToString();
        }
    }
}
