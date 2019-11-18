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
    public partial class cashkeybourd : Form
    {
        
       // Cash obj = new Cash();
        public double bill;
        public double Reminder;
        public cashkeybourd()
        {
            InitializeComponent();
            
        }
        public void display_bill()
        {
            
            textBox4.Text = bill.ToString();
        }

        public void cashkeybourd_Load(object sender, EventArgs e)
        {

            this.Opacity = .9;
            textBox4.Text = bill.ToString();
        }

      

        private void seven_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "7";
        }

        private void eight_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "8";
        }

        private void nine_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "9";
        }

        private void four_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "4";
        }

        private void five_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "5";
        }

        private void six_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "6";
        }

        private void one_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "1";
        }

        private void two_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "2";
        }

        private void three_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "3";
        }

        private void zero_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + "0";
        }

        private void fasleh_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text + ".";
        }

        private void cls_Click(object sender, EventArgs e)
        {
            textBox5.Clear();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            string num2 = textBox4.Text;
            string num1 = textBox5.Text;
            double x = double.Parse(num1);
            double y = double.Parse(num2);
            string res = (x - y).ToString();
            textBox6.Text = res;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
                MessageBox.Show("Please press the calculate button");
            Program.xcash.save_cash();
            Reminder = double.Parse(textBox6.Text);
            Program.xcash.display_reminder();
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            this.Hide();
        }

        private void cashkeybourd_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
       

        

        
        

       
    }
}
