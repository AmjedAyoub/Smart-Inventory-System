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
using System.Configuration;
using System.Globalization;

namespace GraduationProjectTest
{
    public partial class yearlyinventory : Form
    {
        public yearlyinventory()
        {
            InitializeComponent();
            comboBox1.Items.Add("2012");
            comboBox1.Items.Add("2013");
            comboBox1.Items.Add("2014");
            comboBox1.Items.Add("2015");
            comboBox1.Items.Add("2016");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        DateTime lastDay;
        DateTime firstday;
        string date2 = "";
        string date1 = "";

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (comboBox1.SelectedIndex == 0)
            {
                lastDay = new DateTime(2012, 12, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                firstday = new DateTime(2012, 01, 1);
                date2 = lastDay.ToShortDateString();
                date1 = firstday.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                lastDay = new DateTime(2013, 12, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                firstday = new DateTime(2013, 01, 1);
                date2 = lastDay.ToShortDateString();
                date1 = firstday.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                lastDay = new DateTime(2014, 12, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                firstday = new DateTime(2014, 01, 1);
                date2 = lastDay.ToShortDateString();
                date1 = firstday.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                lastDay = new DateTime(2015, 12, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                firstday = new DateTime(2015, 01, 1);
                date2 = lastDay.ToShortDateString();
                date1 = firstday.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                lastDay = new DateTime(2016, 12, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                firstday = new DateTime(2016, 01, 1);
                date2 = lastDay.ToShortDateString();
                date1 = firstday.ToShortDateString();
            }
            ret1();
        }

        public void ret1()
        {
            Boolean a = false;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [inventory] where date > '" + date1 + "'" + "AND date < '" + date2 + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            double q = 0.0;
            double p = 0.0;
            double price = 0.0;
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [inventory] where date like '" + date2 + "'";
                //  Program.xdata.Open();
                int x = 0;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        q = double.Parse(reader["i_quantity"].ToString());
                        p = double.Parse(reader["i_wholeprice"].ToString());
                        price = q * p;
                        dataGridView1.Rows.Insert(x, reader["i_name"], reader["i_quantity"], price);
                        x++;
                        a = true;
                    }
                    Program.xdata.Close();
                }
            }
            if (!a && lastDay != firstday)
            {
                lastDay = lastDay.AddDays(-1);
                date2 = lastDay.ToShortDateString();
                ret1();
            }

        }

        private void yearlyinventory_Load(object sender, EventArgs e)
        {

        }










    }
}
