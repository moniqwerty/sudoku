using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        public int gameDiff{get;set;} //0==simple 1==medium 2==complex
        public Form1()
        {
            InitializeComponent();
            gameDiff = 1;
            
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

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form settings = new Settings(this);
            settings.Show();
        }

        private void nGameBtn_Click(object sender, EventArgs e)
        {
            Game game = new Game(this);
            game.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
