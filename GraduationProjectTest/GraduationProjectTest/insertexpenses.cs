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
    public partial class insertexpenses : Form
    {
        public insertexpenses()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string theDate = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            textBox3.Text = theDate.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string q1 = Program.xsource;
            SqlConnection cn1 = new SqlConnection(q1);
            SqlCommand cmd1 = new SqlCommand("INSERT INTO [expenses](type, date, amount)VALUES (@textBox1, @textBox3, @textBox2)", cn1);
            cmd1.Parameters.AddWithValue("@textBox1", textBox1.Text);
            cmd1.Parameters.AddWithValue("@textBox2", textBox2.Text);
            cmd1.Parameters.AddWithValue("@textBox3", textBox3.Text);
            cn1.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            MessageBox.Show("Your data has been saved successfully");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
