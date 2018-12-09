namespace Staves_Version_2
{
    partial class LoginScreen
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
            this.BTN_Login = new System.Windows.Forms.Button();
            this.BTN_Register = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TXT_Username = new System.Windows.Forms.TextBox();
            this.TXT_Password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BTN_Import = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTN_Login
            // 
            this.BTN_Login.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.BTN_Login.Location = new System.Drawing.Point(166, 143);
            this.BTN_Login.Name = "BTN_Login";
            this.BTN_Login.Size = new System.Drawing.Size(109, 27);
            this.BTN_Login.TabIndex = 0;
            this.BTN_Login.Text = "Login";
            this.BTN_Login.UseVisualStyleBackColor = true;
            this.BTN_Login.Click += new System.EventHandler(this.BTN_Login_Click);
            // 
            // BTN_Register
            // 
            this.BTN_Register.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.BTN_Register.Location = new System.Drawing.Point(12, 143);
            this.BTN_Register.Name = "BTN_Register";
            this.BTN_Register.Size = new System.Drawing.Size(109, 27);
            this.BTN_Register.TabIndex = 1;
            this.BTN_Register.Text = "Register";
            this.BTN_Register.UseVisualStyleBackColor = true;
            this.BTN_Register.Click += new System.EventHandler(this.BTN_Register_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // TXT_Username
            // 
            this.TXT_Username.Location = new System.Drawing.Point(114, 38);
            this.TXT_Username.Name = "TXT_Username";
            this.TXT_Username.Size = new System.Drawing.Size(158, 20);
            this.TXT_Username.TabIndex = 4;
            // 
            // TXT_Password
            // 
            this.TXT_Password.Location = new System.Drawing.Point(114, 73);
            this.TXT_Password.Name = "TXT_Password";
            this.TXT_Password.Size = new System.Drawing.Size(158, 20);
            this.TXT_Password.TabIndex = 5;
            this.TXT_Password.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 15F);
            this.label3.Location = new System.Drawing.Point(62, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Musical Medley";
            // 
            // BTN_Import
            // 
            this.BTN_Import.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.BTN_Import.Location = new System.Drawing.Point(166, 110);
            this.BTN_Import.Name = "BTN_Import";
            this.BTN_Import.Size = new System.Drawing.Size(109, 27);
            this.BTN_Import.TabIndex = 8;
            this.BTN_Import.Text = "Import";
            this.BTN_Import.UseVisualStyleBackColor = true;
            this.BTN_Import.Click += new System.EventHandler(this.BTN_Import_Click);
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(287, 182);
            this.Controls.Add(this.BTN_Import);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TXT_Password);
            this.Controls.Add(this.TXT_Username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTN_Register);
            this.Controls.Add(this.BTN_Login);
            this.Name = "LoginScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Loadup_Screen_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_Login;
        private System.Windows.Forms.Button BTN_Register;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TXT_Username;
        private System.Windows.Forms.TextBox TXT_Password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTN_Import;
    }
}