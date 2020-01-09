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
    public partial class Login : Form
    {
        public static List<string> item = new List<string>();
        public static List<string> exp = new List<string>();
        public static List<string> exitem = new List<string>();
        public static List<string> exexp = new List<string>();
        public Login()
        {
            InitializeComponent();
        }

        private void button2ex_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonlogin1_Click(object sender, EventArgs e)
        {
            string job = "";
            string con = Program.xsource;
                SqlConnection cn = new SqlConnection(con);
            bool blnfound = false;

            cn.Open();
            SqlCommand cmd = new SqlCommand("select * from Employees", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["E_Username"].ToString() == textBox1.Text && textBox1.Text != "")
                {
                    if (dr["E_Password"].ToString() == textBox2.Text)
                    {
                        blnfound = true;      
                    }
                }
            }
            if (blnfound == false)
            {
                MessageBox.Show("wrong username or password please try again ", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            {
                try
                {
                   DataTable dt = new DataTable();
                   using (var command = Program.xdata.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM [Employees] where E_username like '" + textBox1.Text + "'";

                        Program.xdata.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                textBox3.Text = reader["E_Firstname"].ToString();
                                job = reader["E_Job"].ToString();
                            }
                        }
                    }

                   Program.xdata.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

                  
                    dr.Close();
                    cn.Close();
                    if (job == "Manager")
                    {

                        if ((MessageBox.Show("Welcom" + "\n" + "Would you open the manager page?", "Confirmation Window", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                        {
                            Program.xmanager.name(textBox3.Text);
                            Program.xmanager.mesag();
                            Program.xmanager.Show();
                        }
                        else
                        {
                             Program.xcash.cashier = textBox3.Text;
                            Program.xcash.Cash_Load_1(sender, e);
                            Program.xcash.Show();
                            string name = "";
                            string quantity = "";
                            string expiry = "";
                            string wprice = "";
                            string sprice = "";
                            DateTime date = DateTime.Now;
                            try
                            {
                                DataTable dt1 = new DataTable();
                                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] ", Program.xdata);
                                Program.xdata.Open();
                                SDA.Fill(dt1);

                                // Program.xdata.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                            try
                            {
                                using (var command = Program.xdata.CreateCommand())
                                {
                                    command.CommandText = "SELECT * FROM [Items] ";
                                    // Program.xdata.Open();
                                    using (var reader = command.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            name = reader["I_Name"].ToString();
                                            quantity = reader["I_Quantity"].ToString();
                                            expiry = reader["I_Expirydate"].ToString();
                                            wprice = reader["I_Wholesaleprice"].ToString();
                                            sprice = reader["I_sellingprice"].ToString();
                                            item.Add(name);
                                            exp.Add(expiry);
                                            string q2 = Program.xsource;
                                            SqlConnection cn2 = new SqlConnection(q2);
                                            SqlCommand cmd2 = new SqlCommand("INSERT INTO [inventory](i_name,i_quantity,date,i_wholeprice,i_sellingprice,i_expirydate)VALUES (@name,@quantity,@date,@wprice,@sprice,@expiry)", cn2);
                                            cmd2.Parameters.AddWithValue("@name", name);
                                            cmd2.Parameters.AddWithValue("@quantity", quantity);
                                            cmd2.Parameters.AddWithValue("@date", date);
                                            cmd2.Parameters.AddWithValue("@wprice", wprice);
                                            cmd2.Parameters.AddWithValue("@sprice", sprice);
                                            cmd2.Parameters.AddWithValue("@expiry", expiry);
                                            cn2.Open();
                                            SqlDataReader dr2 = cmd2.ExecuteReader();
                                        }
                                    }
                                }
                                Program.xdata.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                            try
                            {
                                DataTable dt1 = new DataTable();
                                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Offers] ", Program.xdata);
                                Program.xdata.Open();
                                SDA.Fill(dt1);

                                // Program.xdata.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                            try
                            {
                                using (var command = Program.xdata.CreateCommand())
                                {
                                    command.CommandText = "SELECT * FROM [Offers] ";
                                    // Program.xdata.Open();
                                    using (var reader = command.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            Program.xoffer.avail = true;
                                        }
                                    }
                                }
                                Program.xdata.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                            for (int i = 0; i < item.Count; i++)
                            {
                                if (exp[i] != "")
                                {
                                    var now = DateTime.Parse(exp[i]);


                                    if (date.AddDays(30) >= now)
                                    {
                                        exitem.Add(item[i]);
                                        exexp.Add(exp[i]);
                                    }
                                }
                            }
                            timer1.Start();
                    }
                   
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    this.Hide();
                    
                        }
                    else
                    {
                        Program.xcash.cashier = textBox3.Text;
                            Program.xcash.Cash_Load_1(sender, e);
                            Program.xcash.Show();
                            string name = "";
                            string quantity = "";
                            string expiry = "";
                            string wprice = "";
                            string sprice = "";
                            DateTime date = DateTime.Now;
                            try
                            {
                                DataTable dt1 = new DataTable();
                                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] ", Program.xdata);
                                Program.xdata.Open();
                                SDA.Fill(dt1);

                                // Program.xdata.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                            try
                            {
                                using (var command = Program.xdata.CreateCommand())
                                {
                                    command.CommandText = "SELECT * FROM [Items] ";
                                    // Program.xdata.Open();
                                    using (var reader = command.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            name = reader["I_Name"].ToString();
                                            quantity = reader["I_Quantity"].ToString();
                                            expiry = reader["I_Expirydate"].ToString();
                                            wprice = reader["I_Wholesaleprice"].ToString();
                                            sprice = reader["I_sellingprice"].ToString();
                                            item.Add(name);
                                            exp.Add(expiry);
                                            string q2 = Program.xsource;
                                            SqlConnection cn2 = new SqlConnection(q2);
                                            SqlCommand cmd2 = new SqlCommand("INSERT INTO [inventory](i_name,i_quantity,date,i_wholeprice,i_sellingprice,i_expirydate)VALUES (@name,@quantity,@date,@wprice,@sprice,@expiry)", cn2);
                                            cmd2.Parameters.AddWithValue("@name", name);
                                            cmd2.Parameters.AddWithValue("@quantity", quantity);
                                            cmd2.Parameters.AddWithValue("@date", date);
                                            cmd2.Parameters.AddWithValue("@wprice", wprice);
                                            cmd2.Parameters.AddWithValue("@sprice", sprice);
                                            cmd2.Parameters.AddWithValue("@expiry", expiry);
                                            cn2.Open();
                                            SqlDataReader dr2 = cmd2.ExecuteReader();
                                        }
                                    }
                                }
                                Program.xdata.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                            try
                            {
                                DataTable dt1 = new DataTable();
                                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Offers] ", Program.xdata);
                                Program.xdata.Open();
                                SDA.Fill(dt1);

                                // Program.xdata.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                            try
                            {
                                using (var command = Program.xdata.CreateCommand())
                                {
                                    command.CommandText = "SELECT * FROM [Offers] ";
                                    // Program.xdata.Open();
                                    using (var reader = command.ExecuteReader())
                                    {
                                        if (reader.Read())
                                        {
                                            Program.xoffer.avail = true;
                                        }
                                    }
                                }
                                Program.xdata.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                            for (int i = 0; i < item.Count; i++)
                            {
                                if (exp[i] != "")
                                {
                                    var now = DateTime.Parse(exp[i]);


                                    if (date.AddDays(30) >= now)
                                    {
                                        exitem.Add(item[i]);
                                        exexp.Add(exp[i]);
                                    }
                                }
                            }
                            timer1.Start();
                    }
                   
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    this.Hide();
                    
                    }
        }

        private void buttonhelp1_Click(object sender, EventArgs e)
        {
            Program.xhelp.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                buttonlogin1_Click((object)sender, (EventArgs)e);   
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        int fff = 0;
        int dd = 1;
        int yyy = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 60000;
            if (fff == dd &&yyy < exitem.Count)
            {
                dd = dd * 2;
                Program.xmsg.expiry(exitem[yyy],(DateTime.Parse( exexp[yyy]).Date).ToShortDateString());
                Program.xmsg.Show();
                yyy++;
            }
            if (fff == exitem.Count)
            {
                timer1.Stop();
            }
            fff++;
        }
    }
}
