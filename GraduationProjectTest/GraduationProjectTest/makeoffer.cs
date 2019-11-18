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

namespace GraduationProjectTest
{
    public partial class makeoffer : Form
    {
        public string id1 = "";
        public string id2 = "";
        public string id3 = "";
        public string id4 = "";
        public string id5 = "";
        public string wp1 = "";
        public string wp2 = "";
        public string wp3 = "";
        public string wp4 = "";
        public string wp5 = "";
        public string sp1 = "";
        public string sp2 = "";
        public string sp3 = "";
        public string sp4 = "";
        public string sp5 = "";
        public double before = 0.0;
        public double after = 0.0;

        public makeoffer()
        {
            InitializeComponent();
           
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string theDate = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            textBox10.Text = theDate.ToString();
        }

        private void makeoffer_Load(object sender, EventArgs e)
        {
           
            // TODO: This line of code loads data into the 'database1DataSet15.Items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter5.Fill(this.database1DataSet15.Items);
            // TODO: This line of code loads data into the 'database1DataSet14.Items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter4.Fill(this.database1DataSet14.Items);
            // TODO: This line of code loads data into the 'database1DataSet13.Items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter3.Fill(this.database1DataSet13.Items);
            // TODO: This line of code loads data into the 'database1DataSet12.Items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter2.Fill(this.database1DataSet12.Items);
            // TODO: This line of code loads data into the 'database1DataSet11.Items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter1.Fill(this.database1DataSet11.Items);
            // TODO: This line of code loads data into the 'database1DataSet6.Items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter.Fill(this.database1DataSet6.Items);
            comboBox1.Text = "select";
            comboBox2.Text = "select";
            comboBox3.Text = "select";
            comboBox4.Text = "select";
            comboBox5.Text = "select";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] where I_Name like '" + comboBox1.Text + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT I_ID,I_Name,I_Company,I_Type,I_Quantity,I_Expirydate,I_Unit,I_Wholesaleprice,I_Tax,I_Sellingprice,I_Date FROM [Items] where I_Name like '" + comboBox1.Text + "'";
                // con1.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id1 = reader["I_ID"].ToString();
                        wp1 = reader["I_Wholesaleprice"].ToString();
                        sp1 = reader["I_Sellingprice"].ToString();
                    }
                }
            }

            Program.xdata.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] where I_Name like '" + comboBox2.Text + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT I_ID,I_Name,I_Company,I_Type,I_Quantity,I_Expirydate,I_Unit,I_Wholesaleprice,I_Tax,I_Sellingprice,I_Date FROM [Items] where I_Name like '" + comboBox2.Text + "'";
                // con1.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id2 = reader["I_ID"].ToString();
                        wp2 = reader["I_Wholesaleprice"].ToString();
                        sp2 = reader["I_Sellingprice"].ToString();
                    }
                }
            }

            Program.xdata.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] where I_Name like '" + comboBox3.Text + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT I_ID,I_Name,I_Company,I_Type,I_Quantity,I_Expirydate,I_Unit,I_Wholesaleprice,I_Tax,I_Sellingprice,I_Date FROM [Items] where I_Name like '" + comboBox3.Text + "'";
                // con1.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id3 = reader["I_ID"].ToString();
                        wp3 = reader["I_Wholesaleprice"].ToString();
                        sp3 = reader["I_Sellingprice"].ToString();
                    }
                }
            }

            Program.xdata.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] where I_Name like '" + comboBox4.Text + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT I_ID,I_Name,I_Company,I_Type,I_Quantity,I_Expirydate,I_Unit,I_Wholesaleprice,I_Tax,I_Sellingprice,I_Date FROM [Items] where I_Name like '" + comboBox4.Text + "'";
                // con1.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id4 = reader["I_ID"].ToString();
                        wp4 = reader["I_Wholesaleprice"].ToString();
                        sp4 = reader["I_Sellingprice"].ToString();
                    }
                }
            }

            Program.xdata.Close();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] where I_Name like '" + comboBox5.Text + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT I_ID,I_Name,I_Company,I_Type,I_Quantity,I_Expirydate,I_Unit,I_Wholesaleprice,I_Tax,I_Sellingprice,I_Date FROM [Items] where I_Name like '" + comboBox5.Text + "'";
                // con1.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id5 = reader["I_ID"].ToString();
                        wp5 = reader["I_Wholesaleprice"].ToString();
                        sp5 = reader["I_Sellingprice"].ToString();
                    }
                }
            }

            Program.xdata.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            double b1 = 0.0;
            double b2 = 0.0;
            double b3 = 0.0;
            double b4 = 0.0;
            double b5 = 0.0;
            double a1 = 0.0;
            double a2 = 0.0;
            double a3 = 0.0;
            double a4 = 0.0;
            double a5 = 0.0;

             if (textBox1.Text != "" && textBox1.Text!="select")
            {
                b1 = (double.Parse(textBox1.Text) * double.Parse(sp1));
                a1 = (double.Parse(textBox1.Text) * double.Parse(wp1));
            }
             if (textBox2.Text != "" && textBox2.Text != "select")
            {
                b2 = (double.Parse(textBox2.Text) * double.Parse(sp2)) ;
                a2 = (double.Parse(textBox2.Text) * double.Parse(wp2));
            }
             if (textBox3.Text != "" && textBox3.Text != "select")
            {
                b3 = (double.Parse(textBox3.Text) * double.Parse(sp3)) ;
                a3 = (double.Parse(textBox3.Text) * double.Parse(wp3));
            }
             if (textBox4.Text != "" && textBox4.Text != "select")
            {
                b4 = (double.Parse(textBox4.Text) * double.Parse(sp4)) ;
                a4 = (double.Parse(textBox4.Text) * double.Parse(wp4));
            }
             if (textBox5.Text != "" && textBox5.Text != "select")
            {
                b5 = (double.Parse(textBox5.Text) * double.Parse(sp5)) ;
                a5 = (double.Parse(textBox5.Text) * double.Parse(wp5));
            }

             textBox8.Text = b1 + b2 + b3 + b4 + b5 + "";
             textBox9.Text = ((double.Parse(textBox7.Text) / 100) * (a1 + a2 + a3 + a4 + a5) + (a1 + a2 + a3 + a4 + a5)).ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ids = id1 + " " + id2 + " " + id3 + " " + id4 + " " + id5;
            string quan = textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + " " + textBox4.Text + " " + textBox5.Text;
            string q2 = Program.xsource;
            SqlConnection cn2 = new SqlConnection(q2);
            SqlCommand cmd2 = new SqlCommand("INSERT INTO [Offers](O_Name,O_Startdate,O_Enddate,O_Quantity,O_Netprofit,items)VALUES (@textBox6,@textBox10,@textBox11,@quan,@textBox9,@ids)", cn2);
            cmd2.Parameters.AddWithValue("@textBox10", textBox10.Text);
            cmd2.Parameters.AddWithValue("@textBox9", textBox9.Text);
            cmd2.Parameters.AddWithValue("@textBox11", textBox11.Text);
            cmd2.Parameters.AddWithValue("@quan", quan);
            cmd2.Parameters.AddWithValue("@ids", ids);
            cmd2.Parameters.AddWithValue("@textBox6", textBox6.Text);
            cn2.Open();
            SqlDataReader dr2 = cmd2.ExecuteReader();

            Program.xoffer.create(textBox6.Text,textBox10.Text,textBox11.Text);
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            comboBox1.Text = "select";
            comboBox2.Text = "select";
            comboBox3.Text = "select";
            comboBox4.Text = "select";
            comboBox5.Text = "select";

            MessageBox.Show("Your data has been saved successfully");
        }

        private void dateTimePicker2_ValueChanged_1(object sender, EventArgs e)
        {
            string theDate1 = dateTimePicker2.Value.ToString("MM/dd/yyyy");
            textBox11.Text = theDate1.ToString();
        }
    }
}
