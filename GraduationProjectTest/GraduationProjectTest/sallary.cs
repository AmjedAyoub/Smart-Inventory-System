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
    public partial class sallary : Form
    {
        public string first;
        public string last;
        public sallary()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void sallary_Load(object sender, EventArgs e)
        {
            string connectionString = Program.xsource;
            // TODO: This line of code loads data into the 'database1DataSet.Employees' table. You can move, or remove it, as needed.
          //  this.employeesTableAdapter.Fill(this.database1DataSet.Employees);
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
        string id = "";
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
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Employees] where E_Firstname  like '" + first + "'" + "AND E_Lastname like '" + last + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);

                //con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            string sallary = "";
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT E_ID, E_Firstname, E_Lastname,E_Drop ,E_Contactnum, E_Job ,E_Hiredate,E_Sallary FROM [Employees] where E_Firstname like '" + first + "'" + "AND E_Lastname like '" + last + "'";
                // con1.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textBox1.Text = reader["E_Firstname"].ToString() + " " + reader["E_Lastname"].ToString();
                        textBox2.Text = reader["E_Drop"].ToString();
                        sallary = reader["E_Sallary"].ToString();
                        string m = (double.Parse(sallary) - double.Parse(textBox2.Text)).ToString();
                        textBox3.Text = m;
                        id = reader["E_ID"].ToString();


                    }
                }
            }

            Program.xdata.Close();
        }
        string xx = "0";
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "0")
            {
                string q1 = Program.xsource;
                SqlConnection cn1 = new SqlConnection(q1);
                SqlCommand cmd1 = new SqlCommand("UPDATE [Employees] SET E_Drop=@xx WHERE E_ID = '" + id + "'", cn1);
                cmd1.Parameters.AddWithValue("@xx", xx);
                cn1.Open();
                SqlDataReader dr1 = cmd1.ExecuteReader();
                string type = "Sallary payment";
                DateTime date = DateTime.Now;
                string q2 = Program.xsource;
                SqlConnection cn2 = new SqlConnection(q2);
                SqlCommand cmd2 = new SqlCommand("INSERT INTO [expenses](type,date,amount)VALUES (@type,@date,@textBox3)", cn2);
                cmd2.Parameters.AddWithValue("@type", type);
                cmd2.Parameters.AddWithValue("@date", date);
                cmd2.Parameters.AddWithValue("@textBox3", textBox3.Text);
                cn2.Open();
                SqlDataReader dr2 = cmd2.ExecuteReader();
                MessageBox.Show("Your data has been saved successfully");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
            else
                MessageBox.Show("There is no rest to pay");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
