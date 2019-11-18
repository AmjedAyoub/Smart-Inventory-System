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
    public partial class showsuggestedoffers : Form
    {
        string id1 = "";
        string id2 = "";
        public showsuggestedoffers()
        {
            InitializeComponent();
        }

        private void showsuggestedoffers_Load(object sender, EventArgs e)
        {

        }
        public void off(string item1, string item2,Boolean a)
        {
            string name = "";
            string name2 = "";
            string expiry = "";
            string wprice = "";
            string sprice = "";
            string wprice2 = "";
            string sprice2 = "";
            DateTime date = DateTime.Now;

            try
            {
                DataTable dt1 = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] where I_Name like '"+item1+"'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt1);

                // Program.xdata.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            try
            {
                using (var command = Program.xdata.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [Items] where I_Name like '"+item1+"'";
                    // Program.xdata.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            name = reader["I_Name"].ToString();
                            expiry = reader["I_Expirydate"].ToString();
                            wprice = reader["I_Wholesaleprice"].ToString();
                            sprice = reader["I_sellingprice"].ToString();
                        }
                    }
                Program.xdata.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            try
            {
                DataTable dt1 = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] where I_Name like '"+item2+"'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt1);

                // Program.xdata.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            try
            {
                using (var command = Program.xdata.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [Items] where I_Name like '" + item2 + "'";
                    // Program.xdata.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            name2 = reader["I_Name"].ToString();
                            wprice2 = reader["I_Wholesaleprice"].ToString();
                            sprice2 = reader["I_sellingprice"].ToString();
                        }
                    }
                    Program.xdata.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            textBox1.Text = name;
            textBox2.Text = name2;
            textBox3.Text = "1";
            textBox4.Text = "2";
            textBox7.Text = "25";
            textBox8.Text = ((double.Parse(sprice) * 2) + (double.Parse(sprice2))).ToString();
            textBox9.Text = ((((double.Parse(wprice) * 2) + (double.Parse(wprice2))) * 0.25) + ((double.Parse(wprice) * 2) + (double.Parse(wprice2)))).ToString();
            if (!a)
            {
                dateTimePicker2.Enabled = false;
                textBox11.Enabled = false;
                textBox11.Text = DateTime.Parse(expiry).AddDays(-1).ToShortDateString();
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox11.Enabled = true;
            dateTimePicker2.Enabled = true;
            Program.xmanager.sugg2();

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string theDate1 = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            textBox10.Text = theDate1.ToString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string theDate1 = dateTimePicker2.Value.ToString("MM/dd/yyyy");
            textBox11.Text = theDate1.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] where I_Name like '" + textBox1.Text + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Items] where I_Name like '" + textBox1.Text + "'";
                // con1.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id2 = reader["I_ID"].ToString();
                    }
                }
            } try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] where I_Name like '" + textBox2.Text + "'", Program.xdata);
               // Program.xdata.Open();
                SDA.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Items] where I_Name like '" + textBox2.Text + "'";
                // con1.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id1 = reader["I_ID"].ToString();
                    }
                }
            }

            Program.xdata.Close();
            string ids = id1 + " " + id2;
            string quan = textBox3.Text + " " + textBox4.Text;
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

            Program.xoffer.create(textBox6.Text, textBox10.Text, textBox11.Text);
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();

            MessageBox.Show("Your data has been saved successfully");
        }
    }
}
