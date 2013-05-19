namespace Sudoku
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtHard = new System.Windows.Forms.RadioButton();
            this.rbtMedium = new System.Windows.Forms.RadioButton();
            this.rbtEasy = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtHard);
            this.groupBox1.Controls.Add(this.rbtMedium);
            this.groupBox1.Controls.Add(this.rbtEasy);
            this.groupBox1.Font = new System.Drawing.Font("Papyrus", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox1.Location = new System.Drawing.Point(59, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 145);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose Difficulty";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rbtHard
            // 
            this.rbtHard.AutoSize = true;
            this.rbtHard.Location = new System.Drawing.Point(31, 98);
            this.rbtHard.Name = "rbtHard";
            this.rbtHard.Size = new System.Drawing.Size(61, 23);
            this.rbtHard.TabIndex = 2;
            this.rbtHard.TabStop = true;
            this.rbtHard.Text = "Hard";
            this.rbtHard.UseVisualStyleBackColor = true;
            this.rbtHard.CheckedChanged += new System.EventHandler(this.rbtHard_CheckedChanged);
            // 
            // rbtMedium
            // 
            this.rbtMedium.AutoSize = true;
            this.rbtMedium.Location = new System.Drawing.Point(31, 65);
            this.rbtMedium.Name = "rbtMedium";
            this.rbtMedium.Size = new System.Drawing.Size(77, 23);
            this.rbtMedium.TabIndex = 1;
            this.rbtMedium.TabStop = true;
            this.rbtMedium.Text = "Medium";
            this.rbtMedium.UseVisualStyleBackColor = true;
            this.rbtMedium.CheckedChanged += new System.EventHandler(this.rbtMedium_CheckedChanged);
            // 
            // rbtEasy
            // 
            this.rbtEasy.AutoSize = true;
            this.rbtEasy.Location = new System.Drawing.Point(31, 32);
            this.rbtEasy.Name = "rbtEasy";
            this.rbtEasy.Size = new System.Drawing.Size(62, 23);
            this.rbtEasy.TabIndex = 0;
            this.rbtEasy.TabStop = true;
            this.rbtEasy.Text = "Easy";
            this.rbtEasy.UseVisualStyleBackColor = true;
            this.rbtEasy.CheckedChanged += new System.EventHandler(this.rbtEasy_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(121, 241);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.BackgroundImage = global::Sudoku.Properties.Resources.back1;
            this.ClientSize = new System.Drawing.Size(318, 303);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Settings_FormClosed);
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtHard;
        private System.Windows.Forms.RadioButton rbtMedium;
        private System.Windows.Forms.RadioButton rbtEasy;
        private System.Windows.Forms.Button button1;

    }
}