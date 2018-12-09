namespace Staves_Version_2
{
    partial class PauseScreen
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
            this.BTN_Continue = new System.Windows.Forms.Button();
            this.BTN_Help = new System.Windows.Forms.Button();
            this.LBL_PauseScreen = new System.Windows.Forms.Label();
            this.BTN_Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTN_Continue
            // 
            this.BTN_Continue.Location = new System.Drawing.Point(36, 45);
            this.BTN_Continue.Name = "BTN_Continue";
            this.BTN_Continue.Size = new System.Drawing.Size(75, 23);
            this.BTN_Continue.TabIndex = 0;
            this.BTN_Continue.Text = "Continue";
            this.BTN_Continue.UseVisualStyleBackColor = true;
            this.BTN_Continue.Click += new System.EventHandler(this.BTN_Continue_Click);
            // 
            // BTN_Help
            // 
            this.BTN_Help.Location = new System.Drawing.Point(36, 80);
            this.BTN_Help.Name = "BTN_Help";
            this.BTN_Help.Size = new System.Drawing.Size(75, 23);
            this.BTN_Help.TabIndex = 1;
            this.BTN_Help.Text = "Help";
            this.BTN_Help.UseVisualStyleBackColor = true;
            this.BTN_Help.Click += new System.EventHandler(this.BTN_Help_Click);
            // 
            // LBL_PauseScreen
            // 
            this.LBL_PauseScreen.AutoSize = true;
            this.LBL_PauseScreen.Font = new System.Drawing.Font("Comic Sans MS", 18F);
            this.LBL_PauseScreen.Location = new System.Drawing.Point(34, 9);
            this.LBL_PauseScreen.Name = "LBL_PauseScreen";
            this.LBL_PauseScreen.Size = new System.Drawing.Size(77, 33);
            this.LBL_PauseScreen.TabIndex = 2;
            this.LBL_PauseScreen.Text = "Pause";
            // 
            // BTN_Exit
            // 
            this.BTN_Exit.Location = new System.Drawing.Point(36, 116);
            this.BTN_Exit.Name = "BTN_Exit";
            this.BTN_Exit.Size = new System.Drawing.Size(75, 23);
            this.BTN_Exit.TabIndex = 3;
            this.BTN_Exit.Text = "Exit";
            this.BTN_Exit.UseVisualStyleBackColor = true;
            this.BTN_Exit.Click += new System.EventHandler(this.BTN_Exit_Click);
            // 
            // PauseScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(149, 151);
            this.Controls.Add(this.BTN_Exit);
            this.Controls.Add(this.LBL_PauseScreen);
            this.Controls.Add(this.BTN_Help);
            this.Controls.Add(this.BTN_Continue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "PauseScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PauseScreen_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_Continue;
        private System.Windows.Forms.Button BTN_Help;
        private System.Windows.Forms.Label LBL_PauseScreen;
        private System.Windows.Forms.Button BTN_Exit;
    }
}