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
    public partial class Edititem : Form
    {
         AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        public Edititem()
        {
            InitializeComponent();
            typecomboBox1.Items.Add("Liquid");
            typecomboBox1.Items.Add("Solid");
            typecomboBox1.Items.Add("Gas");
            comboBox1.Items.Add("Gram");
            comboBox1.Items.Add("Kilogram");
            comboBox1.Items.Add("Liter");
            comboBox1.Items.Add("mL");
            comboBox1.Items.Add("piece");
        }

        private void Edititem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet6.Items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter.Fill(this.database1DataSet6.Items);
            // TODO: This line of code loads data into the 'database1DataSet4.Items' table. You can move, or remove it, as needed.
     

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] where I_Company like '" + textBox2.Text + "'", Program.xdata);
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
                command.CommandText = "SELECT I_ID,I_Name,I_Company,I_Type,I_Quantity,I_Expirydate,I_Unit,I_Price,I_Tax,I_Sellingprice,I_Date FROM [Items] where I_Company like '" + textBox2.Text + "'";
               // Program.xdata.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textBox11.Text = reader["I_ID"].ToString();
                        textBox10.Text = reader["I_Name"].ToString();
                        textBox3.Text = reader["I_Company"].ToString();
                        typecomboBox1.Text = reader["I_Type"].ToString();
                        textBox6.Text = reader["I_Quantity"].ToString();
                        textBox9.Text = reader["I_Expirydate"].ToString();
                        comboBox1.Text = reader["I_Unit"].ToString();
                        textBox5.Text = reader["I_Price"].ToString();
                        textBox4.Text = reader["I_Tax"].ToString();
                        textBox3.Text = reader["I_Sellingprice"].ToString();
                        textBox8.Text = reader["I_Date"].ToString();
                        textBox12.Text = reader["I_Minvalue"].ToString();


                    }
                }
            }

            Program.xdata.Close();
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void unitcomboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string q1 = Program.xsource;
                SqlConnection cn1 = new SqlConnection(q1);
                SqlCommand cmd1 = new SqlCommand("UPDATE [Items] SET I_Name=@textBox10,I_Company=@textBox7 ,I_Type=@typecomboBox1,I_Quantity=@textBox6,I_Expirydate=@textBox9,I_Unit=@comboBox1,I_Wholesalepric=@textBox5,I_Tax=@textBox4,I_Sellingprice=@textBox3,I_Date=@textBox8,I_Minvalue=@textBox12 WHERE I_ID = '" + textBox11.Text + "'", cn1);
            cmd1.Parameters.AddWithValue("@textBox10", textBox10.Text);
            cmd1.Parameters.AddWithValue("@textBox7", textBox7.Text);
            cmd1.Parameters.AddWithValue("@typecomboBox1", typecomboBox1.Text);
            cmd1.Parameters.AddWithValue("@textBox6", textBox6.Text);
            cmd1.Parameters.AddWithValue("@textBox9", textBox9.Text);
            cmd1.Parameters.AddWithValue("@comboBox1", comboBox1.Text);
            cmd1.Parameters.AddWithValue("@textBox5", textBox5.Text);
            cmd1.Parameters.AddWithValue("@textBox4", textBox4.Text);
            cmd1.Parameters.AddWithValue("@textBox3", textBox3.Text);
            cmd1.Parameters.AddWithValue("@textBox8", textBox8.Text);
            cmd1.Parameters.AddWithValue("@textBox12", textBox12.Text);
            cn1.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            MessageBox.Show("Your data has been altered successfully");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {     DataTable dt = new DataTable();
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
                command.CommandText = "SELECT I_ID,I_Name,I_Company,I_Type,I_Quantity,I_Expirydate,I_Unit,I_Wholesaleprice,I_Tax,I_Sellingprice,I_Date FROM [Items] where I_Name like '" + textBox1.Text + "'";
               // con1.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textBox11.Text = reader["I_ID"].ToString();
                        textBox10.Text = reader["I_Name"].ToString();
                        textBox3.Text = reader["I_Company"].ToString();
                        typecomboBox1.Text = reader["I_Type"].ToString();
                        textBox6.Text = reader["I_Quantity"].ToString();
                        textBox9.Text = reader["I_Expirydate"].ToString();
                        comboBox1.Text = reader["I_Unit"].ToString();
                        textBox5.Text = reader["I_Wholesaleprice"].ToString();
                        textBox4.Text = reader["I_Tax"].ToString();
                        textBox3.Text = reader["I_Sellingprice"].ToString();
                        textBox8.Text = reader["I_Date"].ToString();
                        textBox12.Text = reader["I_Minvalue"].ToString();


                    }
                }
            }

            Program.xdata.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide(); 
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = ""; 
        }

        private void textBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT I_ID,I_Name,I_Company,I_Type, I_Quantity,I_Expirydate,I_Unit,I_Wholesaleprice,I_Tax,I_sellingprice,I_Date FROM [Items] where I_Name like '" + comboBox2.Text + "'";
                
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textBox11.Text = reader["I_ID"].ToString();
                        textBox10.Text = reader["I_Name"].ToString();
                        textBox7.Text = reader["I_Company"].ToString();
                        typecomboBox1.Text = reader["I_Type"].ToString();
                        textBox6.Text = reader["I_Quantity"].ToString();
                        textBox9.Text = reader["I_Expirydate"].ToString();
                        comboBox1.Text = reader["I_Unit"].ToString();
                        textBox5.Text = reader["I_Wholesaleprice"].ToString();
                        textBox4.Text = reader["I_Tax"].ToString();
                        textBox3.Text = reader["I_sellingprice"].ToString();
                        textBox8.Text = reader["I_Date"].ToString();
                        textBox12.Text = reader["I_Minvalue"].ToString();
                      
                        


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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           string theDate = dateTimePicker1.Value.ToString("MM/dd/yyyy");
           textBox9.Text = theDate.ToString();

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string theDate = dateTimePicker2.Value.ToString("MM/dd/yyyy");
            textBox8.Text = theDate.ToString();

        }
        }
    }

