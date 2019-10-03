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
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnDbSettings = new System.Windows.Forms.Button();
            this.btnBackupDB = new System.Windows.Forms.Button();
            this.btnFolderSettings = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBackupAll = new System.Windows.Forms.Button();
            this.btnBackupFolder = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.timerDateTime = new System.Windows.Forms.Timer(this.components);
            this.lblDate = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblLastData = new System.Windows.Forms.Label();
            this.lblLogs = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(0, 0);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(195, 50);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnDbSettings
            // 
            this.btnDbSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDbSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDbSettings.Location = new System.Drawing.Point(0, 300);
            this.btnDbSettings.Name = "btnDbSettings";
            this.btnDbSettings.Size = new System.Drawing.Size(195, 50);
            this.btnDbSettings.TabIndex = 4;
            this.btnDbSettings.Text = "DB Settings";
            this.btnDbSettings.UseVisualStyleBackColor = true;
            this.btnDbSettings.Click += new System.EventHandler(this.btnDbSettings_Click);
            // 
            // btnBackupDB
            // 
            this.btnBackupDB.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBackupDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackupDB.Location = new System.Drawing.Point(0, 50);
            this.btnBackupDB.Name = "btnBackupDB";
            this.btnBackupDB.Size = new System.Drawing.Size(195, 50);
            this.btnBackupDB.TabIndex = 1;
            this.btnBackupDB.Text = "Backup DB";
            this.btnBackupDB.UseVisualStyleBackColor = true;
            this.btnBackupDB.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnFolderSettings
            // 
            this.btnFolderSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnFolderSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFolderSettings.Location = new System.Drawing.Point(0, 350);
            this.btnFolderSettings.Name = "btnFolderSettings";
            this.btnFolderSettings.Size = new System.Drawing.Size(195, 50);
            this.btnFolderSettings.TabIndex = 3;
            this.btnFolderSettings.Text = "Folder Settings";
            this.btnFolderSettings.UseVisualStyleBackColor = true;
            this.btnFolderSettings.Click += new System.EventHandler(this.btnFolderSettings_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBackupAll);
            this.panel1.Controls.Add(this.btnBackupFolder);
            this.panel1.Controls.Add(this.btnBackupDB);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.btnDbSettings);
            this.panel1.Controls.Add(this.btnFolderSettings);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(195, 450);
            this.panel1.TabIndex = 0;
            // 
            // btnBackupAll
            // 
            this.btnBackupAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBackupAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackupAll.Location = new System.Drawing.Point(0, 150);
            this.btnBackupAll.Name = "btnBackupAll";
            this.btnBackupAll.Size = new System.Drawing.Size(195, 50);
            this.btnBackupAll.TabIndex = 1;
            this.btnBackupAll.Text = "Backup All";
            this.btnBackupAll.UseVisualStyleBackColor = true;
            this.btnBackupAll.Click += new System.EventHandler(this.btnBackupAll_Click);
            // 
            // btnBackupFolder
            // 
            this.btnBackupFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBackupFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackupFolder.Location = new System.Drawing.Point(0, 100);
            this.btnBackupFolder.Name = "btnBackupFolder";
            this.btnBackupFolder.Size = new System.Drawing.Size(195, 50);
            this.btnBackupFolder.TabIndex = 2;
            this.btnBackupFolder.Text = "Backup Folder";
            this.btnBackupFolder.UseVisualStyleBackColor = true;
            this.btnBackupFolder.Click += new System.EventHandler(this.btnBackupFolder_Click);
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(0, 400);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(195, 50);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(195, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(605, 450);
            this.panel2.TabIndex = 1;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTime.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(580, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(25, 29);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "-";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblDate);
            this.panel3.Controls.Add(this.lblTime);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(605, 44);
            this.panel3.TabIndex = 1;
            // 
            // timerDateTime
            // 
            this.timerDateTime.Enabled = true;
            this.timerDateTime.Interval = 1000;
            this.timerDateTime.Tick += new System.EventHandler(this.timerDateTime_Tick);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblDate.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(0, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(15, 18);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "-";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblLastData);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 44);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(605, 100);
            this.panel4.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblLogs);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 144);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(605, 306);
            this.panel5.TabIndex = 3;
            // 
            // lblLastData
            // 
            this.lblLastData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLastData.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblLastData.Location = new System.Drawing.Point(0, 0);
            this.lblLastData.Name = "lblLastData";
            this.lblLastData.Size = new System.Drawing.Size(605, 100);
            this.lblLastData.TabIndex = 2;
            this.lblLastData.Text = "--------------------------";
            // 
            // lblLogs
            // 
            this.lblLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogs.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblLogs.Location = new System.Drawing.Point(0, 0);
            this.lblLogs.Name = "lblLogs";
            this.lblLogs.Size = new System.Drawing.Size(605, 306);
            this.lblLogs.TabIndex = 2;
            this.lblLogs.Text = "--------------------------";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(755, 388);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup Management System";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnDbSettings;
        private System.Windows.Forms.Button btnBackupDB;
        private System.Windows.Forms.Button btnFolderSettings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBackupFolder;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnBackupAll;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timerDateTime;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblLogs;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblLastData;
    }
}

