namespace Sudoku
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.nGameBtn = new System.Windows.Forms.Button();
            this.settingsBtn = new System.Windows.Forms.Button();
            this.aboutBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Papyrus", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(161, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sudoku!";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // nGameBtn
            // 
            this.nGameBtn.BackColor = System.Drawing.Color.Tan;
           // this.nGameBtn.
            this.nGameBtn.Font = new System.Drawing.Font("Papyrus", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nGameBtn.Location = new System.Drawing.Point(126, 282);
            this.nGameBtn.Name = "nGameBtn";
            this.nGameBtn.Size = new System.Drawing.Size(111, 28);
            this.nGameBtn.TabIndex = 1;
            this.nGameBtn.Text = "New Game";
            this.nGameBtn.UseVisualStyleBackColor = false;
            this.nGameBtn.Click += new System.EventHandler(this.nGameBtn_Click);
            // 
            // settingsBtn
            // 
            this.settingsBtn.BackColor = System.Drawing.Color.Tan;
            this.settingsBtn.Font = new System.Drawing.Font("Papyrus", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsBtn.Location = new System.Drawing.Point(126, 328);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(111, 28);
            this.settingsBtn.TabIndex = 2;
            this.settingsBtn.Text = "Settings";
            this.settingsBtn.UseVisualStyleBackColor = false;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // aboutBtn
            // 
            this.aboutBtn.BackColor = System.Drawing.Color.Tan;
            this.aboutBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.aboutBtn.Font = new System.Drawing.Font("Papyrus", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutBtn.Location = new System.Drawing.Point(126, 377);
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.Size = new System.Drawing.Size(111, 28);
            this.aboutBtn.TabIndex = 3;
            this.aboutBtn.Text = "About";
            this.aboutBtn.UseVisualStyleBackColor = false;
            this.aboutBtn.Click += new System.EventHandler(this.aboutBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Tan;
            this.exitBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.exitBtn.Font = new System.Drawing.Font("Papyrus", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Location = new System.Drawing.Point(126, 427);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(111, 28);
            this.exitBtn.TabIndex = 4;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.nGameBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.exitBtn;
            this.ClientSize = new System.Drawing.Size(342, 653);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.aboutBtn);
            this.Controls.Add(this.settingsBtn);
            this.Controls.Add(this.nGameBtn);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "SplashScreen";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button nGameBtn;
        private System.Windows.Forms.Button settingsBtn;
        private System.Windows.Forms.Button aboutBtn;
        private System.Windows.Forms.Button exitBtn;



    }
}

