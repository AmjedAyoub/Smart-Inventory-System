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
    public partial class salesChart : Form
    {
        public salesChart()
        {
            InitializeComponent();
        }

        private void salesChart_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet7.Sales' table. You can move, or remove it, as needed.
            this.salesTableAdapter.Fill(this.database1DataSet7.Sales);

        }

        private void chart1_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.Minimum = 0;

        }
    }
}
