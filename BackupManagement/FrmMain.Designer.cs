namespace BackupManagement
{
    partial class FrmMain
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
            this.btnStart = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.btnDbSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(132, 384);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(794, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "server=localhost;port=3306;database=osl_adm_2019_aust;userid=aspNetCore;pwd=QaaPV" +
    "G9VkZ8APegN;sslmode=none;Max Pool Size=1000;";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(794, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "E:\\4 User Files\\Nazmul\\!TempBackup\\!Backups";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 64);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(794, 20);
            this.textBox3.TabIndex = 1;
            this.textBox3.Text = "server=localhost;port=3306;database=osl_adm_nstu_2019;userid=aspNetCore;pwd=QaaPV" +
    "G9VkZ8APegN;sslmode=none;Max Pool Size=1000;";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(12, 90);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(794, 20);
            this.textBox4.TabIndex = 1;
            this.textBox4.Text = "server=localhost;port=3306;database=osl_ac_bafsdjobs;userid=aspNetCore;pwd=QaaPVG" +
    "9VkZ8APegN;sslmode=none;";
            // 
            // btnDbSettings
            // 
            this.btnDbSettings.Location = new System.Drawing.Point(249, 384);
            this.btnDbSettings.Name = "btnDbSettings";
            this.btnDbSettings.Size = new System.Drawing.Size(75, 23);
            this.btnDbSettings.TabIndex = 3;
            this.btnDbSettings.Text = "DB Settings";
            this.btnDbSettings.UseVisualStyleBackColor = true;
            this.btnDbSettings.Click += new System.EventHandler(this.btnDbSettings_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 450);
            this.Controls.Add(this.btnDbSettings);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnStart);
            this.Name = "FrmMain";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button btnDbSettings;
    }
}

