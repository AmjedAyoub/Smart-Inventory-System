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
    public partial class monthlyinventory : Form
    {
        public monthlyinventory()
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

        private void monthlyinventory_Load(object sender, EventArgs e)
        {

        }
        int date = DateTime.Now.Year;
       
        DateTime lastDay;
        string n = "";
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
             DateTimeFormatInfo dfi = new DateTimeFormatInfo();
            if (comboBox1.SelectedIndex == 0)
            {
               lastDay = new DateTime(DateTime.Now.Year, 01, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                n = lastDay.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
              lastDay = new DateTime(DateTime.Now.Year, 02, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                n = lastDay.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                 lastDay = new DateTime(DateTime.Now.Year, 03, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                n = lastDay.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 3)
            {

                lastDay = new DateTime(DateTime.Now.Year, 04, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                n = lastDay.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                lastDay = new DateTime(DateTime.Now.Year, 05, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                n = lastDay.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                lastDay = new DateTime(DateTime.Now.Year, 06, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                n = lastDay.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                lastDay = new DateTime(DateTime.Now.Year, 07, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                n = lastDay.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 7)
            {
                lastDay = new DateTime(DateTime.Now.Year, 08, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                n = lastDay.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 8)
            {
                lastDay = new DateTime(DateTime.Now.Year, 09, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                n = lastDay.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 9)
            {
                lastDay = new DateTime(DateTime.Now.Year, 10, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                n = lastDay.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 10)
            {
                lastDay = new DateTime(DateTime.Now.Year, 11, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                n = lastDay.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 11)
            {
                lastDay = new DateTime(DateTime.Now.Year, 12, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                n = lastDay.ToShortDateString();
            }
            ret();
                
            
        }
        public void ret()
        {
            Boolean a=false;
           
                try
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [inventory] where date like '" + n + "'", Program.xdata);
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
                    command.CommandText = "SELECT * FROM [inventory] where date like '" + n + "'";
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
                if (!a && lastDay.Day!=1)
                {
                    lastDay = lastDay.AddDays(-1);
                    n = lastDay.ToShortDateString();
                     ret();
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
