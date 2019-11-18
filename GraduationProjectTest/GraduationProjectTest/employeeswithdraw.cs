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
    public partial class employeeswithdraw : Form
    {
        public string first;
        public string last;
        public employeeswithdraw()
        {
            InitializeComponent();

        }
       
        public void employeeswithdraw_Load(object sender, EventArgs e)
        {
           // this.employeesTableAdapter.Fill(this.database1DataSet.Employees);
            using (SqlConnection sc = new SqlConnection())
            {
                sc.ConnectionString = Program.xsource;
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
            label5.Text = Program.xcash.cashiername;
            panel1.Show();
            panel2.Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string con = Program.xsource;
                SqlConnection cn = new SqlConnection(con);
            bool blnfound = false;

            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from Employees", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["E_Username"].ToString() == label5.Text && label5.Text != "")
                {
                    if (dr["E_Password"].ToString() == textBox1.Text)
                    {
                        blnfound = true;

                    }
                }

            }
            if (blnfound == false)
            {
                MessageBox.Show("wrong username or password please try again ", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
            }


            else
            {
                try
                {
                    DataTable dt = new DataTable();
                    using (var command = Program.xdata.CreateCommand())
                    {
                        command.CommandText = "SELECT E_Firstname FROM [Employees] where E_Password like " + textBox1.Text + "'";

                        Program.xdata.Open();

                    }

                    Program.xdata.Close();
                    dr.Close();
                    cn.Close();
                    textBox1.Text = "";
                    panel2.Show();
                    panel1.Hide();
                    Program.xdata.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

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
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Employees] where E_Firstname  like '" + first + "'" + "AND E_Lastname like '" + last + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT E_ID,E_Firstname,E_Lastname,E_Drop,E_Sallary FROM [Employees] where E_Firstname like '" + first + "'";
              //  Program.xdata.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textBox4.Text = reader["E_ID"].ToString();
                        textBox2.Text=(reader["E_Firstname"].ToString())+" "+(reader["E_Lastname"].ToString());
                        textBox5.Text = reader["E_Drop"].ToString();
                        textBox6.Text=reader["E_Sallary"].ToString();
                    }
                }
            }
            Program.xdata.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((double.Parse(textBox5.Text) + (double.Parse(textBox3.Text))) < (double.Parse(textBox6.Text)))
                {
                    double aaa = double.Parse(textBox3.Text) + double.Parse(textBox5.Text);
                    string aa = aaa.ToString();
                    string q1 = Program.xsource;
                    SqlConnection cn11 = new SqlConnection(q1);
                    SqlCommand cmd11 = new SqlCommand("UPDATE [Employees] SET E_Drop=@aa WHERE E_ID like '" + textBox4.Text + "'", cn11);
                    cmd11.Parameters.AddWithValue("@aa", aa);
                    cn11.Open();
                    SqlDataReader dr11 = cmd11.ExecuteReader();
                    string num = "1";
                    string q26 = Program.xsource;
                    SqlConnection cn26 = new SqlConnection(q26);
                    SqlCommand cmd26 = new SqlCommand("INSERT INTO [dailywith](Emp_name,emp_with,num)VALUES (@textBox2,@textBox3,@num)", cn26);
                    cmd26.Parameters.AddWithValue("@textBox2", textBox2.Text);
                    cmd26.Parameters.AddWithValue("@textBox3", textBox3.Text);
                    cmd26.Parameters.AddWithValue("@num", num);
                    cn26.Open();
                    SqlDataReader dr111 = cmd26.ExecuteReader();
                    MessageBox.Show("Your data has been altered successfully");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("This person has exceeded the withdraw limit");
                        textBox3.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Please insert a valid withdraw");
                textBox3.Text = "";
            }
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            this.Hide();
        }
    }
}
