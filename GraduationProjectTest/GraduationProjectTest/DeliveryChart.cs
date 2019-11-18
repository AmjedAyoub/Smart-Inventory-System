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
    public partial class DeliveryChart : Form
    {
        public DeliveryChart()
        {
            InitializeComponent();
        }

        private void DeliveryChart_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet9.Delivery' table. You can move, or remove it, as needed.
            this.deliveryTableAdapter.Fill(this.database1DataSet9.Delivery);

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
