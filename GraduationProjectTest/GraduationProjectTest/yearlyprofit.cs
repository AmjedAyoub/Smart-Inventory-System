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
    public partial class yearlyprofit : Form
    {
        public double fprice = 0.0;
        public double lprice = 0.0;
        public double sales = 0.0;
        public double buy = 0.0;
        public double expenses = 0.0;
        public yearlyprofit()
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
            textBox1.Text = "";
            textBox2.Text = "";
            sales = 0.0;
            buy = 0.0;
            expenses = 0.0;
            lprice = 0.0;
            fprice = 0.0;
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
                        sales = double.Parse(reader["B_Netamount"].ToString()) + sales;
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
            if (!a && firstday.Year == lastDay.Year)
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
                command.CommandText = "SELECT * FROM [inventory] where date like '" + date2 + "'";
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
            if (!a && firstday.Month == lastDay.Month)
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

        
    }
}
