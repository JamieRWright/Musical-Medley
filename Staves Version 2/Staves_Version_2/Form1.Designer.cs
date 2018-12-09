namespace Staves_Version_2
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SongAttempted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Difficulty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Percentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTN_Exit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentName,
            this.SongAttempted,
            this.Grade,
            this.Difficulty,
            this.Percentage});
            this.dataGridView1.Location = new System.Drawing.Point(32, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(541, 319);
            this.dataGridView1.TabIndex = 0;
            // 
            // StudentName
            // 
            this.StudentName.HeaderText = "StudentName";
            this.StudentName.Name = "StudentName";
            // 
            // SongAttempted
            // 
            this.SongAttempted.HeaderText = "Song";
            this.SongAttempted.Name = "SongAttempted";
            // 
            // Grade
            // 
            this.Grade.HeaderText = "Grade";
            this.Grade.Name = "Grade";
            // 
            // Difficulty
            // 
            this.Difficulty.HeaderText = "Difficulty";
            this.Difficulty.Name = "Difficulty";
            // 
            // Percentage
            // 
            this.Percentage.HeaderText = "Percentage";
            this.Percentage.Name = "Percentage";
            // 
            // BTN_Exit
            // 
            this.BTN_Exit.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.BTN_Exit.Location = new System.Drawing.Point(488, 12);
            this.BTN_Exit.Name = "BTN_Exit";
            this.BTN_Exit.Size = new System.Drawing.Size(85, 30);
            this.BTN_Exit.TabIndex = 1;
            this.BTN_Exit.Text = "Exit";
            this.BTN_Exit.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 13F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(28, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "[Teacher\'s Name] Markbook";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(602, 393);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTN_Exit);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Mark Book";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SongAttempted;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Difficulty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Percentage;
        private System.Windows.Forms.Button BTN_Exit;
        private System.Windows.Forms.Label label1;
    }
}