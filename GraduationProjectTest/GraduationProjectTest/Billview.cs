using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraduationProjectTest
{
    public partial class Billview : Form
    {
        public List<string> items = new List<string>();
        public List<string> quans = new List<string>();
        public List<string> prices = new List<string>();
        public Billview()
        {
            InitializeComponent();
        }

        private void Billview_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            items.Clear();
            prices.Clear();
            quans.Clear();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //print code
            richTextBox1.Clear();
            items.Clear();
            prices.Clear();
            quans.Clear();
            this.Hide();
        }

        public void view(string date, string time, string item, string price, string quantity, string cashier, string id,string total)
        {
            for (int i = 0; i < item.Length; i++)
            {
                string tt1 = "";
                string y = "";
                while (item[i] != ' ' && i < item.Length-1 )
                {
                    tt1 = tt1 + item[i];
                    i++;
                }
                if (items.Count == 1||i==item.Length-1)
                {
                    y = tt1 + item[i];
                }
                else
                {
                    y = tt1;
                } 
                items.Add(y);
            }
            for (int i = 0; i < price.Length; i++)
            {
                string tt2 = "";
                string w = "";
                while (price[i] != ' ' && i < price.Length-1 )
                {
                    tt2 = tt2 + price[i];
                    i++;
                }
                if (prices.Count == 1 || i == price.Length - 1)
                {
                    w = tt2 + price[i];
                }
                else
                {
                    w = tt2;
                }
                    prices.Add(w);
            }
            for (int i = 0; i < quantity.Length; i++)
            {
                string tt = "";
                string s="";
                while (quantity[i] != ' ' && i < quantity.Length-1)
                {
                    tt = tt + quantity[i];
                    i++;
                }
                if (quans.Count == 1 || i == quantity.Length - 1)
                {
                    s = tt + quantity[i];
                }
                else
                {
                    s = tt;
                }
                    quans.Add(s);
            }

            string a1 = @"                          #" + id +"                  "+
                 "\n"+
                 "                           " + DateTime.Parse( date).ToShortDateString() +"                     "+
                 "\n" +
                 "                            " + time + "                        " +
                 "\n" +
                 "   Cashier:          " + cashier +
                 "\n";
            string a2 = "   Items  " + "         Price    " + "         Quantity          ";
           
            string a3 = "";
            
            for (int i = 0; i < items.Count; i++)
            {
                a3 =@a3+
                    "\n"+"   " + items[i] + "             " + prices[i] + "              " + quans[i] ;
            }
    
            string a4 = "_____________________________";
            string a5 = "TOTAL    " + total;
            string a6="           THE RESTURANT NAME";


            richTextBox1.Text = a6+"\n"+a1 + "\n" + a2 + "\n" + a3 + "\n" + a4 + "\n" + "\n" + a5;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
