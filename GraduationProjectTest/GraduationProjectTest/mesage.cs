using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.IO;
using System.Speech;

namespace GraduationProjectTest
{
    public partial class mesage : Form
    {
        public static Boolean mute = false;
        public static mesage xmsg2;

        public mesage()
        {
            InitializeComponent();
        }

        private void mesage_Load(object sender, EventArgs e)
        {
           
        }
      

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 100;
            this.Opacity = op;
            op = (op - 0.01);
            if (op == 0)
            {
                this.Hide();
                timer1.Stop();
                timer3.Stop();
                timer2.Stop();
                op = 1.0;
            }
        }
        int c = 0;
        private void label2_Click(object sender, EventArgs e)
        {
            
        }
        
        double op = 1.0;
        private void label2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void mesage_MouseHover(object sender, EventArgs e)
        {
            op = 1.0;
        }

        private void mesage_MouseMove(object sender, MouseEventArgs e)
        {
            op = 1.0;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            timer1.Stop();
            timer3.Stop();
            timer2.Stop();
            op = 1.0;
            c = 0;
            yy = 740;
           
        }
        public void msg(string x, string y)
        {
            op = 1.0;
            timer2.Stop();
            timer1.Stop();
            timer3.Start();
            this.Opacity = 1.0;
            label4.Text = "Please notice that" + "\n" + "you have only " + y + "\n" + "pieces of " + x+".";
            if (!mute)
            {
                speak();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (c != 5)
            {
                c++;
                timer2.Interval = 1000;
            }
            else
                {
                    timer2.Stop();
                    timer1.Start();
                    c=0;
                }
        }
        public void expiry(string x, string y)
        {
            op = 1.0;
            timer2.Stop();
            timer1.Stop();
            timer3.Start();
            this.Opacity = 1.0;
            label4.Text = "Please notice that" + "\n" + x + " will expire on " + "\n" + y;
            if (!mute)
            {
                speak();
            }
       
        }
        int yy = 740;
        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Interval = 100;
            this.Location = new Point(900, yy);
            yy=yy-5;
            if (yy == 580)
            {
                timer3.Stop();
                timer2.Start();
                yy = 740;
            }
        }

        public void speak()
        {
            SpeechSynthesizer voice = new SpeechSynthesizer();
            voice.SpeakAsync(label4.Text);
        }
        public void mu()
        {
            if (!mute)
            {
                mute = true;

            }
            else
                mute = false;
        }
    }
}
