using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form about = new About(this);
            about.Show();
        }             

        private void nGameBtn_Click(object sender, EventArgs e)
        {
            Form settings = new Settings(this);
            settings.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       
    }
}
