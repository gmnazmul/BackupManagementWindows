namespace BackupManagement
{
    partial class FrmDbSettings
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
            this.txtConnectionStrings = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkZipDbFiles = new System.Windows.Forms.CheckBox();
            this.txtBackupStartMinute = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBackupStartHour = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBackupMinute = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtConnectionStrings
            // 
            this.txtConnectionStrings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConnectionStrings.Location = new System.Drawing.Point(3, 16);
            this.txtConnectionStrings.Multiline = true;
            this.txtConnectionStrings.Name = "txtConnectionStrings";
            this.txtConnectionStrings.Size = new System.Drawing.Size(794, 251);
            this.txtConnectionStrings.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtConnectionStrings);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 270);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Strings (each line should contain one connection string)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtOutputPath);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 39);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output Path";
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOutputPath.Location = new System.Drawing.Point(3, 16);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(794, 20);
            this.txtOutputPath.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkZipDbFiles);
            this.groupBox3.Controls.Add(this.txtBackupStartMinute);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtBackupStartHour);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtBackupMinute);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(800, 100);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Options";
            // 
            // chkZipDbFiles
            // 
            this.chkZipDbFiles.AutoSize = true;
            this.chkZipDbFiles.Location = new System.Drawing.Point(132, 66);
            this.chkZipDbFiles.Name = "chkZipDbFiles";
            this.chkZipDbFiles.Size = new System.Drawing.Size(83, 17);
            this.chkZipDbFiles.TabIndex = 2;
            this.chkZipDbFiles.Text = "Zip DB Files";
            this.chkZipDbFiles.UseVisualStyleBackColor = true;
            // 
            // txtBackupStartMinute
            // 
            this.txtBackupStartMinute.Location = new System.Drawing.Point(298, 13);
            this.txtBackupStartMinute.Name = "txtBackupStartMinute";
            this.txtBackupStartMinute.Size = new System.Drawing.Size(100, 20);
            this.txtBackupStartMinute.TabIndex = 1;
            this.txtBackupStartMinute.Text = "0";
            this.txtBackupStartMinute.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBackupStartHour_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Start Minute";
            // 
            // txtBackupStartHour
            // 
            this.txtBackupStartHour.Location = new System.Drawing.Point(132, 13);
            this.txtBackupStartHour.Name = "txtBackupStartHour";
            this.txtBackupStartHour.Size = new System.Drawing.Size(100, 20);
            this.txtBackupStartHour.TabIndex = 1;
            this.txtBackupStartHour.Text = "0";
            this.txtBackupStartHour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBackupStartHour_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Start Hour";
            // 
            // txtBackupMinute
            // 
            this.txtBackupMinute.Location = new System.Drawing.Point(132, 39);
            this.txtBackupMinute.Name = "txtBackupMinute";
            this.txtBackupMinute.Size = new System.Drawing.Size(100, 20);
            this.txtBackupMinute.TabIndex = 1;
            this.txtBackupMinute.Text = "120";
            this.txtBackupMinute.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBackupStartHour_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Backup Every (minute)";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(323, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(405, 415);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FrmDbSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDbSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DB Settings";
            this.Load += new System.EventHandler(this.FrmDbSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtConnectionStrings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtBackupMinute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkZipDbFiles;
        private System.Windows.Forms.TextBox txtBackupStartMinute;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBackupStartHour;
        private System.Windows.Forms.Label label2;
    }
}