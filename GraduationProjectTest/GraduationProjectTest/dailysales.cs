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
    public partial class dailysales : Form
    {
        public dailysales()
        {
            InitializeComponent();
        }
        public string txt;
        public void dailysales_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.Sales' table. You can move, or remove it, as needed.
           
            monthCalendar1.MaxSelectionCount = 1;
            txt = monthCalendar1.SelectionRange.Start.ToString("dd-MMMM-yyyy", new System.Globalization.DateTimeFormatInfo());
            this.SalesTableAdapter.FillBy(this.DataSet1.Sales, txt);

            this.reportViewer1.RefreshReport();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt = "";
            this.Hide();
        }
    }
}
