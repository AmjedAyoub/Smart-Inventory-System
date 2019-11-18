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
    public partial class delivery : Form
    {
        public string delivprice;
        public string delorder;
        public string cus;
        public int count = 0;
        public int q = 0;
        public List<string> x = new List<string>();
        public List<string> y = new List<string>();
        public List<string> z = new List<string>();

        public delivery()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Show();
            panel1.Hide();
        }
        public void list(List<string> a, List<string> b, List<string> c)
        {
            x = a;
            y = b;
            z = c;

        }
        public void display()
        {
            textBox1.Text = delorder;
            textBox2.Text = cus;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("PLease select a driver");
            }
            else
            {
                DateTime date = DateTime.Now;
                string time = DateTime.Now.ToLongTimeString().ToString();
                string id = "";
                string q2 = Program.xsource;
                SqlConnection cn2 = new SqlConnection(q2);
                SqlCommand cmd2 = new SqlCommand("INSERT INTO [Delivery](Drivername,C_address,D_amount,D_Date,D_time)VALUES (@listBox1,@textBox2,@delivprice,@date,@time)", cn2);
                cmd2.Parameters.AddWithValue("@listBox1", listBox1.SelectedItem);
                cmd2.Parameters.AddWithValue("@textBox2", textBox2.Text);
                cmd2.Parameters.AddWithValue("@delivprice", delivprice);
                cmd2.Parameters.AddWithValue("@date", date);
                cmd2.Parameters.AddWithValue("@time", time);
                cn2.Open();
                SqlDataReader dr2 = cmd2.ExecuteReader();


                try
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Delivery] where D_time like '" + time + "'", Program.xdata);
                    Program.xdata.Open();
                    SDA.Fill(dt);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                using (var command = Program.xdata.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM [Delivery] where  D_time like '" + time + "'";
                   // Program.xdata.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = reader["D_ID"].ToString();

                        }
                    }
                }

                for (int i = 0; i < x.Count; i++)
                {
                    string q22 = Program.xsource;
                    SqlConnection cn22 = new SqlConnection(q22);
                    SqlCommand cmd22 = new SqlCommand("INSERT INTO [deliverydetails](D_ID,Drivername,I_Name,C_address,I_Price,I_Quantity)VALUES (@id,@listBox1,@x,@textBox2,@y,@z)", cn22);
                    cmd22.Parameters.AddWithValue("@id", id);
                    cmd22.Parameters.AddWithValue("@listBox1", listBox1.SelectedItem);
                    cmd22.Parameters.AddWithValue("@x", x[i]);
                    cmd22.Parameters.AddWithValue("@textBox2", textBox2.Text);
                    cmd22.Parameters.AddWithValue("@y", y[i]);
                    cmd22.Parameters.AddWithValue("@z", z[i]);
                    cn22.Open();
                    SqlDataReader dr22 = cmd22.ExecuteReader();
                }
                dataGridView1.Rows.Insert(count, false, listBox1.SelectedItem, textBox1.Text, id, textBox2.Text, delivprice);
                count++;
                textBox1.Text = "";
                textBox2.Text = "";
            }
            Program.xdata.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
            delorder = "";
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
            delorder = "";
            this.Hide();
        }

        public void delivery_Load(object sender, EventArgs e)
        {
           
            panel1.Show();
            panel2.Hide();
            display();
            string name = "";
            string id = "";
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Employees] where E_Job like '" + "Driver" + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);

                //Program.xdata.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
           // int xx = 370;
          //  int yy = 22;
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Employees] where E_Job like '" + "Driver" + "'";
                //Program.xdata.Open();
                listBox1.Items.Clear();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = reader["E_ID"].ToString();
                        name = reader["E_Firstname"].ToString() + " " + reader["E_Lastname"].ToString();
                        listBox1.Items.Add(name + "\n");
                       /* RadioButton r = new RadioButton();
                        r.Visible = true;
                        r.Name = r.ToString();
                        r.Size = new Size(130, 30);
                        r.ForeColor = Color.WhiteSmoke;
                        r.Font = new Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        r.Location = new Point(xx, yy);
                        r.Text = name;
                        panel2.Controls.Add(r);
                        xx = xx + 140;*/
                    }
                }
            }
            listBox1.Items.Add("NOBODY" + "\n");
            Program.xdata.Close();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int newcount = 0;
            int row = dataGridView1.CurrentCell.RowIndex;
            if (row < count && count != 0)
            {
                List<string> d = new List<string>();
                List<string> f = new List<string>();
                List<string> g = new List<string>();
                if ((MessageBox.Show("Are you sure you want to delete these orders", "Confirmation Window", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if ((MessageBox.Show("Do you want to delete the items quantity from your data base", "Confirmation Window", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                    {

                        for (int i = 0; i < count; i++)
                        {
                            string fr = dataGridView1.Rows[i].Cells[0].Value.ToString();
                            if (fr == "True")
                            {
                                string q1 = Program.xsource;
                                SqlConnection cn1 = new SqlConnection(q1);
                                SqlCommand cmd1 = new SqlCommand("DELETE FROM [Delivery] WHERE D_ID = '" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "'", cn1);
                                cn1.Open();
                                SqlDataReader dr1 = cmd1.ExecuteReader();
                                try
                                {
                                    DataTable dt = new DataTable();
                                    SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [deliverydetails] where D_ID like '" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "'", Program.xdata);
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
                                    command.CommandText = "SELECT * FROM [deliverydetails] where D_ID like '" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "'";
                                    // Program.xdata.Open();
                                    using (var reader = command.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            d.Add(reader["I_Name"].ToString());
                                            f.Add(reader["I_Price"].ToString());
                                            g.Add(reader["I_Quantity"].ToString());

                                        }
                                    }
                                }

                                //  Program.xdata.Close();
                                string q11 = Program.xsource;
                                SqlConnection cn11 = new SqlConnection(q11);
                                SqlCommand cmd11 = new SqlCommand("DELETE FROM [deliverydetails] WHERE D_ID = '" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "'", cn11);
                                cn11.Open();
                                SqlDataReader dr11 = cmd11.ExecuteReader();
                                for (int h = 0; h < d.Count - 1; h++)
                                {
                                    double quan = double.Parse(g[h]);
                                    for (int s = h; s < d.Count - 1; s++)
                                    {
                                        if (d[h] == d[s + 1])
                                        {
                                            quan = quan + double.Parse(g[s + 1]);
                                            d.RemoveAt(s + 1);
                                            g.RemoveAt(s + 1);
                                        }
                                    }
                                    DateTime date = DateTime.Now;
                                    string time = DateTime.Now.ToLongTimeString().ToString();
                                    string q2 = Program.xsource;
                                    SqlConnection cn2 = new SqlConnection(q2);
                                    SqlCommand cmd2 = new SqlCommand("INSERT INTO [Destroy list](Des_Date,I_Name,I_Quantity)VALUES (@date,@d,@g)", cn2);
                                    cmd2.Parameters.AddWithValue("@date", date);
                                    cmd2.Parameters.AddWithValue("@d", d[h]);
                                    cmd2.Parameters.AddWithValue("@g", g[h]);
                                    cn2.Open();
                                    SqlDataReader dr2 = cmd2.ExecuteReader();
                                    try
                                    {
                                        DataTable dt = new DataTable();
                                        SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] where I_Name like '" + d[h] + "'", Program.xdata);
                                        //  Program.xdata.Open();
                                        SDA.Fill(dt);

                                        // Program.xdata.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message.ToString());
                                    }
                                    string qant = "";
                                    using (var command = Program.xdata.CreateCommand())
                                    {
                                        command.CommandText = "SELECT * FROM [Items] where I_Name like '" + d[h] + "'";
                                        //   Program.xdata.Open();
                                        using (var reader = command.ExecuteReader())
                                        {
                                            while (reader.Read())
                                            {
                                                qant = reader["I_Quantity"].ToString();
                                            }
                                        }
                                    }

                                    Program.xdata.Close();
                                    string asd = (double.Parse(qant) - quan).ToString();
                                    string q12 = Program.xsource;
                                    SqlConnection cn12 = new SqlConnection(q12);
                                    SqlCommand cmd12 = new SqlCommand("UPDATE [Items] SET I_Quantity=@g WHERE I_Name = '" + d[h] + "'", cn12);
                                    cmd12.Parameters.AddWithValue("@g", asd);
                                    cn12.Open();
                                    SqlDataReader dr12 = cmd12.ExecuteReader();



                                }


                            }
                            dataGridView1.Rows.RemoveAt(i);
                            newcount++;
                        }
                        MessageBox.Show("Your data has been altered successfully");
                        count = count - newcount;
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            string fr = dataGridView1.Rows[i].Cells[0].Value.ToString();
                            if (fr == "True")
                            {
                                dataGridView1.Rows.RemoveAt(i);
                                newcount++;
                            }
                        }
                        count = count - newcount;
                    }
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*textBox3.Text = "0";
            foreach (Control item in panel2.Controls)
            {
                if (item is RadioButton)
                {
                    RadioButton rb = (RadioButton)item;
                    if (rb.Checked)
                    {
                        string s = rb.Text;
                        for (int i = 0; i < count; i++)
                        {
                            string ss = dataGridView1.Rows[i].Cells[1].Value.ToString();
                            if (ss == s)
                            {
                                textBox3.Text = ((double.Parse(textBox3.Text)) + (double.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()))).ToString();
                            }
                        }
                    }
                }
            }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
