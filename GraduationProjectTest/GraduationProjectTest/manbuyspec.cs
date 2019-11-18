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
    public partial class manbuyspec : Form
    {
        public manbuyspec()
        {
            InitializeComponent();
        }

        private void manbuyspec_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet7.Buy' table. You can move, or remove it, as needed.
            
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.MaxSelectionCount = 1;
            // To display single date use MonthCalendar1.SelectionRange.Start/ MonthCalendarSelectionRange.End
            textBox1.Text = monthCalendar1.SelectionRange.Start.ToString("dd/MMMM/yyyy", new System.Globalization.DateTimeFormatInfo());
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar2.MaxSelectionCount = 1;
            // To display single date use MonthCalendar1.SelectionRange.Start/ MonthCalendarSelectionRange.End
            textBox2.Text = monthCalendar2.SelectionRange.Start.ToString("dd/MMMM/yyyy", new System.Globalization.DateTimeFormatInfo());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BuyTableAdapter.Fill(this.DataSet7.Buy,textBox1.Text,textBox2.Text);

            this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
