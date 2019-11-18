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
    public partial class deleteemp : Form
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection(); 

        public string first;
        public string last;
        
        public deleteemp()
        {
            InitializeComponent();
        }
        private string connectionString = Program.xsource;
            private void deleteemp_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Employees' table. You can move, or remove it, as needed.
            using (SqlConnection sc = new SqlConnection())
            {
                sc.ConnectionString = connectionString;
                sc.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT E_Firstname + ' ' + E_Lastname AS Employee_Full_Name FROM Employees ORDER BY E_Lastname", sc))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    comboBox1.ValueMember = "E_ID";
                    comboBox1.DisplayMember = "Employee_Full_Name";

                    comboBox1.DataSource = dt;
                }

            }
       
        }


        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT  E_Firstname + ' ' + E_Lastname AS name FROM Employees WHERE E_Firstname LIKE '" + textBox1.Text + "' AND E_Lastname LIKE '" + textBox1.Text + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
             using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT E_ID ,E_Firstname,E_Lastname ,E_Email ,E_Contactnum, E_Job ,E_Hiredate,E_Sallary FROM [Employees] where E_Firstname + ' ' + E_Lastname like '" + textBox1.Text + "'";
                
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textBox8.Text = reader["E_ID"].ToString();
                        textBox7.Text = reader["E_Firstname"].ToString();
                        textBox6.Text = reader["E_Lastname"].ToString();
                        textBox5.Text = reader["E_Email"].ToString();
                        textBox4.Text = reader["E_Contactnum"].ToString();
                        jobcomboBox1.Text = reader["E_Job"].ToString();
                        textBox2.Text = reader["E_Hiredate"].ToString();
                        textBox3.Text = reader["E_Sallary"].ToString();


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
            cmd.CommandText = "SELECT * FROM [Employees] where E_Firstname like '" + textBox1.Text + "%" + "'";
            cn1.Open();
            using (var command = cn1.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Employees] where E_Firstname like '" + textBox1.Text + "%" + "'";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        namesCollection.Add(reader["E_Firstname"].ToString() + " " + reader["E_Lastname"].ToString());

                    }
                }
            }
            cn1.Close();
            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox1.AutoCompleteCustomSource = namesCollection;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string q1 = Program.xsource;
                SqlConnection cn1 = new SqlConnection(q1);
            SqlCommand cmd1 = new SqlCommand("DELETE FROM [Employees] WHERE E_ID = '" + textBox8.Text + "'", cn1);
            cmd1.Parameters.AddWithValue("@textBox7", textBox7.Text);
            cmd1.Parameters.AddWithValue("@textBox6", textBox6.Text);
            cmd1.Parameters.AddWithValue("@textBox5", textBox5.Text);
            cmd1.Parameters.AddWithValue("@textBox4", textBox4.Text);
            cmd1.Parameters.AddWithValue("@jobcomboBox1", jobcomboBox1.Text);
            cmd1.Parameters.AddWithValue("@textBox2", textBox2.Text);
            cmd1.Parameters.AddWithValue("@textBox3", textBox3.Text);
            
            cn1.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            MessageBox.Show("Your data has been altered successfully");
            textBox8.Clear();
            textBox7.Clear();
            textBox6.Clear();
            textBox5.Clear();
            textBox4.Clear();
            jobcomboBox1.Text = " ";
            textBox3.Clear();
            textBox2.Clear();
            
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide(); 
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
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Employees] where E_Firstname  like '" + first + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT E_ID, E_Firstname, E_Lastname,E_Email ,E_Contactnum, E_Job ,E_Hiredate,E_Sallary FROM [Employees] where E_Firstname like '" + first + "'";
               // con1.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textBox8.Text = reader["E_ID"].ToString();
                        textBox7.Text = reader["E_Firstname"].ToString();
                        textBox6.Text = reader["E_Lastname"].ToString();
                        textBox5.Text = reader["E_Email"].ToString();
                        textBox4.Text = reader["E_Contactnum"].ToString();
                        jobcomboBox1.Text = reader["E_Job"].ToString();
                        textBox2.Text = reader["E_Hiredate"].ToString();
                        textBox3.Text = reader["E_Sallary"].ToString();


                    }
                }
            }

            Program.xdata.Close();
        }

       
        
        }
}
