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
        bool isValid(int[][] matrix, int i, int j, int el)
        {
            for (int k = 0; k < 9; k++)
            {
                if (matrix[i][k] == el)
                {
                    return false;
                }
            }
            for (int k = 0; k < 9; k++)
            {
                if (matrix[k][j] == el)
                {
                    return false;
                }
            }
            int xi = 0, yi = 0, xj = 0, yj = 0;
            if ((i >= 0) && (i <= 2))
            {
                xi = 0;
                yi = 2;
            }
            else if ((j >= 3) && (j <= 5))
            {
                xj = 3;
                yj = 5;
            }
            else if ((j >= 6) && (j <= 8))
            {
                xj = 6;
                yj = 8;
            }
            else if ((i >= 3) && (i <= 5))
            {
                xi = 3;
                yi = 5;
            }
            if ((j >= 0) && (j <= 2))
            {
                xj = 0;
                yj = 2;
            }
            else if ((i >= 6) && (i <= 8))
            {
                xi = 6;
                yi = 8;
            }
            for (int k = xi; k < yi; k++)
            {
                for (int m = xj; m < yj; m++)
                {
                    if (matrix[k][m] == el)
                    {
                        return false;
                    }
                }
            }
            return true;
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
            Game game = new Game();
            game.Show();
        }
    }
}
