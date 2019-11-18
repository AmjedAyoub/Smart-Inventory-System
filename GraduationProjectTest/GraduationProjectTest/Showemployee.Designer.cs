namespace GraduationProjectTest
{
    partial class Showemployee
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
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.Nameemp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hiredate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Job = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sallary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Drop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.LightCyan;
            this.label11.Location = new System.Drawing.Point(258, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(200, 31);
            this.label11.TabIndex = 66;
            this.label11.Text = "Employee Info";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nameemp,
            this.Hiredate,
            this.Email,
            this.Contact,
            this.Job,
            this.Sallary,
            this.Drop,
            this.User,
            this.Pass});
            this.dataGridView1.Location = new System.Drawing.Point(1, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(727, 236);
            this.dataGridView1.TabIndex = 67;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(315, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 29);
            this.button1.TabIndex = 68;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Nameemp
            // 
            this.Nameemp.HeaderText = "Name";
            this.Nameemp.Name = "Nameemp";
            this.Nameemp.ReadOnly = true;
            // 
            // Hiredate
            // 
            this.Hiredate.HeaderText = "Hiredate";
            this.Hiredate.Name = "Hiredate";
            this.Hiredate.ReadOnly = true;
            this.Hiredate.Width = 80;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // Contact
            // 
            this.Contact.HeaderText = "ContactNumber";
            this.Contact.Name = "Contact";
            this.Contact.ReadOnly = true;
            // 
            // Job
            // 
            this.Job.HeaderText = "Job";
            this.Job.Name = "Job";
            this.Job.ReadOnly = true;
            this.Job.Width = 80;
            // 
            // Sallary
            // 
            this.Sallary.HeaderText = "Salary";
            this.Sallary.Name = "Sallary";
            this.Sallary.ReadOnly = true;
            this.Sallary.Width = 50;
            // 
            // Drop
            // 
            this.Drop.HeaderText = "MonthlyWithdraw";
            this.Drop.Name = "Drop";
            this.Drop.ReadOnly = true;
            this.Drop.Width = 50;
            // 
            // User
            // 
            this.User.HeaderText = "Username";
            this.User.Name = "User";
            this.User.ReadOnly = true;
            // 
            // Pass
            // 
            this.Pass.HeaderText = "Password";
            this.Pass.Name = "Pass";
            this.Pass.ReadOnly = true;
            // 
            // Showemployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GraduationProjectTest.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(731, 375);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Showemployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Showemployee";
            this.Load += new System.EventHandler(this.Showemployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nameemp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hiredate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn Job;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sallary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Drop;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pass;
    }
}