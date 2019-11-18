namespace GraduationProjectTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonhelp1 = new System.Windows.Forms.Button();
            this.button2exit = new System.Windows.Forms.Button();
            this.buttonstart1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lavender;
            this.label1.Location = new System.Drawing.Point(77, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 74);
            this.label1.TabIndex = 0;
            this.label1.Text = "          Welcome To\r\n Smart Inventory System ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonhelp1
            // 
            this.buttonhelp1.Image = global::GraduationProjectTest.Properties.Resources.HelpButton;
            this.buttonhelp1.Location = new System.Drawing.Point(17, 492);
            this.buttonhelp1.Name = "buttonhelp1";
            this.buttonhelp1.Size = new System.Drawing.Size(65, 47);
            this.buttonhelp1.TabIndex = 5;
            this.buttonhelp1.UseVisualStyleBackColor = true;
            this.buttonhelp1.Click += new System.EventHandler(this.buttonhelp1_Click);
            // 
            // button2exit
            // 
            this.button2exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2exit.Image = ((System.Drawing.Image)(resources.GetObject("button2exit.Image")));
            this.button2exit.Location = new System.Drawing.Point(774, 443);
            this.button2exit.Name = "button2exit";
            this.button2exit.Size = new System.Drawing.Size(109, 119);
            this.button2exit.TabIndex = 3;
            this.button2exit.UseVisualStyleBackColor = true;
            this.button2exit.Click += new System.EventHandler(this.button2exit_Click);
            // 
            // buttonstart1
            // 
            this.buttonstart1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonstart1.Image = ((System.Drawing.Image)(resources.GetObject("buttonstart1.Image")));
            this.buttonstart1.Location = new System.Drawing.Point(527, 443);
            this.buttonstart1.Name = "buttonstart1";
            this.buttonstart1.Size = new System.Drawing.Size(126, 125);
            this.buttonstart1.TabIndex = 2;
            this.buttonstart1.UseVisualStyleBackColor = true;
            this.buttonstart1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(510, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(342, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(95, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(307, 192);
            this.label3.TabIndex = 7;
            this.label3.Text = "1-Manage availability of resources\r\n    such as ingredients.\r\n\r\n2- Reduce food co" +
                "sts.\r\n  \r\n3- Gain greater visibility of inventory.\r\n\r\n4- Short term planning.\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.BackgroundImage = global::GraduationProjectTest.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(921, 564);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonhelp1);
            this.Controls.Add(this.button2exit);
            this.Controls.Add(this.buttonstart1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(100, 100);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonstart1;
        private System.Windows.Forms.Button button2exit;
        private System.Windows.Forms.Button buttonhelp1;
        private System.Windows.Forms.Label label3;
    }
}

