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
    public partial class BuyItem : Form
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        
        public BuyItem()
        {
            InitializeComponent();
            textBox6.Text = "0";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string id = "";
           
            string qan = (double.Parse(textBox3.Text) + double.Parse(textBox6.Text)).ToString();
            string qan1 = textBox8.Text;
            DateTime date = DateTime.Now;
            string q21 = Program.xsource;
                SqlConnection cn21 = new SqlConnection(q21);
            SqlCommand cmd21 = new SqlCommand("INSERT INTO [Buy](I_ID,I_Name,I_Quantity,Buy_Price,B_date)VALUES (@textBox4,@textBox10,@textBox3,@textBox5,@date)", cn21);
            cmd21.Parameters.AddWithValue("@textBox4", id);
            cmd21.Parameters.AddWithValue("@textBox10", textBox10.Text);
            cmd21.Parameters.AddWithValue("@textBox3", double.Parse(textBox3.Text)+double.Parse(textBox6.Text));
            cmd21.Parameters.AddWithValue("@textBox5", textBox5.Text);
            cmd21.Parameters.AddWithValue("@date", date);
            cn21.Open();
            SqlDataReader dr21 = cmd21.ExecuteReader();
            string q1 = Program.xsource;
                SqlConnection cn1 = new SqlConnection(q1);
            SqlCommand cmd1 = new SqlCommand("UPDATE [Items] SET I_Quantity=@textBox3 ,I_Expirydate=@textBox8 WHERE I_ID = '" + textBox4.Text + "'", cn1);
           cmd1.Parameters.AddWithValue("@textBox3", qan);
            cmd1.Parameters.AddWithValue("@textBox8", qan1);
            cn1.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();

            MessageBox.Show("Your data has been altered successfully"); 



            //////////////////////////////////////////////////////////////////


            try
            {
               
               DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT I_Name,I_Company,I_Quantity, I_Wholesaleprice FROM [Items] where I_Name like '" + textBox1.Text + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
             using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT I_Name,I_Company,I_Quantity,I_Wholesaleprice FROM [Items] where I_Company like '" + textBox2.Text + "'";
               // con1.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textBox4.Text = reader["I_ID"].ToString();
                        textBox10.Text = reader["I_Name"].ToString();
                        textBox7.Text = reader["I_Company"].ToString();
                        textBox3.Text = reader["I_Quantity"].ToString();
                        textBox5.Text = reader["I_Wholesaleprice"].ToString(); 
                        


                    }
                }




            }

             Program.xdata.Close();

             textBox4.Clear();
             textBox10.Clear();
             textBox7.Clear();
             textBox3.Clear();
             textBox6.Clear();
             textBox5.Clear();
             textBox8.Clear();
             textBox1.Clear();
             textBox2.Clear();
             comboBox1.Text = ""; 

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT I_ID,I_Name,I_Company,I_Quantity,I_Wholesaleprice,I_Expirydate FROM [Items] where I_Name like '" + textBox1.Text  + "'";
                Program.xdata.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textBox4.Text = reader["I_ID"].ToString();
                        textBox10.Text = reader["I_Name"].ToString();
                        textBox7.Text = reader["I_Company"].ToString();
                        textBox3.Text = reader["I_Quantity"].ToString();
                        textBox5.Text = reader["I_Wholesaleprice"].ToString();
                        textBox8.Text = reader["I_Expirydate"].ToString();

                    }
                }
            }

            Program.xdata.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
             using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT I_ID,I_Name,I_Company,I_Quantity,I_Wholesaleprice,I_Expirydate FROM [Items] where I_Company like '" + textBox2.Text + "'";
                Program.xdata.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textBox4.Text = reader["I_ID"].ToString();
                        textBox10.Text = reader["I_Name"].ToString();
                        textBox7.Text = reader["I_Company"].ToString();
                        textBox3.Text = reader["I_Quantity"].ToString();
                        textBox5.Text = reader["I_Wholesaleprice"].ToString();
                        textBox8.Text = reader["I_Expirydate"].ToString();


                    }
                }
            }

             Program.xdata.Close();
        }

        private void BuyItem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet5.Items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter.Fill(this.database1DataSet5.Items);
            // TODO: This line of code loads data into the 'database1DataSet2.Items' table. You can move, or remove it, as needed.
           

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT I_ID,I_Name,I_Company,I_Quantity,I_Wholesaleprice ,I_Expirydate FROM [Items] where I_Name like '" + comboBox1.Text + "'";
                Program.xdata.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textBox4.Text = reader["I_ID"].ToString();
                        textBox10.Text = reader["I_Name"].ToString();
                        textBox7.Text = reader["I_Company"].ToString();
                        textBox3.Text = reader["I_Quantity"].ToString();
                        textBox5.Text = reader["I_Wholesaleprice"].ToString();
                        textBox8.Text = reader["I_Expirydate"].ToString();

                    }
                }
            }

            Program.xdata.Close();
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
                        namesCollection.Add(reader["I_Name"].ToString());

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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string theDate = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            textBox8.Text = theDate.ToString();
        }
    }
}
