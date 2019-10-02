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
            this.btnDbSettings = new System.Windows.Forms.Button();
            this.btnBackupDB = new System.Windows.Forms.Button();
            this.btnFolderSettings = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBackupFolder = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnBackupAll = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
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
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 450);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup Management System";
            this.panel1.ResumeLayout(false);
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
    }
}

