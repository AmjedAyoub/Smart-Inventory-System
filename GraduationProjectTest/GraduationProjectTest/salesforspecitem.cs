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
    public partial class salesforspecitem : Form
    {

        
        public salesforspecitem()
        {
            InitializeComponent();
        }

        private void salesforspecitem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet4.Sales' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'database1DataSet10.Items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter1.Fill(this.database1DataSet10.Items);
            // TODO: This line of code loads data into the 'DataSet4.Sales' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'database1DataSet4.Items' table. You can move, or remove it, as needed.
           

            
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SalesTableAdapter.Fill(this.DataSet4.Sales, comboBox2.Text);
            this.reportViewer1.RefreshReport();
        }

       
    }
}
