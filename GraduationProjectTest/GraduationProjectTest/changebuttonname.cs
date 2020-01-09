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
    public partial class changebuttonname : Form
    {
        public string btn_name = "";
        public Button obj;
        public Boolean a = false;
        public string id = "";

        public changebuttonname(Button btn)
        {
            obj = btn;
            InitializeComponent();
            typecomboBox1.Items.Add("Liquid");
            typecomboBox1.Items.Add("Solid");
            typecomboBox1.Items.Add("Gas");
            unitcomboBox2.Items.Add("Gram");
            unitcomboBox2.Items.Add("Kilogram");
            unitcomboBox2.Items.Add("Liter");
            unitcomboBox2.Items.Add("mL");
            unitcomboBox2.Items.Add("piece");
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            obj.Text = textBox1.Text;
            if (a)
            {
                string q1 = Program.xsource;
                SqlConnection cn1 = new SqlConnection(q1);
                SqlCommand cmd1 = new SqlCommand("UPDATE [Items] SET I_Name=@textBox1,I_Company=@textBox7 ,I_Type=@typecomboBox1,I_Quantity=@textBox2,I_Expirydate=@textBox3,I_Unit=@unitcomboBox2,I_Wholesaleprice=@textBox5,I_Tax=@textBox4,I_Sellingprice=@textBox6,I_Date=@textBox8,I_Minvalue=@textBox9 WHERE I_ID = '" + id + "'", cn1);
                cmd1.Parameters.AddWithValue("@textBox1", textBox1.Text);
                cmd1.Parameters.AddWithValue("@textBox7", textBox7.Text);
                cmd1.Parameters.AddWithValue("@textBox2", textBox2.Text);
                cmd1.Parameters.AddWithValue("@typecomboBox1", typecomboBox1.Text);
                cmd1.Parameters.AddWithValue("@textBox6", textBox6.Text);
                cmd1.Parameters.AddWithValue("@textBox9", textBox9.Text);
                cmd1.Parameters.AddWithValue("@unitcomboBox2", unitcomboBox2.Text);
                cmd1.Parameters.AddWithValue("@textBox5", textBox5.Text);
                cmd1.Parameters.AddWithValue("@textBox4", textBox4.Text);
                cmd1.Parameters.AddWithValue("@textBox3", textBox3.Text);
                cmd1.Parameters.AddWithValue("@textBox8", textBox8.Text);
                cn1.Open();
                SqlDataReader dr1 = cmd1.ExecuteReader();
                MessageBox.Show("Your data has been altered successfully");
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox9.Clear();
                unitcomboBox2.Text = " ";
                typecomboBox1.Text = " ";
            }
            else
            {
                string q2 = Program.xsource;
                SqlConnection cn2 = new SqlConnection(q2);
                SqlCommand cmd2 = new SqlCommand("INSERT INTO [Items](I_Name,I_Company,I_Type,I_Quantity,I_Expirydate,I_Unit,I_Wholesaleprice,I_Tax,I_sellingprice,I_Date,I_Minvalue)VALUES (@textBox1,@textBox7,@typecomboBox1,@textBox2,@textBox3,@unitcomboBox2,@textBox5,@textBox4,@textBox6,@textBox8,@textBox9)", cn2);
                cmd2.Parameters.AddWithValue("@textBox6", textBox6.Text);
                cmd2.Parameters.AddWithValue("@textBox7", textBox7.Text);
                cmd2.Parameters.AddWithValue("@typecomboBox1", typecomboBox1.SelectedText);
                cmd2.Parameters.AddWithValue("@textBox2", textBox2.Text);
                cmd2.Parameters.AddWithValue("@textBox1", textBox1.Text);
                cmd2.Parameters.AddWithValue("@unitcomboBox2", unitcomboBox2.SelectedText);
                cmd2.Parameters.AddWithValue("@textBox5", textBox5.Text);
                cmd2.Parameters.AddWithValue("@textBox4", textBox4.Text);
                cmd2.Parameters.AddWithValue("@textBox3", textBox3.Text);
                cmd2.Parameters.AddWithValue("@textBox8", textBox8.Text);
                cmd2.Parameters.AddWithValue("@textBox9", textBox9.Text);
                cn2.Open();
                SqlDataReader dr2 = cmd2.ExecuteReader();
                MessageBox.Show("Your data has been saved successfully");
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox9.Clear();
                unitcomboBox2.Text = " ";
                typecomboBox1.Text = " ";
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox9.Clear();
            unitcomboBox2.Text = " ";
            typecomboBox1.Text = " ";
        }

        private void changebuttonname_Load(object sender, EventArgs e)
        {
            
        }
        public void view()
        {
            textBox1.Text = obj.Text;
            if (textBox1.Text != "")
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
                            id = reader["I_ID"].ToString();
                            textBox9.Text = reader["I_Minvalue"].ToString();
                            textBox7.Text = reader["I_Company"].ToString();
                            typecomboBox1.Text = reader["I_Type"].ToString();
                            textBox2.Text = reader["I_Quantity"].ToString();
                            textBox3.Text = reader["I_Expirydate"].ToString();
                            unitcomboBox2.Text = reader["I_Unit"].ToString();
                            textBox5.Text = reader["I_Wholesaleprice"].ToString();
                            textBox4.Text = reader["I_Tax"].ToString();
                            textBox6.Text = reader["I_Sellingprice"].ToString();
                            textBox8.Text = reader["I_Date"].ToString();
                        }
                    }
                }

                Program.xdata.Close();
                a = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    
    }
}
