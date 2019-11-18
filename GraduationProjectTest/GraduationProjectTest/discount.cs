using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraduationProjectTest
{
    public partial class discount : Form
    {
         public double disbill;
        public double disReminder;
        public discount()
        {
            InitializeComponent();
        }

        public void display_bill()
        {

            textBox4.Text = disbill.ToString();
        }

        private void discount_Load(object sender, EventArgs e)
        {
            this.Opacity = .9;
            textBox4.Text = disbill.ToString();
        }
        public double total;
        private void button28_Click_1(object sender, EventArgs e)
        {
            string num2 = textBox4.Text;
            string num1 = textBox1.Text;
            double x = double.Parse(num1);
            double y = double.Parse(num2);
            string res;
            if (label2.Text == "%")
            {
                total = y * b;
                res = (y - (y * b)).ToString();
                textBox6.Text = res;
            }
            else
            {
                total =  x;
                res = (y - x).ToString();
                textBox6.Text = res;
            }
        }

        private void button29_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
                MessageBox.Show("Please press the calculate button");
            if (double.Parse(textBox6.Text) < 0)
            {
                MessageBox.Show("Incorrect discount the total is negative");
            }
            else
            {
                disReminder = double.Parse(textBox6.Text);
                Program.xcash.dis_reminder(textBox1.Text, label2.Text, total);
                textBox4.Text = "";
                textBox1.Text = "";
                textBox6.Text = "";
                label2.Text = "";
                this.Hide();
            }
        }
        double b;
        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "%";
            string r=textBox1.Text;
            double c = double.Parse(r);
            b = c / 100;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "JD";
        }

        private void nine_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "9";
        }

        private void eight_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "8";
        }

        private void seven_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "7";
        }

        private void six_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "6";
        }

        private void five_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "5";
        }

        private void four_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "4";
        }

        private void three_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "3";
        }

        private void two_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "2";
        }

        private void one_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "1";
        }

        private void zero_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "0";
        }

        private void fasleh_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + ".";
        }

        private void cls_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

       

       

       
    }
}
