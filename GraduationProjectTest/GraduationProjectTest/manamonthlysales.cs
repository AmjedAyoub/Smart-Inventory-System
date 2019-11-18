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
    public partial class manamonthlysales : Form
    {
        public manamonthlysales()
        {
            InitializeComponent();
            comboBox1.Items.Add("January");
            comboBox1.Items.Add("February");
            comboBox1.Items.Add("March");
            comboBox1.Items.Add("April");
            comboBox1.Items.Add("May");
            comboBox1.Items.Add("June");
            comboBox1.Items.Add("July");
            comboBox1.Items.Add("August");
            comboBox1.Items.Add("September");
            comboBox1.Items.Add("October");
            comboBox1.Items.Add("November");
            comboBox1.Items.Add("December");
        }

        private void manamonthlysales_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet5.Sales' table. You can move, or remove it, as needed.
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SalesTableAdapter.Fill(this.DataSet5.Sales,comboBox1.SelectedIndex);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
