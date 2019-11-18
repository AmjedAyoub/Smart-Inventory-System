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
    public partial class Destroyitems : Form
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection namesCollection2 = new AutoCompleteStringCollection();
       
        public Destroyitems()
        {
            InitializeComponent();
        }

        private void Destroyitems_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string quantity = textBox6.Text;
            string id = textBox3.Text;
            string name = textBox1.Text;
            string qan = "";
            string qant = "";
            DateTime date = DateTime.Now;
                     try
                     {
                         SqlConnection con;
                         con = new System.Data.SqlClient.SqlConnection();
                         con.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\amjad\\Desktop\\Amjad-CS\\GraduationProjectTest\\GraduationProjectTest\\Database1.mdf;Integrated Security=True;User Instance=True";
                         DataTable dt = new DataTable();
                         SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] where I_Name like '" + textBox1.Text+ "'", con);
                         con.Open();
                         SDA.Fill(dt);

                         con.Close();
                     }
                     catch (Exception ex)
                     {
                         MessageBox.Show(ex.Message.ToString());
                     }
                     SqlConnection con1;
                     con1 = new System.Data.SqlClient.SqlConnection();
                     con1.ConnectionString =  "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\amjad\\Desktop\\Amjad-CS\\GraduationProjectTest\\GraduationProjectTest\\Database1.mdf;Integrated Security=True;User Instance=True";
                     using (var command = con1.CreateCommand())
                     {
                         command.CommandText = "SELECT * FROM [Items] where I_Name like '" + textBox1.Text + "'";
                         con1.Open();
                         using (var reader = command.ExecuteReader())
                         {
                             while (reader.Read())
                             {
                                 id = reader["I_ID"].ToString();
                                 qant = reader["I_Quantity"].ToString();
                             }
                         }
                     }

            string q21 = Program.xsource;
                SqlConnection cn21 = new SqlConnection(q21);
                    SqlCommand cmd21 = new SqlCommand("INSERT INTO [Destroy list](Des_Date,I_Name,I_Quantity,I_ID)VALUES (@textBox8,@textBox10,@textBox6,@textBox3)", cn21);
                    cmd21.Parameters.AddWithValue("@textBox8", date);
                    cmd21.Parameters.AddWithValue("@textBox10", name);
                    cmd21.Parameters.AddWithValue("@textBox6", quantity);
                    cmd21.Parameters.AddWithValue("@textBox3", id);
                    cn21.Open();
                    SqlDataReader dr21 = cmd21.ExecuteReader();
                    qan = (float.Parse(qant) - float.Parse(quantity)).ToString();
                    string q1 = Program.xsource;
                        SqlConnection cn1 = new SqlConnection(q1);
                    SqlCommand cmd1 = new SqlCommand("UPDATE [Items] SET I_Quantity=@qan WHERE I_ID = '" + textBox3.Text + "'", cn1);
                    cmd1.Parameters.AddWithValue("@qan", qan);
                    cn1.Open();
                    SqlDataReader dr1 = cmd1.ExecuteReader();

                    MessageBox.Show("Your data has been altered successfully");
              
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
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
                        namesCollection2.Add(reader["I_Company"].ToString());

                    }
                }
            }
            cn1.Close();
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteCustomSource = namesCollection2;
        }

        private void textBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = ""; 
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] where I_Name like '" + textBox1.Text + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);

                Program.xdata.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT I_ID, I_Name, I_Company,I_Quantity, I_Date FROM [Items] where I_Name like '" + textBox1.Text + "'";
                Program.xdata.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textBox3.Text = reader["I_ID"].ToString();
                        textBox10.Text = reader["I_Name"].ToString();
                        textBox7.Text = reader["I_Company"].ToString();
                        //textBox6.Text = reader["I_Quantity"].ToString();
                       // textBox8.Text = reader["I_Date"].ToString();



                    }
                }




            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                 DataTable dt = new DataTable();
                 SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] where I_Company like '" + textBox2.Text + "'", Program.xdata);
                 Program.xdata.Open();
                SDA.Fill(dt);

                Program.xdata.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT I_ID, I_Name, I_Company,I_Quantity, I_Date FROM [Items] where I_Name like '" + textBox1.Text + "'";
                Program.xdata.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textBox3.Text = reader["I_ID"].ToString();
                        textBox10.Text = reader["I_Name"].ToString();
                        textBox7.Text = reader["I_Company"].ToString();
                       // textBox6.Text = reader["I_Quantity"].ToString();
                       // textBox8.Text = reader["I_Date"].ToString();



                    }
                }




            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string theDate = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            textBox8.Text = theDate.ToString();
        }
    }
}
