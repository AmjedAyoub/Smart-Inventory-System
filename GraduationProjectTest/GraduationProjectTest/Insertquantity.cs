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
    public partial class Insertquantity : Form
    {
        public Insertquantity()
        {
            InitializeComponent();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            this.Hide();
        }

        private void cls_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void zero_Click(object sender, EventArgs e)
        {
            textBox4.Text = textBox4.Text + "0";
        }

        private void one_Click(object sender, EventArgs e)
        {
            textBox4.Text = textBox4.Text + "1";
        }

        private void two_Click(object sender, EventArgs e)
        {
            textBox4.Text = textBox4.Text + "2";
        }

        private void three_Click(object sender, EventArgs e)
        {
            textBox4.Text = textBox4.Text + "3";
        }

        private void four_Click(object sender, EventArgs e)
        {
            textBox4.Text = textBox4.Text + "4";
        }

        private void five_Click(object sender, EventArgs e)
        {
            textBox4.Text = textBox4.Text + "5";
        }

        private void six_Click(object sender, EventArgs e)
        {
            textBox4.Text = textBox4.Text + "6";
        }

        private void seven_Click(object sender, EventArgs e)
        {
            textBox4.Text = textBox4.Text + "7";
        }

        private void eight_Click(object sender, EventArgs e)
        {
            textBox4.Text = textBox4.Text + "8";
        }

        private void nine_Click(object sender, EventArgs e)
        {
            textBox4.Text = textBox4.Text + "9";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {               
                Program.xcash.dataquantity(textBox4.Text);
                textBox4.Text = "";
                this.Hide();
            }
        }
    }
}
