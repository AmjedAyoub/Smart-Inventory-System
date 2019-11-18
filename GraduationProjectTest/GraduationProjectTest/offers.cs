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
    public partial class offers : Form
    {
        public static string ss = "";
        public static string ee = "";
        public static string xxx = "";
        public Boolean avail = false;
        public offers()
        {
            InitializeComponent();
        }

        private void offers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet16.Offers' table. You can move, or remove it, as needed.
            this.offersTableAdapter.Fill(this.database1DataSet16.Offers);

        }
        public void available()
         {
             if (!avail)
             {
                 panel1.Visible = true;
                 panel1.Show();
                 panel2.Visible = false;
                 panel2.Hide();
                 panel3.Visible = false;
                 panel3.Hide();
             }
             else
             {
                 panel1.Visible = false;
                 panel1.Hide();
                 panel2.Visible = true;
                 panel2.Show();
                 panel3.Visible = false;
                 panel3.Hide();
                 string dd = "";
                 string date1="";
                 string  date2="";
                 string nnn = "";
                 string now = DateTime.Now.Date.ToShortDateString();
                 try
                 {
                     DataTable dt = new DataTable();
                     SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [butn]", Program.xdata);
                     Program.xdata.Open();
                     SDA.Fill(dt);
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message.ToString());
                 }
                 using (var command = Program.xdata.CreateCommand())
                 {
                     command.CommandText = "SELECT * FROM [butn] ";
                     // con1.Open();
                     using (var reader = command.ExecuteReader())
                     {
                         while (reader.Read())
                         {
                            dd = reader["bid"].ToString();
                             date1 = DateTime.Parse( reader["enddate"].ToString()).Date.ToShortDateString();
                             date2 = DateTime.Parse(reader["startdate"].ToString()).Date.ToShortDateString();
                             nnn = reader["bname"].ToString();
                             if (DateTime.Parse( date1).Day < DateTime.Parse(now).Day&&DateTime.Parse( date1).Year < DateTime.Parse(now).Year)
                             {
                                 string q1 = Program.xsource;
                                 SqlConnection cn1 = new SqlConnection(q1);
                                 SqlCommand cmd1 = new SqlCommand("DELETE FROM [Offers] WHERE O_Name = '" + nnn + "'", cn1);
                                 cn1.Open();
                                 SqlDataReader dr1 = cmd1.ExecuteReader();
                             }
                             else
                             {
                                 if (dd == "b1")
                                 {
                                     b1.Text = nnn;
                                     if (nnn == "")
                                         b1.Visible = false;
                                     else
                                         b1.Visible = true;
                                 }
                                 else if (dd == "b2")
                                 {
                                     b2.Text = nnn;
                                     if (nnn == "")
                                         b2.Visible = false;
                                     else
                                         b2.Visible = true;
                                 }
                                 else if (dd == "b3")
                                 {
                                     b3.Text = nnn;
                                     if (nnn == "")
                                         b3.Visible = false;
                                     else
                                         b3.Visible = true;
                                 }
                                 else if (dd == "b4")
                                 {
                                     b4.Text = nnn;
                                     if (nnn == "")
                                         b4.Visible = false;
                                     else
                                         b4.Visible = true;
                                 }
                                 else if (dd == "b5")
                                 {
                                     b5.Text = nnn;
                                     if (nnn == "")
                                         b5.Visible = false;
                                     else
                                         b5.Visible = true;
                                 }
                                 else if (dd == "b6")
                                 {
                                     b6.Text = nnn;
                                     if (nnn == "")
                                         b6.Visible = false;
                                     else
                                         b6.Visible = true;
                                 }
                                
                             }
                            


                         }
                     }
                 }

                 Program.xdata.Close();
             }
         }
        public void availman()
        {
            if (!avail)
            {
                panel1.Visible = true;
                panel1.Show();
                panel2.Visible = false;
                panel2.Hide();
                panel3.Visible = false;
                panel3.Hide();
            }
            else
            {
                panel1.Visible = false;
                panel1.Hide();
                panel2.Visible = false;
                panel2.Show();
                panel3.Visible = true;
                panel3.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        string id = "";
        public void create(string x,string start,string end)
        {
            xxx=x;
            ss = start;
            ee = end;
            if (b1.Text.Equals( ""))
            {
                id = "b1";
                ccc();
            }
            else if (b2.Text.Equals(""))
            {
                id = "b2";
                ccc();
            }
            else if (b3.Text.Equals(""))
            {
                id = "b3";
                ccc();
            }
            else if (b4.Text.Equals(""))
            {
                id = "b4";
                ccc();
            }
            else if (b5.Text.Equals(""))
            {
                id = "b5";
                ccc();
            }
            else if (b6.Text.Equals(""))
            {
                id = "b6";
                ccc();
            }
            else
                MessageBox.Show("You have to delete some offers");
         }
        
        public void ccc()
        {
            string q1 = Program.xsource;
            SqlConnection cn1 = new SqlConnection(q1);
            SqlCommand cmd1 = new SqlCommand("UPDATE [butn] SET bname=@xxx,startdate=@ss,enddate=@ee WHERE bid = '" + id + "'", cn1);
            cmd1.Parameters.AddWithValue("@xxx", xxx);
            cmd1.Parameters.AddWithValue("@ss", ss);
            cmd1.Parameters.AddWithValue("@ee", ee);
            cn1.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                Program.xcash.offer(btn.Text);
            }
        }

        private void b1_Click(object sender, EventArgs e)
        {
            Program.xcash.offer(b1.Text);
        }

        private void b2_Click(object sender, EventArgs e)
        {
            Program.xcash.offer(b2.Text);
        }

        private void b3_Click(object sender, EventArgs e)
        {
            Program.xcash.offer(b3.Text);
        }

        private void b4_Click(object sender, EventArgs e)
        {
            Program.xcash.offer(b4.Text);
        }

        private void b5_Click(object sender, EventArgs e)
        {
            Program.xcash.offer(b5.Text);
        }

        private void b6_Click(object sender, EventArgs e)
        {
            Program.xcash.offer(b6.Text);
        }

    }
}
