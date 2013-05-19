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
        public Settings(Form1 p)
        {
            InitializeComponent();
            parent = p;
            if (parent.gameDiff == 0)
            {
                rbtEasy.Checked = true;
                rbtMedium.Checked = false;
                rbtHard.Checked = false;

            }
            if (parent.gameDiff == 1)
            {
                rbtEasy.Checked = false;
                rbtMedium.Checked = true;
                rbtHard.Checked = false;
            }
            if (parent.gameDiff == 2)
            {
                rbtEasy.Checked = false;
                rbtMedium.Checked = false;
                rbtHard.Checked = true;
            }
            groupBox1.BackColor = System.Drawing.Color.Transparent;
                
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void rbtEasy_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtEasy.Checked){
                parent.gameDiff = 0;
            }
        }

        private void rbtMedium_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtMedium.Checked)
            {
                parent.gameDiff = 1;
            }
        }

        private void rbtHard_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtHard.Checked)
            {
                parent.gameDiff = 2;
            }
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
