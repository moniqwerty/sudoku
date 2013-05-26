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
    public partial class Settings : Form
    {
        public Form1 parent;
        public int gameDiff { get; set; } //0==simple 1==medium 2==complex

        public Settings(Form1 p)
        {
            InitializeComponent();
            gameDiff = 1;

            parent = p;
            
            groupBox1.BackColor = System.Drawing.Color.Transparent;
                
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void rbtEasy_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtEasy.Checked){
                gameDiff = 0;
            }
        }

        private void rbtMedium_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtMedium.Checked)
            {
                gameDiff = 1;
            }
        }

        private void rbtHard_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtHard.Checked)
            {
                gameDiff = 2;
            }
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game game = new Game(this);
            game.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
