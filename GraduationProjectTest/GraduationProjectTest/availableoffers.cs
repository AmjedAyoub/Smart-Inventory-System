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
    public partial class availableoffers : Form
    {
        public static Boolean a = false;
        List<string> item = new List<string>();
        List<string> exp = new List<string>();
        List<string> exitem = new List<string>();
        List<string> exexp = new List<string>();
        string max = "";
        string min = "";
        string maxpr = "";
        string minpr = "";
        string maxwpr = "";
        string minwpr = "";

        public availableoffers()
        {
            InitializeComponent();
        }

        private void availableoffers_Load(object sender, EventArgs e)
        {

        }

        public void view()
        {
           

            

            int c2 = 0;

            int mn2 = 0;

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
                int c1 = 0;
                int mn1 = 0;
                try
                {
                    DataTable dt11 = new DataTable();
                    SqlDataAdapter SDA1 = new SqlDataAdapter("SELECT * FROM [Sales] where I_Name like '" + item[i] + "'", Program.xdata);
                    Program.xdata.Open();
                    SDA1.Fill(dt11);

                    // Program.xdata.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                try
                {
                    using (var command1 = Program.xdata.CreateCommand())
                    {
                        command1.CommandText = "SELECT * FROM [Sales] where I_Name like '" + item[i] + "'";
                        // Program.xdata.Open();
                        using (var reader1 = command1.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                c1++;
                                mn1++;
                            }
                            if (c1 > c2)
                            {
                                c2 = c1;
                                max = name;
                                maxpr = sprice;
                                maxwpr = wprice;
                            }
                            if (mn2 < mn1)
                            {
                                mn2 = mn1;
                                min = name;
                                minpr = sprice;
                                minwpr = wprice;
                            }
                        }
                    }
                    Program.xdata.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

            for (int ii = 0; ii < item.Count; ii++)
            {
                if (exp[ii] != "")
                {
                    var now = DateTime.Parse(exp[ii]);


                    if (date.AddDays(30) >= now)
                    {
                        exitem.Add(item[ii]);
                        exexp.Add(exp[ii]);
                    }
                }
            }

            if (exitem.Count > 0)
            {
                int xx = 25;
                int yy = 20;
                for (int k = 0; k < exitem.Count; k++)
                {
                    if (k < 9)
                    {
                        if (xx > 565)
                        {
                            xx = 25;
                            yy = yy + 50;
                        }
                        RadioButton r = new RadioButton();
                        r.Visible = true;
                        r.Name = r.ToString();
                        r.Size = new Size(130, 30);
                        r.ForeColor = Color.LimeGreen;
                        r.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        r.Location = new Point(xx, yy);
                        r.Text = "Offer " + (k + 1);
                        panel1.Controls.Add(r);
                        xx = xx + 270;
                    }
                }
            }
             
           
            if (date.Day == 28)
            {
                RadioButton r = new RadioButton();
                r.Visible = true;
                r.Name = r.ToString();
                r.Size = new Size(300, 30);
                r.ForeColor = Color.LimeGreen;
                r.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                r.Location = new Point(300, 20);
                r.Text = "Offer of the least sold item";
                panel2.Controls.Add(r);
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control item in panel1.Controls)
            {
                if (item is RadioButton)
                {
                    RadioButton rb = (RadioButton)item;
                    if (rb.Checked)
                    {
                        if (rb.Text == "Offer 1")
                        {
                            Program.xsgg.off(exitem[0], max,a);
                            Program.xmanager.sugg();
                        }
                        else if (rb.Text == "Offer 2")
                        {
                            Program.xsgg.off(exitem[1], max,a);
                            Program.xmanager.sugg();

                        }
                        else if (rb.Text == "Offer 3")
                        {
                            Program.xsgg.off(exitem[2], max,a);
                            Program.xmanager.sugg();

                        }
                        else if (rb.Text == "Offer 4")
                        {
                            Program.xsgg.off(exitem[3], max,a);
                            Program.xmanager.sugg();

                        }
                        else if (rb.Text == "Offer 5")
                        {
                            Program.xsgg.off(exitem[4], max,a);
                            Program.xmanager.sugg();
                        }
                        else if (rb.Text == "Offer 6")
                        {
                            Program.xsgg.off(exitem[5], max,a);
                            Program.xmanager.sugg();

                        }
                        else if (rb.Text == "Offer 7")
                        {
                            Program.xsgg.off(exitem[6], max,a);
                            Program.xmanager.sugg();

                        }
                        else if (rb.Text == "Offer 8")
                        {
                            Program.xsgg.off(exitem[7], max,a);
                            Program.xmanager.sugg();

                        }
                        else if (rb.Text == "Offer 9")
                        {
                            Program.xsgg.off(exitem[8], max,a);
                            Program.xmanager.sugg();
                        }



                    }
                }
            }
            foreach (Control item in panel2.Controls)
            {
                if (item is RadioButton)
                {
                    RadioButton rb = (RadioButton)item;
                    if (rb.Checked)
                    {
                        if (rb.Text == "Offer of the least sold item")
                        {
                            a = true;
                            Program.xsgg.off(min, max,a);
                            Program.xsgg.Show();
                           
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            item.Clear();
            exitem.Clear();
            exexp.Clear();
            exp.Clear();
            this.Dispose(false);
            this.Hide();
        }
    }
}

