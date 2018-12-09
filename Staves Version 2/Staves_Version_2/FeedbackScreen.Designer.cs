namespace Staves_Version_2
{
    partial class FeedbackScreen
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
            this.BTN_Save = new System.Windows.Forms.Button();
            this.BTN_TryAgain = new System.Windows.Forms.Button();
            this.LBL_FeedBack = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TXT_Grade = new System.Windows.Forms.TextBox();
            this.TXT_Percentage = new System.Windows.Forms.TextBox();
            this.TXT_Improvements = new System.Windows.Forms.TextBox();
            this.CHC_Passed = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // BTN_Save
            // 
            this.BTN_Save.Location = new System.Drawing.Point(12, 177);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(77, 35);
            this.BTN_Save.TabIndex = 0;
            this.BTN_Save.Text = "Save";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // BTN_TryAgain
            // 
            this.BTN_TryAgain.Location = new System.Drawing.Point(141, 177);
            this.BTN_TryAgain.Name = "BTN_TryAgain";
            this.BTN_TryAgain.Size = new System.Drawing.Size(82, 35);
            this.BTN_TryAgain.TabIndex = 1;
            this.BTN_TryAgain.Text = "Try Again";
            this.BTN_TryAgain.UseVisualStyleBackColor = true;
            this.BTN_TryAgain.Click += new System.EventHandler(this.BTN_TryAgain_Click);
            // 
            // LBL_FeedBack
            // 
            this.LBL_FeedBack.AutoSize = true;
            this.LBL_FeedBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LBL_FeedBack.Location = new System.Drawing.Point(82, 9);
            this.LBL_FeedBack.Name = "LBL_FeedBack";
            this.LBL_FeedBack.Size = new System.Drawing.Size(70, 17);
            this.LBL_FeedBack.TabIndex = 2;
            this.LBL_FeedBack.Text = "Feedback";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Grade";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Percentage";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Improvements";
            // 
            // TXT_Grade
            // 
            this.TXT_Grade.Location = new System.Drawing.Point(91, 33);
            this.TXT_Grade.Name = "TXT_Grade";
            this.TXT_Grade.ReadOnly = true;
            this.TXT_Grade.Size = new System.Drawing.Size(100, 20);
            this.TXT_Grade.TabIndex = 6;
            // 
            // TXT_Percentage
            // 
            this.TXT_Percentage.Location = new System.Drawing.Point(91, 66);
            this.TXT_Percentage.Name = "TXT_Percentage";
            this.TXT_Percentage.ReadOnly = true;
            this.TXT_Percentage.Size = new System.Drawing.Size(100, 20);
            this.TXT_Percentage.TabIndex = 7;
            // 
            // TXT_Improvements
            // 
            this.TXT_Improvements.Location = new System.Drawing.Point(91, 100);
            this.TXT_Improvements.Name = "TXT_Improvements";
            this.TXT_Improvements.ReadOnly = true;
            this.TXT_Improvements.Size = new System.Drawing.Size(100, 20);
            this.TXT_Improvements.TabIndex = 8;
            // 
            // CHC_Passed
            // 
            this.CHC_Passed.AutoCheck = false;
            this.CHC_Passed.AutoSize = true;
            this.CHC_Passed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CHC_Passed.Font = new System.Drawing.Font("Comic Sans MS", 10F);
            this.CHC_Passed.Location = new System.Drawing.Point(12, 137);
            this.CHC_Passed.Name = "CHC_Passed";
            this.CHC_Passed.Size = new System.Drawing.Size(72, 23);
            this.CHC_Passed.TabIndex = 9;
            this.CHC_Passed.Text = "Passed";
            this.CHC_Passed.UseVisualStyleBackColor = true;
            // 
            // FeedbackScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(235, 237);
            this.Controls.Add(this.CHC_Passed);
            this.Controls.Add(this.TXT_Improvements);
            this.Controls.Add(this.TXT_Percentage);
            this.Controls.Add(this.TXT_Grade);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LBL_FeedBack);
            this.Controls.Add(this.BTN_TryAgain);
            this.Controls.Add(this.BTN_Save);
            this.Name = "FeedbackScreen";
            this.Text = "Feedback";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FeedbackScreen_FormClosing);
            this.Load += new System.EventHandler(this.FeedbackScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.Button BTN_TryAgain;
        private System.Windows.Forms.Label LBL_FeedBack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TXT_Grade;
        private System.Windows.Forms.TextBox TXT_Percentage;
        private System.Windows.Forms.TextBox TXT_Improvements;
        private System.Windows.Forms.CheckBox CHC_Passed;
    }
}