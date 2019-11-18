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
    public partial class monthlyprofit : Form
    {
        public double fprice = 0.0;
        public double lprice = 0.0;
        public double sales = 0.0;
        public double buy = 0.0;
        public double expenses = 0.0;
         

        public monthlyprofit()
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        int date = DateTime.Now.Year;
    
        DateTime lastDay;
        DateTime firstday;
        string date2 = "";
        string date1 = "";
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            sales = 0.0;
            buy = 0.0;
            expenses = 0.0;
            lprice = 0.0;
            fprice = 0.0;
            if (comboBox1.SelectedIndex == 0)
            {
                lastDay = new DateTime(DateTime.Now.Year, 01, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                firstday = new DateTime(DateTime.Now.Year, 01, 1);
                date2 = lastDay.ToShortDateString();
                date1 = firstday.ToShortDateString(); 
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                lastDay = new DateTime(DateTime.Now.Year, 02, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                firstday = new DateTime(DateTime.Now.Year, 02, 1);
                date2 = lastDay.ToShortDateString();
                date1 = firstday.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                lastDay = new DateTime(DateTime.Now.Year, 03, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                firstday = new DateTime(DateTime.Now.Year, 03, 1);
                date2 = lastDay.ToShortDateString();
                date1 = firstday.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                lastDay = new DateTime(DateTime.Now.Year, 04, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                firstday = new DateTime(DateTime.Now.Year, 04, 1);
                date2 = lastDay.ToShortDateString();
                date1 = firstday.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                lastDay = new DateTime(DateTime.Now.Year, 05, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                firstday = new DateTime(DateTime.Now.Year, 05, 1);
                date2 = lastDay.ToShortDateString();
                date1 = firstday.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                lastDay = new DateTime(DateTime.Now.Year, 06, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                firstday = new DateTime(DateTime.Now.Year, 06, 1);
                date2 = lastDay.ToShortDateString();
                date1 = firstday.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                lastDay = new DateTime(DateTime.Now.Year, 07, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                firstday = new DateTime(DateTime.Now.Year, 07, 1);
                date2 = lastDay.ToShortDateString();
                date1 = firstday.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 7)
            {
                lastDay = new DateTime(DateTime.Now.Year, 08, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                firstday = new DateTime(DateTime.Now.Year, 08, 1);
                date2 = lastDay.ToShortDateString();
                date1 = firstday.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 8)
            {
                lastDay = new DateTime(DateTime.Now.Year, 09, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                firstday = new DateTime(DateTime.Now.Year, 09, 1);
                date2 = lastDay.ToShortDateString();
                date1 = firstday.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 9)
            {
                lastDay = new DateTime(DateTime.Now.Year, 10, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                firstday = new DateTime(DateTime.Now.Year, 10, 1);
                date2 = lastDay.ToShortDateString();
                date1 = firstday.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 10)
            {
                lastDay = new DateTime(DateTime.Now.Year, 11, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                firstday = new DateTime(DateTime.Now.Year, 11, 1);
                date2 = lastDay.ToShortDateString();
                date1 = firstday.ToShortDateString();
            }
            else if (comboBox1.SelectedIndex == 11)
            {
                lastDay = new DateTime(DateTime.Now.Year, 12, 1);
                lastDay = lastDay.AddMonths(1);

                lastDay = lastDay.AddDays(-(lastDay.Day));
                firstday = new DateTime(DateTime.Now.Year, 12, 1);
                date2 = lastDay.ToShortDateString();
                date1 = firstday.ToShortDateString();
            }
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Billing] where B_Date >= '" + date1 + "'" + "AND B_Date <= '" + date2 + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Billing] where B_Date >= '" + date1 + "'" + "AND B_Date <= '" + date2 + "'";
                //  Program.xdata.Open();
                
                using (var reader = command.ExecuteReader())
                {
                    
                        while (reader.Read())
                        {
                            sales = double.Parse(reader["B_Netamount"].ToString())+sales;
                        }
                }
            }
            Program.xdata.Close();
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Buy] where B_date >= '" + date1 + "'" + "AND B_date <= '" + date2 + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Buy] where B_date >= '" + date1 + "'" + "AND B_date <= '" + date2 + "'";
                //  Program.xdata.Open();
              
                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        buy = double.Parse(reader["Buy_Price"].ToString()) + buy;
                    }
                }
            }
            Program.xdata.Close();
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [expenses] where date >= '" + date1 + "'" + "AND date <= '" + date2 + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [expenses] where date >= '" + date1 + "'" + "AND date <= '" + date2 + "'";
                //  Program.xdata.Open();
               
                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        expenses = double.Parse(reader["amount"].ToString()) + expenses;
                    }
                }
            }
            Program.xdata.Close();
            ret1();
            ret2();
            gross();
        }

        public void ret1()
        {
            Boolean a = false;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [inventory] where date like '" + date1 + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            double q = 0.0;
            double p = 0.0;
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [inventory] where date like '" + date1 + "'";
                //  Program.xdata.Open();
              
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        q = double.Parse(reader["i_quantity"].ToString());
                        p = double.Parse(reader["i_wholeprice"].ToString());
                        fprice = q * p;
                        a = true;
                    }
                    Program.xdata.Close();
                }
            }
            if (!a && firstday.Day !=lastDay.Day && firstday.Month==lastDay.Month)
            {
                firstday = firstday.AddDays(1);
                date1 = firstday.ToShortDateString();
                ret1();
            }
        }

        public void ret2()
        {
             Boolean a = false;

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [inventory] where date like '" + date2 + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            double q = 0.0;
            double p = 0.0;
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [inventory] where date like '" + date2+ "'";
                //  Program.xdata.Open();
              
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        q = double.Parse(reader["i_quantity"].ToString());
                        p = double.Parse(reader["i_wholeprice"].ToString());
                        lprice = q * p;
                        a = true;
                    }
                    Program.xdata.Close();
                }
                 }
            if (!a && lastDay.Day != 1 && firstday.Month == lastDay.Month)
            {
                lastDay = lastDay.AddDays(-1);
                date2 = lastDay.ToShortDateString();
                ret2();
            }
        }

        public void gross()
        {
            textBox1.Text = (sales - (fprice + buy - lprice)).ToString();
            net();
        }

        public void net()
        {
            textBox2.Text = (double.Parse(textBox1.Text) - expenses).ToString();
        }

        private void monthlyprofit_Load(object sender, EventArgs e)
        {

        }






     }
    
}
