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

namespace GraduationProjectTest
{
    public partial class deleteitem : Form
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        public deleteitem()
        {
            InitializeComponent();
            
           
        }
        private string connectionString = Program.xsource;
        private void button4_Click(object sender, EventArgs e)
        {
            string q1 = Program.xsource;
                SqlConnection cn1 = new SqlConnection(q1);
            SqlCommand cmd1 = new SqlCommand("DELETE FROM [Items] WHERE I_ID = '" + textBox3.Text + "'", cn1);
            cn1.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            MessageBox.Show("Your data has been altered successfully");

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox10.Clear();
            textBox7.Clear();
            textBox6.Clear();
            textBox8.Clear();
            comboBox1.Text = " "; 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string q1 = Program.xsource;
                SqlConnection cn1 = new SqlConnection(q1);
           
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn1;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [Items] where I_Name like '" + textBox1.Text + "%" + "'";
            cn1.Open();
            using (var command = cn1.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Items] where I_Name like '" + textBox1.Text + "%" + "'";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        namesCollection.Add(reader["I_Name"].ToString() );

                    }
                }
            }
            cn1.Close();
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteCustomSource = namesCollection;


        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = ""; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                 DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] where I_Name like '" + textBox1.Text + "'", Program.xdata);
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
                command.CommandText = "SELECT I_ID, I_Name, I_Company,I_Quantity, I_Wholesaleprice FROM [Items] where I_Name like '" + textBox1.Text + "'";
               // con1.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textBox3.Text = reader["I_ID"].ToString();
                        textBox10.Text = reader["I_Name"].ToString();
                        textBox7.Text = reader["I_Company"].ToString();
                        textBox6.Text = reader["I_Quantity"].ToString();
                        textBox8.Text = reader["I_Wholesaleprice"].ToString();
                        


                    }
                }




            }

             Program.xdata.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                  DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] where I_Company like '" + textBox2.Text + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);

              //  con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
             using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT I_ID, I_Name, I_Company,I_Quantity, I_Wholesaleprice FROM [Items] where I_Name like '" + textBox1.Text + "'";
               // con1.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textBox3.Text = reader["I_ID"].ToString();
                        textBox10.Text = reader["I_Name"].ToString();
                        textBox7.Text = reader["I_Company"].ToString();
                        textBox6.Text = reader["I_Quantity"].ToString();
                        textBox8.Text = reader["I_Wholesaleprice"].ToString();



                    }
                }




            }

             Program.xdata.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide(); 
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { 
            

            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT I_ID,I_Name,I_Company,I_Quantity,I_Wholesaleprice FROM [Items] where I_Name like '" + comboBox1.Text + "'";
                Program.xdata.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textBox3.Text = reader["I_ID"].ToString();
                        textBox10.Text = reader["I_Name"].ToString();
                        textBox7.Text = reader["I_Company"].ToString();
                        textBox6.Text = reader["I_Quantity"].ToString();
                        textBox8.Text = reader["I_Wholesaleprice"].ToString();


                    }
                }
            }

            Program.xdata.Close();
        }

        private void deleteitem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet3.Items' table. You can move, or remove it, as needed.
           



            using (SqlConnection sc = new SqlConnection())
            {
                sc.ConnectionString = connectionString;
                sc.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT I_Name FROM [Items] ORDER BY I_Name", sc))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    comboBox1.ValueMember = "I_ID";
                    comboBox1.DisplayMember = "I_Name";

                    comboBox1.DataSource = dt;
                }

            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            string q1 = Program.xsource;
                SqlConnection cn1 = new SqlConnection(q1);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn1;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [Items] where I_Company like '" + textBox2.Text + "%" + "'";
            cn1.Open();
            using (var command = cn1.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Items] where I_Company like '" + textBox2.Text + "%" + "'";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        namesCollection.Add(reader["I_Company"].ToString());

                    }
                }
            }
            cn1.Close();
            textBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox2.AutoCompleteCustomSource = namesCollection;
        }

        private void itemsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
        
    }
}
