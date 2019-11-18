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
    public partial class netProfitChart : Form
    {
        public netProfitChart()
        {
            InitializeComponent();
        }

        private void netProfitChart_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet115.Sales' table. You can move, or remove it, as needed.
            this.salesTableAdapter1.Fill(this.database1DataSet115.Sales);
            // TODO: This line of code loads data into the 'database1DataSet8.Sales' table. You can move, or remove it, as needed.
           // this.salesTableAdapter.Fill(this.database1DataSet8.Sales);

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
