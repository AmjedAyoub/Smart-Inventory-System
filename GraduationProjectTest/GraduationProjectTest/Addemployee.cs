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
    public partial class Addemployee : Form
    {
        public Addemployee()
        {
            InitializeComponent();
            jobcomboBox1.Items.Add("Manager");
            jobcomboBox1.Items.Add("Accountant");
            jobcomboBox1.Items.Add("Cashier");
            jobcomboBox1.Items.Add("Worker");
            jobcomboBox1.Items.Add("Driver");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void jobcomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Addemployee_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string q1 = Program.xsource;
            SqlConnection cn1 = new SqlConnection(q1);
            SqlCommand cmd1 = new SqlCommand("INSERT INTO [Employees](E_Firstname, E_Lastname, E_Hiredate, E_Email, E_Contactnum, E_Job, E_Sallary)VALUES (@textBox1, @textBox6, @textBox2, @textBox5 , @textBox4 , @jobcomboBox1 , @textBox3)",cn1);
            cmd1.Parameters.AddWithValue("@textBox1", textBox1.Text);
            cmd1.Parameters.AddWithValue("@textBox6", textBox6.Text);
            cmd1.Parameters.AddWithValue("@textBox2", textBox2.Text);
            cmd1.Parameters.AddWithValue("@textBox5", textBox5.Text);
            cmd1.Parameters.AddWithValue("@textBox4", textBox4.Text);
            cmd1.Parameters.AddWithValue("@jobcomboBox1", jobcomboBox1.Text);
            cmd1.Parameters.AddWithValue("@textBox3", textBox3.Text);
            cn1.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            MessageBox.Show("Your data has been saved successfully");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            jobcomboBox1.Text = " ";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string theDate = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            textBox2.Text = theDate.ToString();

        }       
    }
}
