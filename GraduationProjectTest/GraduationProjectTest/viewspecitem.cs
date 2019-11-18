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
    public partial class viewspecitem : Form
    {
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        
        public viewspecitem()
        {
            InitializeComponent();
        }

        private void viewspecitem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet3.Items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter.Fill(this.database1DataSet3.Items);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = 0;
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] ", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);

                // Program.xdata.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Items] WHERE [I_Name] like '" + comboBox1.Text + "'";
                if (comboBox1.Text != "")
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           
                            dataGridView1.Rows.Insert(x, reader["I_Name"], reader["I_Company"], reader["I_Type"], reader["I_Quantity"], reader["I_Expirydate"], reader["I_Tax"], reader["I_Wholesaleprice"], reader["I_sellingprice"]);
                            x++;
                        }
                    }
                }
                Program.xdata.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
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
            int x = 0;
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] ", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);

                // Program.xdata.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Items] WHERE [I_Name] like '" + textBox1.Text + "'";
                if (comboBox1.Text != "")
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            dataGridView1.Rows.Insert(x, reader["I_Name"], reader["I_Company"], reader["I_Type"], reader["I_Quantity"], reader["I_Expirydate"], reader["I_Tax"], reader["I_Wholesaleprice"], reader["I_sellingprice"]);
                            x++;
                        }
                    }
                }
                Program.xdata.Close();
            }
        }
    }
}
