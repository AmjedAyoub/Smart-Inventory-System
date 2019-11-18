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
using System.Data.Odbc;
using System.Configuration;

namespace GraduationProjectTest
{
    public partial class closingcash : Form
    {
        string date = DateTime.Today.ToShortDateString();
        DateTime d = DateTime.Now;
       public double buy = 0.0;
       public double bill = 0.0;
       public double visa = 0.0;
        public double with = 0.0;
        double total = 0.0;
        public closingcash()
        {
            InitializeComponent();
        }

        private void closingcash_Load(object sender, EventArgs e)
        {

        }
        public void close()
        {
            
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Buy] where B_date like '" + date + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);

                // con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT Buy_Price FROM [Buy] where B_date like '" + date + "'";
                // con1.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        buy = double.Parse(reader["Buy_Price"].ToString()) + buy;
                    }
                }
            }
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Billing] where B_date like '" + date + "'", Program.xdata);
               // Program.xdata.Open();
                SDA.Fill(dt);

                // con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT B_Netamount FROM [Billing] where B_date like '" + date + "'";
                // con1.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bill = double.Parse(reader["B_Netamount"].ToString()) + bill;
                    }
                }
            }
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Visa] where B_date like '" + date + "'", Program.xdata);
                // Program.xdata.Open();
                SDA.Fill(dt);

                // con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT B_Amount FROM [Visa] where B_date like '" + date + "'";
                // con1.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        visa = double.Parse(reader["B_Amount"].ToString()) + visa;
                    }
                }
            }
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [dailywith]", Program.xdata);
                // Program.xdata.Open();
                SDA.Fill(dt);

                // con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT emp_with FROM [dailywith]";
                // con1.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        with = double.Parse(reader["emp_with"].ToString()) + with;
                    }
                }
            }
            Program.xdata.Close();
            total = bill - buy - visa - with;
            richTextBox1.Text = "        REPORT OF THE DAY" + "\n" + "\n" + "           " + d + "\n" + "\n" + "Cashier :    " + Program.xcash.cashiername + "\n" + "\n" + "\n" + "\n" + "Sales :                    " + bill + "\n" + "Buying :                   " + buy + "\n" + "Visa :                      " + visa + "\n" + "Emp Withdraw :      " + with + "\n" + "__________________________" + "\n" + "TOTAL :                   " + total;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            total = 0.0;
            bill = 0.0;
            buy = 0.0;
            visa = 0.0;
            with = 0.0;
            string q1 = Program.xsource;
            SqlConnection cn1 = new SqlConnection(q1);
            SqlCommand cmd1 = new SqlCommand("DELETE FROM [dailywith] where num="+"1", cn1);
            cn1.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            Program.closecashe = true;
            Program.xcash.disable();
            this.Hide();
            richTextBox1.Clear();
            /*
             * code print here
             */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            this.Hide();
        }
    }
}
