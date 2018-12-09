namespace Staves_Version_2
{
    partial class NewStudentDetails
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
            this.LBL_Title = new System.Windows.Forms.Label();
            this.LBL_FirstName = new System.Windows.Forms.Label();
            this.LBL_Password = new System.Windows.Forms.Label();
            this.LBL_Username = new System.Windows.Forms.Label();
            this.TXT_FirstName = new System.Windows.Forms.TextBox();
            this.TXT_Username = new System.Windows.Forms.TextBox();
            this.TXT_Pass = new System.Windows.Forms.TextBox();
            this.BTN_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LBL_Title
            // 
            this.LBL_Title.AutoSize = true;
            this.LBL_Title.Font = new System.Drawing.Font("Comic Sans MS", 14F);
            this.LBL_Title.Location = new System.Drawing.Point(30, 9);
            this.LBL_Title.Name = "LBL_Title";
            this.LBL_Title.Size = new System.Drawing.Size(148, 26);
            this.LBL_Title.TabIndex = 0;
            this.LBL_Title.Text = "Student Details";
            // 
            // LBL_FirstName
            // 
            this.LBL_FirstName.AutoSize = true;
            this.LBL_FirstName.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.LBL_FirstName.Location = new System.Drawing.Point(12, 39);
            this.LBL_FirstName.Name = "LBL_FirstName";
            this.LBL_FirstName.Size = new System.Drawing.Size(84, 19);
            this.LBL_FirstName.TabIndex = 1;
            this.LBL_FirstName.Text = "First Name";
            // 
            // LBL_Password
            // 
            this.LBL_Password.AutoSize = true;
            this.LBL_Password.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.LBL_Password.Location = new System.Drawing.Point(12, 118);
            this.LBL_Password.Name = "LBL_Password";
            this.LBL_Password.Size = new System.Drawing.Size(69, 19);
            this.LBL_Password.TabIndex = 2;
            this.LBL_Password.Text = "Password";
            // 
            // LBL_Username
            // 
            this.LBL_Username.AutoSize = true;
            this.LBL_Username.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.LBL_Username.Location = new System.Drawing.Point(12, 76);
            this.LBL_Username.Name = "LBL_Username";
            this.LBL_Username.Size = new System.Drawing.Size(74, 19);
            this.LBL_Username.TabIndex = 3;
            this.LBL_Username.Text = "Username";
            // 
            // TXT_FirstName
            // 
            this.TXT_FirstName.Location = new System.Drawing.Point(112, 39);
            this.TXT_FirstName.Name = "TXT_FirstName";
            this.TXT_FirstName.ReadOnly = true;
            this.TXT_FirstName.Size = new System.Drawing.Size(100, 23);
            this.TXT_FirstName.TabIndex = 5;
            // 
            // TXT_Username
            // 
            this.TXT_Username.Location = new System.Drawing.Point(112, 76);
            this.TXT_Username.Name = "TXT_Username";
            this.TXT_Username.ReadOnly = true;
            this.TXT_Username.Size = new System.Drawing.Size(100, 23);
            this.TXT_Username.TabIndex = 6;
            // 
            // TXT_Pass
            // 
            this.TXT_Pass.Location = new System.Drawing.Point(112, 117);
            this.TXT_Pass.Name = "TXT_Pass";
            this.TXT_Pass.ReadOnly = true;
            this.TXT_Pass.Size = new System.Drawing.Size(100, 23);
            this.TXT_Pass.TabIndex = 8;
            // 
            // BTN_OK
            // 
            this.BTN_OK.Location = new System.Drawing.Point(112, 160);
            this.BTN_OK.Name = "BTN_OK";
            this.BTN_OK.Size = new System.Drawing.Size(100, 23);
            this.BTN_OK.TabIndex = 9;
            this.BTN_OK.Text = "OK";
            this.BTN_OK.UseVisualStyleBackColor = true;
            this.BTN_OK.Click += new System.EventHandler(this.BTN_OK_Click);
            // 
            // NewStudentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(224, 192);
            this.Controls.Add(this.BTN_OK);
            this.Controls.Add(this.TXT_Pass);
            this.Controls.Add(this.TXT_Username);
            this.Controls.Add(this.TXT_FirstName);
            this.Controls.Add(this.LBL_Username);
            this.Controls.Add(this.LBL_Password);
            this.Controls.Add(this.LBL_FirstName);
            this.Controls.Add(this.LBL_Title);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "NewStudentDetails";
            this.Text = "Student Details";
            this.Load += new System.EventHandler(this.NewStudentDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_Title;
        private System.Windows.Forms.Label LBL_FirstName;
        private System.Windows.Forms.Label LBL_Password;
        private System.Windows.Forms.Label LBL_Username;
        private System.Windows.Forms.TextBox TXT_FirstName;
        private System.Windows.Forms.TextBox TXT_Username;
        private System.Windows.Forms.TextBox TXT_Pass;
        private System.Windows.Forms.Button BTN_OK;
    }
}