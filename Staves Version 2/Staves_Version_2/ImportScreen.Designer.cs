namespace Staves_Version_2
{
    partial class ImportScreen
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
            this.BTN_Browse = new System.Windows.Forms.Button();
            this.OFD_FileSearch = new System.Windows.Forms.OpenFileDialog();
            this.TXT_FilePath = new System.Windows.Forms.TextBox();
            this.BTN_Import = new System.Windows.Forms.Button();
            this.LBL_Instructions = new System.Windows.Forms.Label();
            this.TXT_SongName = new System.Windows.Forms.TextBox();
            this.LBL_SongName = new System.Windows.Forms.Label();
            this.BTN_Delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTN_Browse
            // 
            this.BTN_Browse.Location = new System.Drawing.Point(197, 43);
            this.BTN_Browse.Name = "BTN_Browse";
            this.BTN_Browse.Size = new System.Drawing.Size(75, 20);
            this.BTN_Browse.TabIndex = 0;
            this.BTN_Browse.Text = "Browse...";
            this.BTN_Browse.UseVisualStyleBackColor = true;
            this.BTN_Browse.Click += new System.EventHandler(this.BTN_Browse_Click);
            // 
            // OFD_FileSearch
            // 
            this.OFD_FileSearch.FileOk += new System.ComponentModel.CancelEventHandler(this.OFD_FileSearch_FileOk);
            // 
            // TXT_FilePath
            // 
            this.TXT_FilePath.Location = new System.Drawing.Point(12, 43);
            this.TXT_FilePath.Name = "TXT_FilePath";
            this.TXT_FilePath.Size = new System.Drawing.Size(179, 20);
            this.TXT_FilePath.TabIndex = 1;
            // 
            // BTN_Import
            // 
            this.BTN_Import.Location = new System.Drawing.Point(197, 69);
            this.BTN_Import.Name = "BTN_Import";
            this.BTN_Import.Size = new System.Drawing.Size(75, 23);
            this.BTN_Import.TabIndex = 2;
            this.BTN_Import.Text = "Import";
            this.BTN_Import.UseVisualStyleBackColor = true;
            this.BTN_Import.Click += new System.EventHandler(this.BTN_Continue_Click);
            // 
            // LBL_Instructions
            // 
            this.LBL_Instructions.AutoSize = true;
            this.LBL_Instructions.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Instructions.Location = new System.Drawing.Point(12, 73);
            this.LBL_Instructions.Name = "LBL_Instructions";
            this.LBL_Instructions.Size = new System.Drawing.Size(166, 15);
            this.LBL_Instructions.TabIndex = 3;
            this.LBL_Instructions.Text = "Please enter your file to import";
            // 
            // TXT_SongName
            // 
            this.TXT_SongName.Location = new System.Drawing.Point(98, 9);
            this.TXT_SongName.Name = "TXT_SongName";
            this.TXT_SongName.Size = new System.Drawing.Size(93, 20);
            this.TXT_SongName.TabIndex = 4;
            // 
            // LBL_SongName
            // 
            this.LBL_SongName.AutoSize = true;
            this.LBL_SongName.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.LBL_SongName.Location = new System.Drawing.Point(11, 9);
            this.LBL_SongName.Name = "LBL_SongName";
            this.LBL_SongName.Size = new System.Drawing.Size(81, 19);
            this.LBL_SongName.TabIndex = 5;
            this.LBL_SongName.Text = "Song Name";
            // 
            // BTN_Delete
            // 
            this.BTN_Delete.Location = new System.Drawing.Point(197, 9);
            this.BTN_Delete.Name = "BTN_Delete";
            this.BTN_Delete.Size = new System.Drawing.Size(75, 19);
            this.BTN_Delete.TabIndex = 6;
            this.BTN_Delete.Text = "Delete";
            this.BTN_Delete.UseVisualStyleBackColor = true;
            this.BTN_Delete.Click += new System.EventHandler(this.BTN_Delete_Click);
            // 
            // ImportScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(284, 97);
            this.Controls.Add(this.BTN_Delete);
            this.Controls.Add(this.LBL_SongName);
            this.Controls.Add(this.TXT_SongName);
            this.Controls.Add(this.LBL_Instructions);
            this.Controls.Add(this.BTN_Import);
            this.Controls.Add(this.TXT_FilePath);
            this.Controls.Add(this.BTN_Browse);
            this.Name = "ImportScreen";
            this.Text = "Import";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImportScreen_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_Browse;
        private System.Windows.Forms.OpenFileDialog OFD_FileSearch;
        private System.Windows.Forms.TextBox TXT_FilePath;
        private System.Windows.Forms.Button BTN_Import;
        private System.Windows.Forms.Label LBL_Instructions;
        private System.Windows.Forms.TextBox TXT_SongName;
        private System.Windows.Forms.Label LBL_SongName;
        private System.Windows.Forms.Button BTN_Delete;
    }
}