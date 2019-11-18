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
    public partial class editcustomer : Form
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        public string first;
        public string last;
        public editcustomer()
        {
            InitializeComponent();
        }
        private void editcustomer_Load(object sender, EventArgs e)
        {
            string connectionString = Program.xsource;
            using (SqlConnection sc = new SqlConnection())
            {
                sc.ConnectionString = connectionString;
                sc.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT C_FirstName + ' ' + C_LastName AS Customer_Full_Name FROM [Customer] ORDER BY C_LastName", sc))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    comboBox1.ValueMember = "C_ID";
                    comboBox1.DisplayMember = "Customer_Full_Name";

                    comboBox1.DataSource = dt;
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                 DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT C_FirstName + ' ' + C_LastName AS name FROM CUstomer  where C_FirstName  LIKE '" + textBox1.Text + "' AND C_LastName LIKE '" + textBox1.Text + "'", Program.xdata);
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
                command.CommandText = "SELECT C_ID, C_FirstName, C_LastName,C_Contactnumber ,C_Email,C_Contactnumber, C_City ,C_Stname,C_Bildingnum, C_Floor , C_Apartment FROM [Customer] where C_FirstName + ' ' + C_LastName like '" + textBox1.Text + "'";
               // con1.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textBox12.Text = reader["C_ID"].ToString();
                        textBox3.Text = reader["C_FirstName"].ToString();
                        textBox4.Text = reader["C_LastName"].ToString();
                        textBox5.Text = reader["C_Email"].ToString();
                        textBox6.Text = reader["C_Contactnumber"].ToString();
                        textBox7.Text = reader["C_City"].ToString();
                        textBox8.Text = reader["C_Stname"].ToString();
                        textBox9.Text = reader["C_Bildingnum"].ToString();
                        textBox10.Text = reader["C_Floor"].ToString();
                        textBox11.Text = reader["C_Apartment"].ToString();


                    }
                }
            }


             Program.xdata.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string q1 = Program.xsource;
                SqlConnection cn1 = new SqlConnection(q1);
            SqlCommand cmd1 = new SqlCommand("UPDATE [Customer] SET C_FirstName=@textBox3, C_LastName=@textBox4,C_Contactnumber=@textBox6 ,C_Email=@textBox6 , C_City=@textBox7  ,C_Stname=@textBox8 ,C_Bildingnum=@textBox9 , C_Floor=@textBox10  , C_Apartment=@textBox11 WHERE C_ID = '" + textBox12.Text + "'", cn1);
            cmd1.Parameters.AddWithValue("@textBox3", textBox3.Text);
            cmd1.Parameters.AddWithValue("@textBox4", textBox4.Text);
            cmd1.Parameters.AddWithValue("@textBox5", textBox5.Text);
            cmd1.Parameters.AddWithValue("@textBox6", textBox6.Text);
            cmd1.Parameters.AddWithValue("@textBox7", textBox7.Text);
            cmd1.Parameters.AddWithValue("@textBox8", textBox8.Text);
            cmd1.Parameters.AddWithValue("@textBox9", textBox9.Text);
            cmd1.Parameters.AddWithValue("@textBox10", textBox10.Text);
            cmd1.Parameters.AddWithValue("@textBox11", textBox11.Text);

            cn1.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            MessageBox.Show("Your data has been altered successfully");
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string q1 = Program.xsource;
                SqlConnection cn1 = new SqlConnection(q1);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn1;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [Customer] where C_Contactnumber like '" + textBox2.Text + "%" + "'";
            cn1.Open();
            using (var command = cn1.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Customer] where C_Contactnumber like '" + textBox2.Text + "%" + "'";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        namesCollection.Add(reader["C_Contactnumber"].ToString());

                    }
                }
            }
            cn1.Close();
            textBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox2.AutoCompleteCustomSource = namesCollection;
        }
        



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                  DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Customer] where C_Contactnumber like '" + textBox2.Text + "'", Program.xdata);
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
                command.CommandText = "SELECT C_ID, C_FirstName, C_LastName,C_Contactnumber ,C_Email,C_Contactnumber, C_City ,C_Stname,C_Bildingnum, C_Floor , C_Apartment FROM [Customer] where C_Contactnumber like '" + textBox2.Text + "'";
                //con1.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textBox12.Text = reader["C_ID"].ToString();
                        textBox3.Text = reader["C_FirstName"].ToString();
                        textBox4.Text = reader["C_LastName"].ToString();
                        textBox5.Text = reader["C_Email"].ToString();
                        textBox6.Text = reader["C_Contactnumber"].ToString();
                        textBox7.Text = reader["C_City"].ToString();
                        textBox8.Text = reader["C_Stname"].ToString();
                        textBox9.Text = reader["C_Bildingnum"].ToString();
                        textBox10.Text = reader["C_Floor"].ToString();
                        textBox11.Text = reader["C_Apartment"].ToString();


                    }
                }
            }

            Program.xdata.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = 0;
            int s = comboBox1.Text.Length;
            if (comboBox1.Text != "")
            {
                while (comboBox1.Text[i].ToString() != " ")
                    i++;
                first = comboBox1.Text.Substring(0, i);
                last = comboBox1.Text.Substring(i + 1, s - 1 - i);
            }
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Customer] where C_FirstName  like '" + first + "'" + "AND C_LastName like '" + last + "'", Program.xdata);
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
                command.CommandText = "SELECT C_ID, C_FirstName, C_LastName,C_Email ,C_Contactnumber, C_City ,C_Stname,C_Bildingnum , C_Floor,C_Apartment FROM [Customer] where C_FirstName like '" + first + "'" + "AND C_LastName like '" + last + "'";
               // con1.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textBox12.Text = reader["C_ID"].ToString();
                        textBox3.Text = reader["C_FirstName"].ToString();
                        textBox4.Text = reader["C_LastName"].ToString();
                        textBox5.Text = reader["C_Email"].ToString();
                        textBox6.Text = reader["C_Contactnumber"].ToString();
                        textBox7.Text = reader["C_City"].ToString();
                        textBox8.Text = reader["C_Stname"].ToString();
                        textBox9.Text = reader["C_Bildingnum"].ToString();
                        textBox10.Text = reader["C_Floor"].ToString();
                        textBox11.Text = reader["C_Apartment"].ToString();




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
            cmd.CommandText = "SELECT * FROM [Customer] where C_FirstName like '" + textBox1.Text + "%" + "'";
            cn1.Open();
            using (var command = cn1.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Customer] where C_FirstName like '" + textBox1.Text + "%" + "'";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        namesCollection.Add(reader["C_FirstName"].ToString() + " " + reader["C_LastName"].ToString());

                    }
                }
            }
            cn1.Close();
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteCustomSource = namesCollection;

        }

    }

}

