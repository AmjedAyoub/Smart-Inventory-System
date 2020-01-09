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
    public partial class Maps : Form
    {
        public Maps()
        {
            InitializeComponent();
        }

        private void btnMapIt_Click(object sender, EventArgs e)
        {

            try
            {
                string street = string.Empty;
                string city = string.Empty;              

                StringBuilder queryAddress = new StringBuilder();
                queryAddress.Append("http://maps.google.com/maps?q=");

                if (txtStreet.Text != string.Empty)
                {
                    street = txtStreet.Text.Replace(' ', '+');
                    queryAddress.Append(street + ',' + '+');
                }

                if (txtCity.Text != string.Empty)
                {
                    city = txtCity.Text.Replace(' ', '+');
                    queryAddress.Append(city + ',' + '+');
                }                

                webBrowser1.Navigate(queryAddress.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Unable to Retrieve Map");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.Print();
        }
    }      
    

    }

