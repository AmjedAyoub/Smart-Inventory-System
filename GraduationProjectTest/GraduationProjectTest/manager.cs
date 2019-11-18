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
    public partial class manager : Form
    {
        public static List<string> item = new List<string>();
        public static List<string> exp = new List<string>();
        public static List<string> exitem = new List<string>();
        public static List<string> exexp = new List<string>();
        public static List<string> min = new List<string>();
        public static List<string> exmin = new List<string>();
        public static List<string> quan = new List<string>();
        public static List<string> exquan = new List<string>();

        public manager()
        {
            InitializeComponent();
           
        }

       

        private void manager_Load(object sender, EventArgs e)
        {

        }

       
      
        private void addNewEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear(); 
            Program.xaddemp.TopLevel = false;
            Program.xaddemp.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xaddemp);
        }

        private void edistEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear(); 
            Program.xeditemp.TopLevel = false;
            Program.xeditemp.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xeditemp);
        }

        private void showEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xshowemp.TopLevel = false;
            Program.xshowemp.Visible = true;
           //- Program.xshowemp.Showemployee_Load(sender,e);
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xshowemp);
        }

        private void deleteEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xdeleteemp.TopLevel = false;
            Program.xdeleteemp.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xdeleteemp);
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xadditem.TopLevel = false;
            Program.xadditem.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xadditem);
        }

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xedititem.TopLevel = false;
            Program.xedititem.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xedititem);
        }

        private void deleteItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xdeleteitem.TopLevel = false;
            Program.xdeleteitem.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xdeleteitem);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        public void name(string x)
        {
            label2.Text = x.ToUpper();
        }

        private void toolStripMenuItem37_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show( "Are you sure you want to Logout?", "Confirmation Window", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                this.Hide();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            label8.Text = DateTime.Now.ToLongTimeString();
            label9.Text = DateTime.Now.ToLongDateString();
        }

        private void buyItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xbuyl.TopLevel = false;
            Program.xbuyl.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xbuyl);
        }


        private void monthlyInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xminventory.TopLevel = false;
            Program.xminventory.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xminventory);
        }

        private void yearlyInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xyinventory.TopLevel = false;
            Program.xyinventory.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xyinventory);
        }

        private void viewByItemNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Program.xviewava.Show();



            panel1.Controls.Clear();
            Program.xviewava.TopLevel = false;
            Program.xviewava.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xviewava);
        }

        private void viewASpecificItemDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Program.xviewspec.Show();
            panel1.Controls.Clear();
            Program.xviewspec.TopLevel = false;
            Program.xviewspec.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xviewspec);
        }

        private void viewDailySalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // Program.xmandaily.Show();

            panel1.Controls.Clear();
            Program.xmandaily.TopLevel = false;
            Program.xmandaily.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xmandaily);

        }

        private void viewSalesInASpecificPeriodToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // Program.xmanspec.Show();

            panel1.Controls.Clear();
            Program.xmanspec.TopLevel = false;
            Program.xmanspec.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xmanspec);
        }

        private void viewMonthlySalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // Program.xmanmonth.Show();

            panel1.Controls.Clear();
            Program.xmanmonth.TopLevel = false;
            Program.xmanmonth.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xmanmonth);
        }

        private void viewYearlySalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // Program.xmanyear.Show();

            panel1.Controls.Clear();
            Program.xmanyear.TopLevel = false;
            Program.xmanyear.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xmanyear);
        }

        private void viewSalesForSpecificItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Program.xsalesspec.Show();

            panel1.Controls.Clear();
            Program.xsalesspec.TopLevel = false;
            Program.xsalesspec.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xsalesspec);
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Program.xmanbuy.Show();

            panel1.Controls.Clear();
            Program.xmanbuy.TopLevel = false;
            Program.xmanbuy.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xmanbuy);
        }

        private void showBuyingListInASpecificPeriodToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // Program.xmanbuyspec.Show();

            panel1.Controls.Clear();
            Program.xmanbuyspec.TopLevel = false;
            Program.xmanbuyspec.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xmanbuyspec);
        }

        private void sallaryPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xsallary.TopLevel = false;
            Program.xsallary.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xsallary);
        }

        private void buyItemToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xbuyl.TopLevel = false;
            Program.xbuyl.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xbuyl);
        }

        private void showOffersListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xoffer.TopLevel = false;
            Program.xoffer.Visible = true;
            this.Controls.Add(panel1);
            Program.xoffer.availman();
            panel1.Controls.Add(Program.xoffer);
        }

        public void showAvailableOffersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xavaoffer.TopLevel = false;
            Program.xavaoffer.Visible = true;
            this.Controls.Add(panel1);
            Program.xavaoffer.view();
            panel1.Controls.Add(Program.xavaoffer);
        }
        public void sugg2()
        {
            panel1.Controls.Clear();
            Program.xavaoffer.TopLevel = false;
            Program.xavaoffer.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xavaoffer);
        }

        public void sugg()
        {
            panel1.Controls.Clear();
            Program.xsgg.TopLevel = false;
            Program.xsgg.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xsgg);
        }


        private void makeAnOfferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xmakeoffer.TopLevel = false;
            Program.xmakeoffer.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xmakeoffer);
        }

        private void toolStripMenuItem34_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xmanpassch.TopLevel = false;
            Program.xmanpassch.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xmanpassch);

        }

        private void monthlyProfitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xmprofit.TopLevel = false;
            Program.xmprofit.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xmprofit);
        }

        private void yearlyProfitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xyprofit.TopLevel = false;
            Program.xyprofit.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xyprofit);
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xinexpenses.TopLevel = false;
            Program.xinexpenses.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xinexpenses);
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xvexpenses.TopLevel = false;
            Program.xvexpenses.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xvexpenses);
        }

       

        private void salesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xsalesChart.TopLevel = false;
            Program.xsalesChart.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xsalesChart);
        }

        private void netprofitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xnetProfit.TopLevel = false;
            Program.xnetProfit.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xnetProfit);
        }

        private void deliveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Program.xdeliveryChart.TopLevel = false;
            Program.xdeliveryChart.Visible = true;
            this.Controls.Add(panel1);
            panel1.Controls.Add(Program.xdeliveryChart);
        }

        public void mesag()
        {
            string name = "";
            string quantity = "";
            string expiry = "";
            string wprice = "";
            string sprice = "";
            string minvalue = "";
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
                            minvalue=reader["I_Minvalue"].ToString();
                            item.Add(name);
                            exp.Add(expiry);
                            min.Add(minvalue);
                            quan.Add(quantity);
                            
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
                    if (double.Parse(quan[i]) <= double.Parse(min[i]))
                    {
                        exquan.Add(quan[i]);
                        exmin.Add(item[i]);
                    }

                
            }
            if (exquan.Count > 0)
            {
                label3.Text = "You have only " + exquan[v] + " of " + exmin[v] + " !!!   *** ";
                label3.Location = new Point(1165, 16);
                v++;
            }
            else
                label3.Text = "";
            if (exitem.Count > 0)
            {
                label5.Text = " The " + exitem[h] + " will expire on " + DateTime.Parse(exexp[h]).ToShortDateString() + " !!!   *** ";
                label5.Location = new Point(label3.Location.X+label3.Width, 16);
                h++;
            }
            else
                label5.Text = "";
            if ((exitem.Count > 0) || (exquan.Count > 0))
            {

                label4.Text = " ***   THE WERAHOUSE STATUS   *** ";
                label4.Location = new Point(260, 16);
                timer2.Start();
                timer3.Start();
            }
            else
            {
                ss = true;
                label4.Text = " ***   THE WERAHOUSE STATUS   *** THERE IS NO ITEMS UNDER THE LIMIT *** ";
                label4.Location = new Point(260, 16);
               // timer2.Start();
                timer3.Start();
            }
        }
        int dd = 1165;
        int v = 0;
        int h = 0;
       
        private void timer2_Tick(object sender, EventArgs e)
        {
            
            timer2.Interval = 10;
            if (dd == -(label5.Width+label3.Width))
            {
                dd = 1165;
                label3.Location = new Point(dd, 16);
                label5.Location = new Point(label3.Location.X + label3.Width, 16);
               
                    if (v < exmin.Count)
                    {
                        label3.Text = " You have only " + exquan[v] + " of " + exmin[v] + " !!!   *** ";
                        v++;
                    }
                    else if(exmin.Count>0)
                    {
                        v=0;
                        label3.Text = " You have only " + exquan[v] + " of " + exmin[v] + " !!!   *** ";
                        
                    }
                    if (h < exitem.Count)
                    {
                        label5.Text = " The " + exitem[h] + " will expire on " + DateTime.Parse(exexp[h]).ToShortDateString() + " !!!   *** ";
                        h++;
                    }
                    else
                        if (exitem.Count>0)
                    {
                      h=0;
                       label5.Text = " The " + exitem[h] + " will expire on " + DateTime.Parse(exexp[h]).ToShortDateString() + " !!!   *** ";
                       
                    }
                

            }
            else
            {
                dd = dd - 1;
                label3.Location = new Point(dd, 16);
                label5.Location = new Point(label3.Location.X + label3.Width, 16);
            }

        }
        int u = 0;
        Boolean ss = false;
        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Interval = 10;
            if (u > 50 && u < 99)
            {
                label4.Text="";
            }
            else
            {
                if (ss)
                {
                    label4.Text = " ***   THE WERAHOUSE STATUS   *** THERE IS NO ITEMS UNDER THE LIMIT *** ";
                }
                else
                {
                    label4.Text = " ***   THE WERAHOUSE STATUS   *** ";
                }
            }
            if (u == 100)
            {
                u = 0;
            }
            u++;
            if (!ss)
            {
                if (label5.Location.X + label5.Width < 240 || label3.Location.X>280+label5.Width)
                {
                    label4.Visible = true;
                    label4.Location = new Point(260, 16);
                }
                else
                    label4.Visible=false;
            }
            else
                label4.Location = new Point(260, 16);
        }
    }
}
