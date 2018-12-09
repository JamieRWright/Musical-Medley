namespace Staves_Version_2
{
    partial class SongMenu
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
            this.BTN_SignOut = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LBL_File = new System.Windows.Forms.Label();
            this.LBL_Difficulty = new System.Windows.Forms.Label();
            this.BTN_Launch = new System.Windows.Forms.Button();
            this.BTN_Help = new System.Windows.Forms.Button();
            this.CMB_SongList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // BTN_SignOut
            // 
            this.BTN_SignOut.Location = new System.Drawing.Point(34, 158);
            this.BTN_SignOut.Name = "BTN_SignOut";
            this.BTN_SignOut.Size = new System.Drawing.Size(121, 23);
            this.BTN_SignOut.TabIndex = 3;
            this.BTN_SignOut.Text = "Sign Out";
            this.BTN_SignOut.UseVisualStyleBackColor = true;
            this.BTN_SignOut.Click += new System.EventHandler(this.BTN_SignOut_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 15F);
            this.label1.Location = new System.Drawing.Point(57, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Menu";
            // 
            // LBL_File
            // 
            this.LBL_File.AutoSize = true;
            this.LBL_File.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LBL_File.Location = new System.Drawing.Point(12, 41);
            this.LBL_File.Name = "LBL_File";
            this.LBL_File.Size = new System.Drawing.Size(0, 13);
            this.LBL_File.TabIndex = 4;
            // 
            // LBL_Difficulty
            // 
            this.LBL_Difficulty.AutoSize = true;
            this.LBL_Difficulty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LBL_Difficulty.Location = new System.Drawing.Point(0, 0);
            this.LBL_Difficulty.Name = "LBL_Difficulty";
            this.LBL_Difficulty.Size = new System.Drawing.Size(0, 13);
            this.LBL_Difficulty.TabIndex = 5;
            // 
            // BTN_Launch
            // 
            this.BTN_Launch.Location = new System.Drawing.Point(34, 120);
            this.BTN_Launch.Name = "BTN_Launch";
            this.BTN_Launch.Size = new System.Drawing.Size(121, 23);
            this.BTN_Launch.TabIndex = 0;
            this.BTN_Launch.Text = "Launch";
            this.BTN_Launch.UseVisualStyleBackColor = true;
            this.BTN_Launch.Click += new System.EventHandler(this.BTN_Launch_Click);
            // 
            // BTN_Help
            // 
            this.BTN_Help.Location = new System.Drawing.Point(34, 83);
            this.BTN_Help.Name = "BTN_Help";
            this.BTN_Help.Size = new System.Drawing.Size(121, 23);
            this.BTN_Help.TabIndex = 2;
            this.BTN_Help.Text = "Help";
            this.BTN_Help.UseVisualStyleBackColor = true;
            this.BTN_Help.Click += new System.EventHandler(this.BTN_Help_Click);
            // 
            // CMB_SongList
            // 
            this.CMB_SongList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_SongList.FormattingEnabled = true;
            this.CMB_SongList.Location = new System.Drawing.Point(34, 49);
            this.CMB_SongList.Name = "CMB_SongList";
            this.CMB_SongList.Size = new System.Drawing.Size(121, 21);
            this.CMB_SongList.TabIndex = 1;
            // 
            // SongMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(184, 204);
            this.Controls.Add(this.CMB_SongList);
            this.Controls.Add(this.LBL_Difficulty);
            this.Controls.Add(this.LBL_File);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTN_SignOut);
            this.Controls.Add(this.BTN_Help);
            this.Controls.Add(this.BTN_Launch);
            this.Name = "SongMenu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SongMenu_FormClosing);
            this.Load += new System.EventHandler(this.SongMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BTN_SignOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LBL_File;
        private System.Windows.Forms.Label LBL_Difficulty;
        private System.Windows.Forms.Button BTN_Launch;
        private System.Windows.Forms.Button BTN_Help;
        private System.Windows.Forms.ComboBox CMB_SongList;
    }
}