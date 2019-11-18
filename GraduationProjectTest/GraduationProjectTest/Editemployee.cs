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
    public partial class Editemployee : Form
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection(); 
        public string first;
        public string last;
        public Editemployee()
        {
            InitializeComponent();
            jobcomboBox1.Items.Add("Manager");
            jobcomboBox1.Items.Add("Accountant");
            jobcomboBox1.Items.Add("Cashier");
            jobcomboBox1.Items.Add("Worker");
        }
       
        private void Editemployee_Load(object sender, EventArgs e)
        {
           string connectionString = Program.xsource;
            // TODO: This line of code loads data into the 'database1DataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.database1DataSet.Employees);
            using (SqlConnection sc = new SqlConnection())
            {
                sc.ConnectionString = connectionString;
                sc.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT E_Firstname + ' ' + E_Lastname AS Employee_Full_Name FROM Employees ORDER BY E_Lastname",sc))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    comboBox1.ValueMember = "E_ID";
                    comboBox1.DisplayMember = "Employee_Full_Name";
                   
                    comboBox1.DataSource = dt;
                }

            }

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.employeesTableAdapter.FillBy(this.database1DataSet.Employees);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

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

                //con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT E_ID, E_Firstname, E_Lastname,E_Email ,E_Contactnum, E_Job ,E_Hiredate,E_Sallary FROM [Employees] where E_Firstname like '" + first + "'" + "AND E_Lastname like '" + last + "'";
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

        private void fillByToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.employeesTableAdapter.FillBy(this.database1DataSet.Employees);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.employeesTableAdapter.Fill(this.database1DataSet.Employees);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void toolStripContainer1_LeftToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void employeesBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT E_Firstname + ' ' + E_Lastname AS name FROM Employees WHERE E_Firstname LIKE '" + textBox1.Text + "' AND E_Lastname LIKE '" + textBox1.Text + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);

                //con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT E_ID, E_Firstname, E_Lastname,E_Email ,E_Contactnum, E_Job ,E_Hiredate,E_Sallary FROM [Employees]  where E_Firstname + ' ' + E_Lastname like '" + textBox1.Text + "'";

              //  con1.Open();
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

        private void button3_Click(object sender, EventArgs e)
        {
            string q1 = Program.xsource;
                SqlConnection cn1 = new SqlConnection(q1);
            SqlCommand cmd1 = new SqlCommand("UPDATE [Employees] SET E_Firstname=@textBox7, E_Lastname=@textBox6,E_Email=@textBox5,E_Contactnum=@textBox4 ,E_Job=@jobcomboBox1 , E_Hiredate=@textBox2 ,E_Sallary=@textBox3 WHERE E_ID = '" + textBox8.Text + "'", cn1);
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



        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string theDate = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            textBox2.Text = theDate.ToString();
        }

       
    }
}
