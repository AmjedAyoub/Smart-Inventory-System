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
    public partial class manyearlysales : Form
    {
        public manyearlysales()
        {
            InitializeComponent();
            comboBox1.Items.Add("2012");
            comboBox1.Items.Add("2013");
            comboBox1.Items.Add("2014");
            comboBox1.Items.Add("2015");
            comboBox1.Items.Add("2016");
        }

        private void manyearlysales_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet6.Sales' table. You can move, or remove it, as needed.
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SalesTableAdapter.Fill(this.DataSet6.Sales,comboBox1.SelectedIndex);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
