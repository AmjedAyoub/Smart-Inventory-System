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
using System.Data.Odbc;
using System.Configuration;


namespace GraduationProjectTest
{
    public partial class Cash : Form
    {      
        AutoCompleteStringCollection namesCollection = new AutoCompleteStringCollection();
        public bool visa = false;
        public string cashiername;
        public double itemprice;
        public string menues;
        public bool p1 = false;
        public bool p2 = false;
        public bool p3 = false;
        public bool p4 = false;
        public bool p5 = false;
        public int count = 0;
        public string cashier;
        public Button objbtnname;
        public string itempricedata = "";
        public List<string> name = new List<string>();
        public List<string> price = new List<string>();
        public List<string> quantity = new List<string>();
        public string total = "";

        public Cash()
        {
            InitializeComponent();
        }

        private void addcus_btn_Click(object sender, EventArgs e)
        {
            Program.xaddcus.Show();
        }

        private void searchname_btn_Click(object sender, EventArgs e)
        {
            string first="";
            string last="";
            int i = 0;
            int s = textBox2.Text.Length;
            while (textBox2.Text[i].ToString() != " ")
                i++;
            first = textBox2.Text.Substring(0, i);
            last = textBox2.Text.Substring(i + 1, s - 1 - i);

            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT  C_FirstName + ' ' + C_LastName AS name FROM Customer WHERE C_FirstName LIKE '" + textBox2.Text + "' AND C_LastName LIKE '" + textBox2.Text + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
             using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT C_FirstName, C_LastName,C_Contactnumber ,C_Stname,C_Bildingnum, C_City , C_Floor , C_Apartment FROM [Customer] where C_FirstName + ' ' + C_LastName like '" + textBox2.Text + "'";
               // Program.xdata.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textBox2.Text = reader["C_FirstName"].ToString() + " " + reader["C_LastName"].ToString();
                        textBox3.Text = reader["C_Contactnumber"].ToString();
                        textBox4.Text = "City: " + reader["C_City"].ToString() + "   " + "StrName: " + reader["C_Stname"].ToString() + "\t" + "Bilding No.: " + reader["C_Bildingnum"].ToString() + "   " + " Floor: " + reader["C_Floor"].ToString() + "\t" + "\t" + "Apartment: " + reader["C_Apartment"].ToString();

                    }
                }
            }
             Program.xdata.Close();
        }

        private void phonesearch_btn_Click(object sender, EventArgs e)
        {
            try
            {
                 DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Customer] where C_Contactnumber like '" + textBox3.Text + "'", Program.xdata);
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
                command.CommandText = "SELECT C_FirstName,C_LastName ,C_Stname,C_Bildingnum, C_City , C_Floor , C_Apartment FROM [Customer] where C_Contactnumber like '" + textBox3.Text + "'";
               // Program.xdata.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        textBox2.Text = reader["C_FirstName"].ToString() + " " + reader["C_LastName"].ToString();
                        textBox4.Text = "City: " + reader["C_City"].ToString() + "   " + "StrName: " + reader["C_Stname"].ToString() + "\t" + "Bilding No.: " + reader["C_Bildingnum"].ToString() + "   " + " Floor: " + reader["C_Floor"].ToString() + "\t" + "\t" + "Apartment: " + reader["C_Apartment"].ToString();

                    }
                }
            }
            Program.xdata.Close();

        }

        private void discount_btn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Program.xdiscount.disbill = double.Parse(textBox1.Text);
                Program.xdiscount.display_bill();
                Program.xdiscount.Show();
            }
        }

        private void cls_btn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            count = 0;
            textBox1.Clear();
            textBox5.Clear();

        }

        private void del_btn_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            if (row < count && count != 0)
            {
                if ((dataGridView1.Rows[row].Cells[0].Value.ToString() != "Discount" && dataGridView1.Rows[row].Cells[2].Value.ToString().Equals("1")))
                {
                    string x = dataGridView1.Rows[row].Cells[1].Value.ToString();
                    if (x != "")
                    {
                        double txt = double.Parse(textBox1.Text);
                        double grid = double.Parse(x);
                        dataGridView1.Rows.RemoveAt(row);
                        count--;
                        dataGridView1.Rows.Add();
                        textBox1.Text = (txt - grid).ToString();
                    }
                }
                else  if (dataGridView1.Rows[row].Cells[0].Value.ToString().Equals( "Discount"))
                    {
                        double txt = double.Parse(textBox1.Text);
                        dataGridView1.Rows.RemoveAt(row);
                        count--;
                        dataGridView1.Rows.Add();
                        textBox1.Text = (txt + tot).ToString();
                    }
                else if (dataGridView1.Rows[row].Cells[2].Value.ToString() != "1")
                {
                    double txt = double.Parse(textBox1.Text);
                    string s = dataGridView1.Rows[row].Cells[2].Value.ToString();
                    string s2 = dataGridView1.Rows[row].Cells[1].Value.ToString();
                    dataGridView1.Rows.RemoveAt(row);
                    count--;
                    dataGridView1.Rows.Add();
                    textBox1.Text=(txt-(double.Parse(s2)*int.Parse(s))).ToString();
                }
                
            }
        }

        private void editcus_btn_Click(object sender, EventArgs e)
        {
            Program.xeditcus.Show();
        }

        private void savecash_btn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Program.xcashkeyb.bill = double.Parse(textBox1.Text);
                Program.xcashkeyb.display_bill();
                Program.xcashkeyb.cashkeybourd_Load(sender, e);
                Program.xcashkeyb.Show();
            }
        }

        public void save_cash()
        {
            int i = 0;
            string disc = "";
            string tax = "16%";
            string item = "";
            string wholprice = "";
            string sellingprice = "";
            string del = "";
            string last = "";
            string first = "";
            string price = "";
            string quantity = "";
            string sum = "";
            string id = "";
            string netprofit = "";
            string cashier = cashername_lbl.Text;
            string custom = DateTime.Now.ToLongTimeString().ToString();
            int s = textBox2.Text.Length;
            string num = textBox3.Text;
            if (textBox2.Text != "")
            {
                while (textBox2.Text[i].ToString() != " ")
                    i++;
                first = textBox2.Text.Substring(0, i);
                last = textBox2.Text.Substring(i + 1, s - 1 - i);
            }

            DateTime date = DateTime.Now;
            for (int x = 0; x < count; x++)
            {
                if (dataGridView1.Rows[x].Cells[0].Value.ToString() == "Discount")
                    disc = dataGridView1.Rows[x].Cells[1].Value.ToString();
                else if (dataGridView1.Rows[x].Cells[0].Value.ToString() == "Delivery")
                    del = "Yes";
                else
                {
                    string qqqq = "";
                    string min = "";
                    string yyyy = dataGridView1.Rows[x].Cells[0].Value.ToString();
                    item = item + " " + dataGridView1.Rows[x].Cells[0].Value.ToString();
                    price = price + " " + dataGridView1.Rows[x].Cells[1].Value.ToString();
                    quantity = quantity + " " + dataGridView1.Rows[x].Cells[2].Value.ToString();
                    sum = dataGridView1.Rows[x].Cells[1].Value.ToString();
                    try
                    {
                        DataTable dt = new DataTable();
                        SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] where I_Name like '" + dataGridView1.Rows[x].Cells[0].Value.ToString() + "'", Program.xdata);
                        Program.xdata.Open();
                        SDA.Fill(dt);

                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    using (var command = Program.xdata.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM [Items] where I_Name like '" + dataGridView1.Rows[x].Cells[0].Value.ToString() + "'";
                        //Program.xdata.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                id = reader["I_ID"].ToString();
                                wholprice = reader["I_Wholesaleprice"].ToString();
                                sellingprice = reader["I_sellingprice"].ToString();
                                netprofit = ((double.Parse(sellingprice)) - (double.Parse(wholprice))).ToString();
                                qqqq = reader["I_Quantity"].ToString();
                                min = reader["I_Minvalue"].ToString();
                            }
                        }
                    }
                    
                        if (Convert.ToInt32(min) != 0)
                        {
                            if ((int.Parse(qqqq) - int.Parse(dataGridView1.Rows[x].Cells[2].Value.ToString())) >= 0)
                            {
                                qqqq = (int.Parse(qqqq) - int.Parse(dataGridView1.Rows[x].Cells[2].Value.ToString())).ToString();
                            }
                                if (int.Parse(qqqq) <= int.Parse(min))
                                {
                                    Program.xmsg.msg(dataGridView1.Rows[x].Cells[0].Value.ToString(), qqqq);
                                    Program.xmsg.Show();
                                }
                        }
                        else
                            qqqq = (int.Parse(qqqq) - int.Parse(dataGridView1.Rows[x].Cells[2].Value.ToString())).ToString();
                  
                    
                     string q1111 = Program.xsource;
                    SqlConnection cn1111 = new SqlConnection(q1111);
                    SqlCommand cmd11111 = new SqlCommand("UPDATE [Items] SET I_Quantity=@qqqq WHERE I_Name = '" + yyyy + "'", cn1111);
                    cmd11111.Parameters.AddWithValue("@qqqq", qqqq);
                    cn1111.Open();
                    SqlDataReader dr1111 = cmd11111.ExecuteReader();

                    string q22 = Program.xsource;
                    SqlConnection cn22 = new SqlConnection(q22);
                    SqlCommand cmd22 = new SqlCommand("INSERT INTO [Sales](S_Date,I_Name,I_ID,S_Netprofit,S_Sum)VALUES (@date,@textBox6,@id,@netprofit,@sum)", cn22);
                    cmd22.Parameters.AddWithValue("@textBox6", dataGridView1.Rows[x].Cells[0].Value.ToString());
                    cmd22.Parameters.AddWithValue("@id", id);
                    cmd22.Parameters.AddWithValue("@date", date);
                    cmd22.Parameters.AddWithValue("@netprofit", netprofit);
                    cmd22.Parameters.AddWithValue("@sum", sum);
                    cn22.Open();
                    SqlDataReader dr22 = cmd22.ExecuteReader();
                }

                Program.xdata.Close();
            }


            string q2 = Program.xsource;
            SqlConnection cn2 = new SqlConnection(q2);
            SqlCommand cmd2 = new SqlCommand("INSERT INTO [Billing](B_Date,B_Time,B_Netamount,B_Discount,B_Addedtax,C_FirstName,C_LastName,C_Num,C_Address,I_Name,Delivery,I_Price,I_Quantity,I_Cashier)VALUES (@date,@custom,@textBox1,@disc,@tax,@first,@last,@num,@textBox4,@item,@del,@price,@quantity,@cashier)", cn2);
            cmd2.Parameters.AddWithValue("@date", date);
            cmd2.Parameters.AddWithValue("@textBox1", textBox1.Text);
            cmd2.Parameters.AddWithValue("@disc", disc);
            cmd2.Parameters.AddWithValue("@tax", tax);
            cmd2.Parameters.AddWithValue("@first", first);
            cmd2.Parameters.AddWithValue("@last", last);
            cmd2.Parameters.AddWithValue("@textBox4", textBox4.Text);
            cmd2.Parameters.AddWithValue("@item", item);
            cmd2.Parameters.AddWithValue("@del", del);
            cmd2.Parameters.AddWithValue("@price", price);
            cmd2.Parameters.AddWithValue("@quantity", quantity);
            cmd2.Parameters.AddWithValue("@cashier", cashier);
            cmd2.Parameters.AddWithValue("@custom", custom);
            cmd2.Parameters.AddWithValue("@num", num);
            cn2.Open();
            SqlDataReader dr2 = cmd2.ExecuteReader();
            if (visa)
            {
                string q23 = Program.xsource;
                SqlConnection cn23 = new SqlConnection(q23);
                SqlCommand cmd23 = new SqlCommand("INSERT INTO [Visa](B_Amount,B_Date,B_Time,Cashier)VALUES (@textBox1,@date,@custom,@cashier)", cn23);
                cmd23.Parameters.AddWithValue("@date", date);
                cmd23.Parameters.AddWithValue("@textBox1", textBox1.Text);
                cmd23.Parameters.AddWithValue("@cashier", cashier);
                cmd23.Parameters.AddWithValue("@custom", custom);
                cn23.Open();
                SqlDataReader dr23 = cmd23.ExecuteReader();
                visa = false;
            }

            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            count = 0;
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        public void display_reminder()
        {
            textBox5.Text = Program.xcashkeyb.Reminder.ToString();
        }
        public double tot;
        public void dis_reminder(string x, string y,double z)
        {
            dataGridView1.Rows.Insert(count, "Discount", x + y, "1");
            textBox1.Text = Program.xdiscount.disReminder.ToString();
            tot = z;
            count++;
        }

        private void manager_btn_Click(object sender, EventArgs e)
        {
            Program.xmanagpass.Show();
        }

        private void nextextra_btn_Click(object sender, EventArgs e)
        {
            if (p1 == true)
            {


                tabControl1.SelectedIndex = 1;
                p1 = false;
                p2 = true;


            }
            else if (p2 == true)
            {

                tabControl1.SelectedIndex = 2;
                p2 = false;
                p3 = true;
            }
            else if (p3 == true)
            {

                tabControl1.SelectedIndex = 3;
                p3 = false;
                p4 = true;
            }
            else if (p4 == true)
            {
                tabControl1.SelectedIndex = 4;
                p4 = false;
                p5 = true;
            }

        }

        private void previousextra_btn_Click(object sender, EventArgs e)
        {

            if (p5 == true)
            {
                tabControl1.SelectedIndex = 3;
                p4 = true;
                p5 = false;

            }
            else if (p4 == true)
            {
                tabControl1.SelectedIndex = 2;
                p4 = false;
                p3 = true;
            }
            else if (p3 == true)
            {
                tabControl1.SelectedIndex = 1;
                p3 = false;
                p2 = true;
            }
            else if (p2 == true)
            {
                tabControl1.SelectedIndex = 0;
                p2 = false;
                p1 = true;
            }
        }

        private void Opcash_btn_Click(object sender, EventArgs e)
        {
            Program.xpassword.Show();
        }

        private void Menus_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip mnu = new ContextMenuStrip();
                ToolStripMenuItem renamemenu = new ToolStripMenuItem("Rename The Menu");
                renamemenu.Click += new EventHandler(renamemenu_Click);
                mnu.Items.AddRange(new ToolStripItem[] { renamemenu });
                mnu.Show(Menus, e.X, e.Y);
            }
        }

        private void renamemenu_Click(object sender, EventArgs e)
        {
            Program.xchangmenu.Show();
        }

        private void exitcash_btn_Click(object sender, EventArgs e)
        {
            if (Program.closecashe)
            {
                if ((MessageBox.Show("This will close the program " + "\n" + "Are you sure you want to Exit", "Confirmation Window", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    Program.closecashe = false;
                    Application.Exit();
                }
            }
            else
                MessageBox.Show("You cant exit you have to close the cash first !!!");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                Program.xcashkeyb.bill = double.Parse(textBox1.Text);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            pricedata(button30.Text);
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            label8.Text = DateTime.Now.ToLongTimeString();
            label9.Text = DateTime.Now.ToLongDateString();

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }
    
        private void map_btn_Click(object sender, EventArgs e)
        {
            Program.xmaps.Show();
        }
        private void button29_Click(object sender, EventArgs e)
        {
            pricedata(button29.Text);
           
        }
        private void button30_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button30);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }

        }
        private void button29_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button29);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button28_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button28);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button27_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button27);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button10_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button10);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            pricedata(button10.Text);
        }
        private void button26_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button26);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button25_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button25);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button24_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button24);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button23_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button23);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button22_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button22);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button21_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button21);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button20_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button20);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button19_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button19);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button18_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button18);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button17_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button17);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button16_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button16);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button15_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button15);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button14_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button14);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button13_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button13);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button12_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button12);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button11_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button11);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button9_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button9);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button8_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button8);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button7_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button7);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button6);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button5);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button4);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button3);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button2);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button1);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button31_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button31);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button32_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button32);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button33_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button33);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button34_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button34);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button35_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button35);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button36_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button36);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button37_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button37);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button38_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button38);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button39_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button39);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button40_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn.view();
                Program.xchangbtn = new changebuttonname(button40);
                Program.xchangbtn.Show();
            }
        }
        private void button41_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button41);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button42_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button42);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button43_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button43);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button44_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button44);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button45_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button45);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button46_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button46);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button47_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button47);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button48_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button48);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button49_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button49);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button50_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button50);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button51_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button51);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button52_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button52);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button53_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button53);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button54_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button54);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button55_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button55);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button56_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button56);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void butto57n_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button57);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button58_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button58);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button59_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button59);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button60_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button60);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button61_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button61);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button62_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button62);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button63_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button63);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button64_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button64);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button65_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button65);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button66_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button66);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button67_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button67);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button68_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button68);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button69_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button69);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button70_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button70);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button71_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button71);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button72_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button72);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button73_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button73);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button74_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button74);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button75_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button75);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button76_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button76);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button77_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button77);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button78_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button78);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button79_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button79);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button80_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button80);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button81_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button81);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button82_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button82);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button83_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button83);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button84_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button84);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button85_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button85);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button86_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button86);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button87_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button87);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button88_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button88);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button89_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button89);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button90_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button90);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button91_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button91);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }

        }
        private void button92_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button92);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
            
        }
        private void button93_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button93);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button94_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button94);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button95_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button95);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button96_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button96);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button97_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button97);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button98_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button98);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button99_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button99);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button100_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button100);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button101_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button101);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button102_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button102);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button103_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button103);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button104_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button104);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button105_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button105);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button106_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button106);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button107_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button107);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button108_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button108);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button109_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button109);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button110_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button110);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button111_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button111);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button112_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button112);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button113_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button113);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button114_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button114);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button115_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button115);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button116_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button116);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button117_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button117);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button118_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button118);
                Program.xchangbtn.Show();
            }
        }
        private void button119_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button119);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button120_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button120);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button121_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button121);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button122_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button122);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button123_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button123);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button124_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button124);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button125_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button125);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button126_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button126);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button127_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button127);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button128_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button128);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button129_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button129);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button130_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button130);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button131_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button131);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button132_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button132);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button133_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button133);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button134_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button134);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button135_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button135);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button136_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button136);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button137_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button137);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button138_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button138);
                Program.xchangbtn.Show();
            }
        }
        private void button139_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button139);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button140_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button140);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button141_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button141);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button142_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button142);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button143_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button143);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button144_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button144);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button145_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button145);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button146_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button146);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button147_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button147);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button148_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button148);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button149_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button149);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button150_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button150);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button151_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button151);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button152_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button152);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button153_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button153);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button154_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button154);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button155_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button155);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button156_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button156);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button157_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button157);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button158_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button158);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button159_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button159);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button160_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button160);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button161_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button161);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button162_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button162);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button163_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button163);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button164_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button164);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button165_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button165);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button166_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button166);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button167_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button167);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button168_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button168);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button169_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button169);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button170_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button170);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button171_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button171);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button172_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button172);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button173_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button173);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button174_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button174);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button175_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button175);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button202_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button202);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button203_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button203);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button204_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button204);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button205_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button205);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button206_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button206);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button207_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button207);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button208_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button208);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button209_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button209);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button210_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button210);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button211_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button211);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button212_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button212);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button213_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button213);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button214_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button214);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button215_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button215);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button216_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button216);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button217_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button217);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button218_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button218);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button219_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button219);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button220_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button220);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button221_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button221);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button222_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button222);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button223_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button223);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button224_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button224);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button225_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button225);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button226_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button226);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button227_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button227);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button228_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button228);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button229_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button229);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button230_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button230);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button231_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button231);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button232_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button232);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button233_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button233);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button234_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button234);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button235_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button235);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
        private void button236_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button236);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }
       
        private void button177_Click(object sender, EventArgs e)
        {
            List<string> x = new List<string>();
            List<string> y = new List<string>();
            List<string> z = new List<string>();
            dataGridView1.Rows.Insert(count, "Delivery", "1.15", " 1");
            if (textBox1.Text == "")
                itemprice = 1.15;
            else
                itemprice = double.Parse(textBox1.Text) + 1.15;
            textBox1.Text = itemprice.ToString();
            count++;
            Program.xdelivery.delivprice = textBox1.Text;
            Program.xdelivery.cus = textBox2.Text + "\n" + textBox3.Text + "\n" + textBox4.Text;
            for (int i = 0; i < count; i++)
            {
                Program.xdelivery.delorder =Program.xdelivery.delorder+ dataGridView1.Rows[i].Cells[0].Value.ToString() + " "+dataGridView1.Rows[i].Cells[1].Value.ToString() +" "+ dataGridView1.Rows[i].Cells[2].Value.ToString()+"\n";
                x.Add(dataGridView1.Rows[i].Cells[0].Value.ToString());
                y.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                z.Add( dataGridView1.Rows[i].Cells[2].Value.ToString());
            }
            Program.xdelivery.list(x, y, z);
            Program.xdelivery.delivery_Load(sender,e);
                Program.xdelivery.Show();
                x.RemoveRange(0,x.Count);
                y.RemoveRange(0, y.Count);
                z.RemoveRange(0, z.Count);

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
       
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            string q1 = Program.xsource;
            SqlConnection cn1 = new SqlConnection(q1);
           // conn.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\amjad\\Desktop\\Amjad-CS\\GraduationProjectTest\\GraduationProjectTest\\Database1.mdf;Integrated Security=True;User Instance=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn1;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [Customer] where C_FirstName like '" + textBox2.Text +"%" + "'";
            cn1.Open();
            using (var command = cn1.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Customer] where C_FirstName like '" + textBox2.Text + "%" + "'";
              
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        namesCollection.Add(reader["C_FirstName"].ToString() + " " + reader["C_LastName"].ToString());
          
                    }
                }
            }
            cn1.Close();
            textBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox2.AutoCompleteCustomSource = namesCollection;
        }


        public void Cash_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet2.Customer' table. You can move, or remove it, as needed.
           
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            visa = false;
            p1 = true;
            tabControl1.SelectedIndex = 0;
            cashername_lbl.Text = cashier;
            cashiername = cashername_lbl.Text;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("This will close the program " + "\n" + "Are you sure you want to Exit", "Confirmation Window", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                Application.Exit();
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Are you sure you want to logout", "Confirmation Window", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                Program.xlogin.Show();
                this.Hide();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void return_btn_Click(object sender, EventArgs e)
        {
            int x = 0;
            string item = "";
            string price = "";
            string quantity = "";
            string id = "";
            DateTime date = DateTime.Now;
            if (count != 0)
            {
                for (x = 0; x < count; x++)
                {
                    item =  dataGridView1.Rows[x].Cells[0].Value.ToString();
                    price =  dataGridView1.Rows[x].Cells[1].Value.ToString();
                    quantity =  dataGridView1.Rows[x].Cells[2].Value.ToString();

                    try
                    {
                         DataTable dt = new DataTable();
                        SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Sales] where I_Name like '" + dataGridView1.Rows[x].Cells[0].Value.ToString() + "'AND S_Date = '" + date + "'", Program.xdata);
                       Program.xdata.Open();
                        SDA.Fill(dt);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                    string sid = "";
                    using (var command = Program.xdata.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM [Sales] where I_Name like '" + dataGridView1.Rows[x].Cells[0].Value.ToString() + "'AND S_Date = '" + date + "'";
                       // Program.xdata.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                id = reader["I_ID"].ToString();
                                sid = reader["S_ID"].ToString();
                            }
                        }
                    }

                    string q1 =Program.xsource;
                    SqlConnection cn1 = new SqlConnection(q1);
                    SqlCommand cmd1 = new SqlCommand("DELETE FROM [Sales] WHERE S_ID = '" + sid + "'AND S_Date = '" + date + "'", cn1);
                    cn1.Open();
                    SqlDataReader dr1 = cmd1.ExecuteReader();
                    string q2 = Program.xsource;
                    SqlConnection cn2 = new SqlConnection(q2);
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO [Return](I_ID,I_Name,I_Quantity,R_Date)VALUES (@id,@item,@quantity,@date)", cn2);
                    cmd2.Parameters.AddWithValue("@id", id);
                    cmd2.Parameters.AddWithValue("@item", item);
                    cmd2.Parameters.AddWithValue("@quantity", quantity);
                    cmd2.Parameters.AddWithValue("@date", date);
                    cn2.Open();
                    try
                    {
                        DataTable dt = new DataTable();
                        SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] where I_Name like '" + dataGridView1.Rows[x].Cells[0].Value.ToString() + "'", Program.xdata);
                       // Program.xdata.Open();
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
                        command.CommandText = "SELECT * FROM [Items] where I_Name like '" + dataGridView1.Rows[x].Cells[0].Value.ToString() + "'";
                       // Program.xdata.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                id = reader["I_ID"].ToString();
                                qant = reader["I_Quantity"].ToString();
                            }
                        }
                    }
                    string qan = "";
                    qan = (float.Parse(qant) + float.Parse(quantity)).ToString();
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    SqlConnection cn11 = new SqlConnection(q1);
                    SqlCommand cmd11 = new SqlCommand("UPDATE [Items] SET I_Quantity=@qan WHERE I_ID = '" + id + "'", cn11);
                    cmd11.Parameters.AddWithValue("@qan", qan);
                    cn11.Open();
                    SqlDataReader dr11 = cmd11.ExecuteReader();


                    MessageBox.Show("Your data has been altered successfully");
                    clear();
                }

            }

            Program.xdata.Close();

        }

        private void buy_btn_Click(object sender, EventArgs e)
        {
            Program.xbuyl.Show();
        }

        private void destroy_btn_Click(object sender, EventArgs e)
        {
            int x = 0;
            string price = "";
            string quantity = "";
            string id = "";
            string name = "";
            string qan = "";
            string qant="";
            DateTime date = DateTime.Now;
            if (count != 0)
            {
                for (x = 0; x < count; x++)
                {
                    name = dataGridView1.Rows[x].Cells[0].Value.ToString();
                    price = dataGridView1.Rows[x].Cells[1].Value.ToString();
                    quantity = dataGridView1.Rows[x].Cells[2].Value.ToString();

                    try
                    {
                        DataTable dt = new DataTable();
                        SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] where I_Name like '" + dataGridView1.Rows[x].Cells[0].Value.ToString() + "'", Program.xdata);
                        Program.xdata.Open();
                        SDA.Fill(dt);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                     using (var command = Program.xdata.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM [Items] where I_Name like '" + dataGridView1.Rows[x].Cells[0].Value.ToString() + "'";
                      //  Program.xdata.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                id = reader["I_ID"].ToString();
                                qant = reader["I_Quantity"].ToString();
                            }
                        }
                    }

                     string q21 = Program.xsource;
                    SqlConnection cn21 = new SqlConnection(q21);
                    SqlCommand cmd21 = new SqlCommand("INSERT INTO [Destroy list](Des_Date,I_Name,I_Quantity,I_ID)VALUES (@date,@name,@quantity,@id)", cn21);
                    cmd21.Parameters.AddWithValue("@date", date);
                    cmd21.Parameters.AddWithValue("@name", name);
                    cmd21.Parameters.AddWithValue("@quantity", quantity);
                    cmd21.Parameters.AddWithValue("@id", id);
                    cn21.Open();
                    SqlDataReader dr21 = cmd21.ExecuteReader();
                    qan = (float.Parse(qant) - float.Parse(quantity)).ToString();
                    string q1 = Program.xsource;
                    SqlConnection cn1 = new SqlConnection(q1);
                    SqlCommand cmd1 = new SqlCommand("UPDATE [Items] SET I_Quantity=@qan WHERE I_ID = '" + id + "'", cn1);
                    cmd1.Parameters.AddWithValue("@qan", qan);
                    cn1.Open();
                    SqlDataReader dr1 = cmd1.ExecuteReader();

                    MessageBox.Show("Your data has been altered successfully");
                    clear();
                }

                Program.xdata.Close();
            }
            else
                Program.xdestroy.Show();
        }

        private void button176_Click(object sender, EventArgs e)
        {
            Program.xtabel.Show();
            listfortable();
        }

        public void listfortable()
        {
            total = textBox1.Text;
            for (int i = 0; i < count; i++)
            {
                name.Add( dataGridView1.Rows[i].Cells[0].Value.ToString());
                price.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                quantity.Add( dataGridView1.Rows[i].Cells[2].Value.ToString());
            }

        }
        public void clear()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            count = 0;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
        public void listfromtable(List<string>x,List<string>y,List<string>z,string w)
        {
            clear();
           
            for (int i = 0; i < x.Count; i++)
            {
                dataGridView1.Rows.Insert(count, x[i], y[i], z[i]);
                count++;
            }
            textBox1.Text = w;
        }

        private void returnListToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void deliveryListToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void destroyListToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void dailyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        public int rowIndex;
        public int columnIndex;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            columnIndex = dataGridView1.CurrentCell.ColumnIndex;
            rowIndex = dataGridView1.CurrentCell.RowIndex;

            if( count!=0 && rowIndex < count )
            {
                if (dataGridView1.Rows[rowIndex].Cells[0].Value.ToString() != "Discount" && dataGridView1.Rows[rowIndex].Cells[0].Value.ToString() != "")
                {
                    if (dataGridView1.CurrentCell.ColumnIndex == 2)
                       Program.xqantity.Show();
                }
            }
        }
        public void dataquantity(string x)
        {
            DataGridViewCell cell = dataGridView1.Rows[rowIndex].Cells[columnIndex] ;
            if (cell.Value.ToString() == "1")
            {
                cell.Value = x;
                string pr = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                int quan = int.Parse(x);
                double pri = double.Parse(pr);
                double total = (double.Parse(textBox1.Text));
                double tot = (quan * pri) - pri;
                textBox1.Text = (tot + total).ToString();
            }
            else
            {
                string qua = cell.Value.ToString();
                string pr1 = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
                int quan1 = int.Parse(qua);
                double pri = double.Parse(pr1);
                double tot = quan1 * pri;
                double total = (double.Parse(textBox1.Text));
                double ttt = total - tot;
                cell.Value = x;
                int quan2 = int.Parse(x);
                double tot1 = quan2 * pri;
                textBox1.Text = (ttt + tot1).ToString();
            }
           
        }

        private void pass_btn_Click(object sender, EventArgs e)
        {
            Program.xchangepass.Show();
        }

        private void withdrow_btn_Click(object sender, EventArgs e)
        {
            Program.xemoloyeewithdraw.employeeswithdraw_Load(sender,e);
            Program.xemoloyeewithdraw.Show();
        }
        
        private void visa_btn_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show( "Are you sure you want to save this order by visa", "Confirmation Window", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                visa = true;
                save_cash();
            }
        }

        private void report_btn_Click(object sender, EventArgs e)
        {
            Program.xdaily.dailysales_Load(sender,e);
            Program.xdaily.Show(); 
        }

        private void offer_btn_Click(object sender, EventArgs e)
        {
            Program.xoffer.available();
            Program.xoffer.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {
            pricedata(button28.Text);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            pricedata(button27.Text);
          
        }

        private void button26_Click(object sender, EventArgs e)
        {
            pricedata(button26.Text);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            pricedata(button25.Text);
        }

        public void pricedata(string x)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] where I_Name = '" + x +"'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Items] where I_Name = '" +x + "'";
                // Program.xdata.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        itempricedata = reader["I_sellingprice"].ToString();
                       
                    }
                }
            }
            Program.xdata.Close();
            if (count == 0)
            {
                textBox1.Text = "";
                textBox5.Text = "";
            }
            if (x != "")
            {

                dataGridView1.Rows.Insert(count, x, itempricedata, " 1");
                if (textBox1.Text == "")
                    itemprice = double.Parse(itempricedata);
                else
                    itemprice = double.Parse(textBox1.Text) + double.Parse(itempricedata);
                textBox1.Text = itemprice.ToString();
                count++;

            }
            if(count>=10)
            dataGridView1.FirstDisplayedScrollingRowIndex = count-10;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            pricedata(button24.Text);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            pricedata(button23.Text);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            pricedata(button22.Text);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            pricedata(button21.Text);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            pricedata(button20.Text);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            pricedata(button19.Text);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            pricedata(button18.Text);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            pricedata(button17.Text);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            pricedata(button16.Text);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            pricedata(button15.Text);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            pricedata(button14.Text);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            pricedata(button13.Text);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            pricedata(button12.Text);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            pricedata(button11.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pricedata(button9.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pricedata(button8.Text);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pricedata(button7.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pricedata(button6.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pricedata(button5.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pricedata(button4.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pricedata(button3.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pricedata(button2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pricedata(button1.Text);
        }

        private void button138_Click(object sender, EventArgs e)
        {
            pricedata(button138.Text);
        }

        private void button139_Click(object sender, EventArgs e)
        {
            pricedata(button139.Text);
        }

        private void button140_Click(object sender, EventArgs e)
        {
            pricedata(button140.Text);
        }

        private void button141_Click(object sender, EventArgs e)
        {
            pricedata(button141.Text);
        }

        private void button142_Click(object sender, EventArgs e)
        {
            pricedata(button142.Text);
        }

        private void button143_Click(object sender, EventArgs e)
        {
            pricedata(button143.Text);
        }

        private void button144_Click(object sender, EventArgs e)
        {
            pricedata(button144.Text);
        }

        private void button145_Click(object sender, EventArgs e)
        {
            pricedata(button145.Text);
        }

        private void button146_Click(object sender, EventArgs e)
        {
            pricedata(button146.Text);
        }

        private void button147_Click(object sender, EventArgs e)
        {
            pricedata(button147.Text);
        }

        private void button148_Click(object sender, EventArgs e)
        {
            pricedata(button148.Text);
        }

        private void button149_Click(object sender, EventArgs e)
        {
            pricedata(button149.Text);
        }

        private void button150_Click(object sender, EventArgs e)
        {
            pricedata(button150.Text);
        }

        private void button91_Click(object sender, EventArgs e)
        {
            pricedata(button91.Text);
        }

        private void button92_Click(object sender, EventArgs e)
        {
            pricedata(button92.Text);
        }

        private void button93_Click(object sender, EventArgs e)
        {
            pricedata(button93.Text);
        }

        private void button94_Click(object sender, EventArgs e)
        {
            pricedata(button94.Text);
        }

        private void button95_Click(object sender, EventArgs e)
        {
            pricedata(button95.Text);
        }

        private void button96_Click(object sender, EventArgs e)
        {
            pricedata(button96.Text);
        }

        private void button97_Click(object sender, EventArgs e)
        {
            pricedata(button97.Text);
        }

        private void button98_Click(object sender, EventArgs e)
        {
            pricedata(button98.Text);
        }

        private void button99_Click(object sender, EventArgs e)
        {
            pricedata(button99.Text);
        }

        private void button100_Click(object sender, EventArgs e)
        {
            pricedata(button100.Text);
        }

        private void button101_Click(object sender, EventArgs e)
        {
            pricedata(button101.Text);
        }

        private void button102_Click(object sender, EventArgs e)
        {
            pricedata(button102.Text);
        }

        private void button103_Click(object sender, EventArgs e)
        {
            pricedata(button103.Text);
        }

        private void button104_Click(object sender, EventArgs e)
        {
            pricedata(button104.Text);
        }

        private void button105_Click(object sender, EventArgs e)
        {
            pricedata(button105.Text);
        }

        private void button106_Click(object sender, EventArgs e)
        {
            pricedata(button106.Text);
        }

        private void button107_Click(object sender, EventArgs e)
        {
            pricedata(button107.Text);
        }

        private void button108_Click(object sender, EventArgs e)
        {
            pricedata(button108.Text);
        }

        private void button109_Click(object sender, EventArgs e)
        {
            pricedata(button109.Text);
        }

        private void button110_Click(object sender, EventArgs e)
        {
            pricedata(button110.Text);
        }

        private void button111_Click(object sender, EventArgs e)
        {
            pricedata(button111.Text);
        }

        private void button112_Click(object sender, EventArgs e)
        {
            pricedata(button112.Text);
        }

        private void button113_Click(object sender, EventArgs e)
        {
            pricedata(button113.Text);
        }

        private void button114_Click(object sender, EventArgs e)
        {
            pricedata(button114.Text);
        }

        private void button115_Click(object sender, EventArgs e)
        {
            pricedata(button115.Text);
        }

        private void button116_Click(object sender, EventArgs e)
        {
            pricedata(button116.Text);
        }

        private void button117_Click(object sender, EventArgs e)
        {
            pricedata(button117.Text);
        }

        private void button118_Click(object sender, EventArgs e)
        {
            pricedata(button118.Text);
        }

        private void button119_Click(object sender, EventArgs e)
        {
            pricedata(button119.Text);
        }

        private void button120_Click(object sender, EventArgs e)
        {
            pricedata(button120.Text);
        }

        private void button61_Click(object sender, EventArgs e)
        {
            pricedata(button61.Text);
        }

        private void button62_Click(object sender, EventArgs e)
        {
            pricedata(button62.Text);
        }

        private void button63_Click(object sender, EventArgs e)
        {
            pricedata(button63.Text);
        }

        private void button64_Click(object sender, EventArgs e)
        {
            pricedata(button64.Text);
        }

        private void button65_Click(object sender, EventArgs e)
        {
            pricedata(button65.Text);
        }

        private void button66_Click(object sender, EventArgs e)
        {
            pricedata(button66.Text);
        }

        private void button67_Click(object sender, EventArgs e)
        {
            pricedata(button67.Text);
        }

        private void button68_Click(object sender, EventArgs e)
        {
            pricedata(button68.Text);
        }

        private void button69_Click(object sender, EventArgs e)
        {
            pricedata(button69.Text);
        }

        private void button70_Click(object sender, EventArgs e)
        {
            pricedata(button70.Text);
        }

        private void button71_Click(object sender, EventArgs e)
        {
            pricedata(button71.Text);
        }

        private void button72_Click(object sender, EventArgs e)
        {
            pricedata(button72.Text);
        }

        private void button73_Click(object sender, EventArgs e)
        {
            pricedata(button73.Text);
        }

        private void button74_Click(object sender, EventArgs e)
        {
            pricedata(button74.Text);
        }

        private void button75_Click(object sender, EventArgs e)
        {
            pricedata(button75.Text);
        }

        private void button76_Click(object sender, EventArgs e)
        {
            pricedata(button76.Text);
        }

        private void button77_Click(object sender, EventArgs e)
        {
            pricedata(button77.Text);
        }

        private void button78_Click(object sender, EventArgs e)
        {
            pricedata(button78.Text);
        }

        private void button79_Click(object sender, EventArgs e)
        {
            pricedata(button79.Text);
        }

        private void button80_Click(object sender, EventArgs e)
        {
            pricedata(button80.Text);
        }

        private void button81_Click(object sender, EventArgs e)
        {
            pricedata(button81.Text);
        }

        private void button82_Click(object sender, EventArgs e)
        {
            pricedata(button82.Text);
        }

        private void button83_Click(object sender, EventArgs e)
        {
            pricedata(button83.Text);
        }

        private void button84_Click(object sender, EventArgs e)
        {
            pricedata(button84.Text);
        }

        private void button85_Click(object sender, EventArgs e)
        {
            pricedata(button85.Text);
        }

        private void button86_Click(object sender, EventArgs e)
        {
            pricedata(button86.Text);
        }

        private void button87_Click(object sender, EventArgs e)
        {
            pricedata(button87.Text);
        }

        private void button88_Click(object sender, EventArgs e)
        {
            pricedata(button88.Text);
        }

        private void button89_Click(object sender, EventArgs e)
        {
            pricedata(button89.Text);
        }

        private void button90_Click(object sender, EventArgs e)
        {
            pricedata(button90.Text);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            pricedata(button31.Text);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            pricedata(button32.Text);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            pricedata(button33.Text);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            pricedata(button34.Text);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            pricedata(button35.Text);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            pricedata(button36.Text);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            pricedata(button37.Text);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            pricedata(button38.Text);
        }

        private void button39_Click(object sender, EventArgs e)
        {
            pricedata(button39.Text);
        }

        private void button40_Click(object sender, EventArgs e)
        {
            pricedata(button40.Text);
        }

        private void button41_Click(object sender, EventArgs e)
        {
            pricedata(button41.Text);
        }

        private void button42_Click(object sender, EventArgs e)
        {
            pricedata(button42.Text);
        }

        private void button43_Click(object sender, EventArgs e)
        {
            pricedata(button43.Text);
        }

        private void button44_Click(object sender, EventArgs e)
        {
            pricedata(button44.Text);
        }

        private void button45_Click(object sender, EventArgs e)
        {
            pricedata(button45.Text);
        }

        private void button46_Click(object sender, EventArgs e)
        {
            pricedata(button46.Text);
        }

        private void button47_Click(object sender, EventArgs e)
        {
            pricedata(button47.Text);
        }

        private void button48_Click(object sender, EventArgs e)
        {
            pricedata(button48.Text);
        }

        private void button49_Click(object sender, EventArgs e)
        {
            pricedata(button49.Text);
        }

        private void button50_Click(object sender, EventArgs e)
        {
            pricedata(button50.Text);
        }

        private void button51_Click(object sender, EventArgs e)
        {
            pricedata(button51.Text);
        }

        private void button52_Click(object sender, EventArgs e)
        {
            pricedata(button52.Text);
        }

        private void button53_Click(object sender, EventArgs e)
        {
            pricedata(button53.Text);
        }

        private void button54_Click(object sender, EventArgs e)
        {
            pricedata(button54.Text);
        }

        private void button55_Click(object sender, EventArgs e)
        {
            pricedata(button55.Text);
        }

        private void button56_Click(object sender, EventArgs e)
        {
            pricedata(button56.Text);
        }

        private void button57_Click(object sender, EventArgs e)
        {
            pricedata(button57.Text);
        }

        private void button58_Click(object sender, EventArgs e)
        {
            pricedata(button58.Text);
        }

        private void button59_Click(object sender, EventArgs e)
        {
            pricedata(button59.Text);
        }

        private void button60_Click(object sender, EventArgs e)
        {
            pricedata(button60.Text);
        }
        public void addextra(string x)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Items] where I_Name like '" + x + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Items] where I_Name like '" + x + "'";
                // Program.xdata.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        itempricedata = reader["I_sellingprice"].ToString();

                    }
                }
            }
            Program.xdata.Close();
            int c = dataGridView1.CurrentCell.RowIndex+1;
            if (count == 0)
            {
                textBox1.Text = "";
                textBox5.Text = "";
            }
            if (c <= count)
            {
                if (x != "")
                {

                    dataGridView1.Rows.Insert(c, x, itempricedata, " 1");
                    if (textBox1.Text == "")
                        itemprice = double.Parse(itempricedata);
                    else
                        itemprice = double.Parse(textBox1.Text) + double.Parse(itempricedata);
                    textBox1.Text = itemprice.ToString();
                    count++;
                    c++;

                }
            }
            if (count >= 10)
                dataGridView1.FirstDisplayedScrollingRowIndex = count - 10;
        }

        private void button272_Click(object sender, EventArgs e)
        {
            if(count>0)
                addextra(button272.Text);
        }

        private void button182_Click(object sender, EventArgs e)
        {
            if (count > 0)
            addextra(button182.Text);
        }

        private void button181_Click(object sender, EventArgs e)
        {
            if (count > 0)
            addextra(button181.Text);
        }

        private void button180_Click(object sender, EventArgs e)
        {
            if (count > 0)
            addextra(button180.Text);
        }

        private void button179_Click(object sender, EventArgs e)
        {
            if (count > 0)
            addextra(button179.Text);
        }

        private void button178_Click(object sender, EventArgs e)
        {
            if (count > 0)
            addextra(button178.Text);
        }

        private void button188_Click(object sender, EventArgs e)
        {
            if (count > 0)
            addextra(button188.Text);
        }

        private void button187_Click(object sender, EventArgs e)
        {
            if (count > 0)
            addextra(button187.Text);
        }

        private void button186_Click(object sender, EventArgs e)
        {
            if (count > 0)
            addextra(button186.Text);
        }

        private void button185_Click(object sender, EventArgs e)
        {
            if (count > 0)
            addextra(button185.Text);
        }

        private void button184_Click(object sender, EventArgs e)
        {
            if (count > 0)
            addextra(button184.Text);
        }

        private void button183_Click(object sender, EventArgs e)
        {
            if (count > 0)
            addextra(button183.Text);
        }

        private void closecashe_btn_Click(object sender, EventArgs e)
        {
            Program.xclose.close();
            Program.xclose.Show();
        }
        public void disable()
        {
            foreach (Control item in this.Controls)
            {
                if (item is Button)
                {
                    Button r = (Button)item;
                        r.Enabled = false;
                }
                if (item is MenuStrip)
                {
                    MenuStrip m = (MenuStrip)item;
                    m.Enabled = false;
                }
                if (item is TabControl)
                {
                    TabControl t = (TabControl)item;
                    t.Enabled = false;
                }
                if (item is Panel)
                {
                    Panel p = (Panel)item;
                    p.Enabled = false;
                }
            }
            Opcash_btn.Enabled = true;
            exitcash_btn.Enabled = true;
        }

        private void button137_Click(object sender, EventArgs e)
        {
            pricedata(button137.Text);
        }

        private void button136_Click(object sender, EventArgs e)
        {
            pricedata(button136.Text);
        }

        private void button135_Click(object sender, EventArgs e)
        {
            pricedata(button135.Text);
        }

        private void button134_Click(object sender, EventArgs e)
        {
            pricedata(button134.Text);
        }

        private void button133_Click(object sender, EventArgs e)
        {
            pricedata(button133.Text);
        }

        private void button132_Click(object sender, EventArgs e)
        {
            pricedata(button132.Text);
        }

        private void button131_Click(object sender, EventArgs e)
        {
            pricedata(button131.Text);
        }

        private void button130_Click(object sender, EventArgs e)
        {
            pricedata(button130.Text);
        }

        private void button129_Click(object sender, EventArgs e)
        {
            pricedata(button129.Text);
        }

        private void button128_Click(object sender, EventArgs e)
        {
            pricedata(button128.Text);
        }

        private void button127_Click(object sender, EventArgs e)
        {
            pricedata(button127.Text);
        }

        private void button126_Click(object sender, EventArgs e)
        {
            pricedata(button126.Text);
        }

        private void button125_Click(object sender, EventArgs e)
        {
            pricedata(button125.Text);
        }

        private void button124_Click(object sender, EventArgs e)
        {
            pricedata(button124.Text);
        }

        private void button123_Click(object sender, EventArgs e)
        {
            pricedata(button123.Text);
        }

        private void button122_Click(object sender, EventArgs e)
        {
            pricedata(button122.Text);
        }

        private void button121_Click(object sender, EventArgs e)
        {
            pricedata(button121.Text);
        }

        private void button206_Click(object sender, EventArgs e)
        {
            pricedata(button206.Text);
        }

        private void button205_Click(object sender, EventArgs e)
        {
            pricedata(button205.Text);
        }

        private void button204_Click(object sender, EventArgs e)
        {
            pricedata(button204.Text);
        }

        private void button203_Click(object sender, EventArgs e)
        {
            pricedata(button203.Text);
        }

        private void button202_Click(object sender, EventArgs e)
        {
            pricedata(button202.Text);
        }

        private void button175_Click(object sender, EventArgs e)
        {
            pricedata(button175.Text);
        }

        private void button174_Click(object sender, EventArgs e)
        {
            pricedata(button174.Text);
        }

        private void button173_Click(object sender, EventArgs e)
        {
            pricedata(button173.Text);
        }

        private void button172_Click(object sender, EventArgs e)
        {
            pricedata(button172.Text);
        }

        private void button171_Click(object sender, EventArgs e)
        {
            pricedata(button171.Text);
        }

        private void button170_Click(object sender, EventArgs e)
        {
            pricedata(button170.Text);
        }

        private void button169_Click(object sender, EventArgs e)
        {
            pricedata(button169.Text);
        }

        private void button168_Click(object sender, EventArgs e)
        {
            pricedata(button168.Text);
        }

        private void button167_Click(object sender, EventArgs e)
        {
            pricedata(button167.Text);
        }

        private void button166_Click(object sender, EventArgs e)
        {
            pricedata(button166.Text);
        }

        private void button165_Click(object sender, EventArgs e)
        {
            pricedata(button165.Text);
        }

        private void button164_Click(object sender, EventArgs e)
        {
            pricedata(button164.Text);
        }

        private void button163_Click(object sender, EventArgs e)
        {
            pricedata(button163.Text);
        }

        private void button162_Click(object sender, EventArgs e)
        {
            pricedata(button162.Text);
        }

        private void button161_Click(object sender, EventArgs e)
        {
            pricedata(button161.Text);
        }

        private void button160_Click(object sender, EventArgs e)
        {
            pricedata(button160.Text);
        }

        private void button159_Click(object sender, EventArgs e)
        {
            pricedata(button159.Text);
        }

        private void button158_Click(object sender, EventArgs e)
        {
            pricedata(button158.Text);
        }

        private void button157_Click(object sender, EventArgs e)
        {
            pricedata(button157.Text);
        }

        private void button156_Click(object sender, EventArgs e)
        {
            pricedata(button156.Text);
        }

        private void button155_Click(object sender, EventArgs e)
        {
            pricedata(button155.Text);
        }

        private void button154_Click(object sender, EventArgs e)
        {
            pricedata(button154.Text);
        }

        private void button153_Click(object sender, EventArgs e)
        {
            pricedata(button153.Text);
        }

        private void button152_Click(object sender, EventArgs e)
        {
            pricedata(button152.Text);
        }

        private void button151_Click(object sender, EventArgs e)
        {
            pricedata(button151.Text);
        }

        private void button236_Click(object sender, EventArgs e)
        {
            pricedata(button236.Text);
        }

        private void button235_Click(object sender, EventArgs e)
        {
            pricedata(button235.Text);
        }

        private void button234_Click(object sender, EventArgs e)
        {
            pricedata(button234.Text);
        }

        private void button233_Click(object sender, EventArgs e)
        {
            pricedata(button233.Text);
        }

        private void button232_Click(object sender, EventArgs e)
        {
            pricedata(button232.Text);
        }

        private void button231_Click(object sender, EventArgs e)
        {
            pricedata(button231.Text);
        }

        private void button230_Click(object sender, EventArgs e)
        {
            pricedata(button230.Text);
        }

        private void button229_Click(object sender, EventArgs e)
        {
            pricedata(button229.Text);
        }

        private void button228_Click(object sender, EventArgs e)
        {
            pricedata(button228.Text);
        }

        private void button227_Click(object sender, EventArgs e)
        {
            pricedata(button227.Text);
        }

        private void button226_Click(object sender, EventArgs e)
        {
            pricedata(button226.Text);
        }

        private void button225_Click(object sender, EventArgs e)
        {
            pricedata(button225.Text);
        }

        private void button224_Click(object sender, EventArgs e)
        {
            pricedata(button224.Text);
        }

        private void button223_Click(object sender, EventArgs e)
        {
            pricedata(button223.Text);
        }

        private void button222_Click(object sender, EventArgs e)
        {
            pricedata(button222.Text);
        }

        private void button221_Click(object sender, EventArgs e)
        {
            pricedata(button221.Text);
        }

        private void button220_Click(object sender, EventArgs e)
        {
            pricedata(button220.Text);
        }

        private void button219_Click(object sender, EventArgs e)
        {
            pricedata(button219.Text);
        }

        private void button218_Click(object sender, EventArgs e)
        {
            pricedata(button218.Text);
        }

        private void button217_Click(object sender, EventArgs e)
        {
            pricedata(button217.Text);
        }

        private void button216_Click(object sender, EventArgs e)
        {
            pricedata(button216.Text);
        }

        private void button215_Click(object sender, EventArgs e)
        {
            pricedata(button215.Text);
        }

        private void button214_Click(object sender, EventArgs e)
        {
            pricedata(button214.Text);
        }

        private void button213_Click(object sender, EventArgs e)
        {
            pricedata(button213.Text);
        }

        private void button212_Click(object sender, EventArgs e)
        {
            pricedata(button212.Text);
        }

        private void button211_Click(object sender, EventArgs e)
        {
            pricedata(button211.Text);
        }

        private void button210_Click(object sender, EventArgs e)
        {
            pricedata(button210.Text);
        }

        private void button209_Click(object sender, EventArgs e)
        {
            pricedata(button209.Text);
        }

        private void button208_Click(object sender, EventArgs e)
        {
            pricedata(button208.Text);
        }

        private void button207_Click(object sender, EventArgs e)
        {
            pricedata(button207.Text);
        }

        private void button194_Click(object sender, EventArgs e)
        {
            if (count > 0)
                addextra(button194.Text);
        }

        private void button193_Click(object sender, EventArgs e)
        {
            if (count > 0)
                addextra(button193.Text);
        }

        private void button192_Click(object sender, EventArgs e)
        {
            if (count > 0)
                addextra(button192.Text);
        }

        private void button191_Click(object sender, EventArgs e)
        {
            if (count > 0)
                addextra(button191.Text);
        }

        private void button190_Click(object sender, EventArgs e)
        {
            if (count > 0)
                addextra(button190.Text);
        }

        private void button189_Click(object sender, EventArgs e)
        {
            if (count > 0)
                addextra(button189.Text);
        }

        private void button200_Click(object sender, EventArgs e)
        {
            if (count > 0)
                addextra(button200.Text);
        }

        private void button199_Click(object sender, EventArgs e)
        {
            if (count > 0)
                addextra(button199.Text);
        }

        private void button198_Click(object sender, EventArgs e)
        {
            if (count > 0)
                addextra(button198.Text);
        }

        private void button197_Click(object sender, EventArgs e)
        {
            if (count > 0)
                addextra(button197.Text);
        }

        private void button196_Click(object sender, EventArgs e)
        {
            if (count > 0)
                addextra(button196.Text);
        }

        private void button195_Click(object sender, EventArgs e)
        {
            if (count > 0)
                addextra(button195.Text);
        }

        private void button271_Click(object sender, EventArgs e)
        {
            if (count > 0)
                addextra(button271.Text);
        }

        private void button270_Click(object sender, EventArgs e)
        {
            if (count > 0)
                addextra(button270.Text);
        }

        private void button269_Click(object sender, EventArgs e)
        {
            if (count > 0)
                addextra(button269.Text);
        }

        private void button268_Click(object sender, EventArgs e)
        {
            if (count > 0)
                addextra(button268.Text);
        }

        private void button267_Click(object sender, EventArgs e)
        {
            if (count > 0)
                addextra(button267.Text);
        }

        private void button201_Click(object sender, EventArgs e)
        {
            if (count > 0)
                addextra(button201.Text);
        }

        private void button272_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button272);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }

        private void button182_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button182);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }

        private void button181_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button181);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }

        private void button180_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button180);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }

        private void button179_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button179);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }

        private void button178_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button178);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }

        private void button188_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button188);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }

        }

        private void button187_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button187);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }

        }

        private void button186_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button186);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }

        private void button185_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button185);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }

        private void button184_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button184);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }

        private void button183_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button183);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }

        private void button194_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button194);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }

        }

        private void button193_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button193);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }

        private void button192_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button192);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }

        private void button191_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button191);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }

        private void button190_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button190);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }

        private void button189_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button189);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }

        private void button200_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button200);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }

        private void button199_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button199);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }

        private void button198_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button198);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }

        private void button197_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button197);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }

        private void button196_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button196);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }

        private void button195_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button195);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }

        private void button271_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button271);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }

        }

        private void button270_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button270);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }

        private void button269_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button269);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }

        private void button268_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button268);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }

        }

        private void button267_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button267);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }

        }

        private void button201_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Program.xchangbtn = new changebuttonname(button201);
                Program.xchangbtn.view();
                Program.xchangbtn.Show();
            }
        }

        public void offer(string x)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM [Offers] where O_Name = '" + x + "'", Program.xdata);
                Program.xdata.Open();
                SDA.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            using (var command = Program.xdata.CreateCommand())
            {
                command.CommandText = "SELECT * FROM [Offers] where O_Name = '" + x + "'";
                // Program.xdata.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        itempricedata = reader["O_Netprofit"].ToString();

                    }
                }
            }
            Program.xdata.Close();
            if (count == 0)
            {
                textBox1.Text = "";
                textBox5.Text = "";
            }
            if (x != "")
            {

                dataGridView1.Rows.Insert(count, x, itempricedata, " 1");
                if (textBox1.Text == "")
                    itemprice = double.Parse(itempricedata);
                else
                    itemprice = double.Parse(textBox1.Text) + double.Parse(itempricedata);
                textBox1.Text = itemprice.ToString();
                count++;

            }
            if (count >= 10)
                dataGridView1.FirstDisplayedScrollingRowIndex = count - 10;
        }

        private void billingListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.xblist.insert();
            Program.xblist.Show();
        }

        private void button237_Click(object sender, EventArgs e)
        {
            Program.xblist.insert();
            Program.xblist.Show();
        }
        public Boolean mmm = false;
        private void button238_Click(object sender, EventArgs e)
        {
            if (!mmm)
            {
                button238.BackgroundImage = Properties.Resources._2;

                Program.xmsg.mu();
                mmm = true;
            }
            else
            {

                button238.BackgroundImage = Properties.Resources._1__2_;
                Program.xmsg.mu();
                mmm = false;
            }
        }
    }
}

