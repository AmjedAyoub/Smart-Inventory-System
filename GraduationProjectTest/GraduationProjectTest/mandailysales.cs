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
    public partial class mandailysales : Form
    {
        public mandailysales()
        {
            InitializeComponent();
        }

        private void mandailysales_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet2.Sales' table. You can move, or remove it, as needed.
           
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.MaxSelectionCount = 1;
            // To display single date use MonthCalendar1.SelectionRange.Start/ MonthCalendarSelectionRange.End
            textBox1.Text = monthCalendar1.SelectionRange.Start.ToString("dd/MMMM/yyyy", new System.Globalization.DateTimeFormatInfo());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.SalesTableAdapter.Fill(this.DataSet2.Sales,textBox1.Text);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
