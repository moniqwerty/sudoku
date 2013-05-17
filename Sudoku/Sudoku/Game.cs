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
    public partial class Game : Form
    {
        public Sudoku game;
        private Form1 form1;
        public Game(Form1 f){
            this.form1 = f;
            InitializeComponent();
            game = new Sudoku();
            if (form1.gameDiff == 0)
            {
                game.GenerateGame(GameLevel.SIMPLE);
            }
            if (form1.gameDiff == 1)
            {
                game.GenerateGame(GameLevel.MEDIUM);
            }
            if (form1.gameDiff == 2)
            {
                game.GenerateGame(GameLevel.COMPLEX);
            }

            int[,] set = game._numberSet;
            int[,] mset = game._problemSet;
            String str1 = "";
            String str2 = "";
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    str1 += set[i, j];
                    str2 += mset[i, j];
                }
                str1 += "\n";
                str2 += "\n";
            }
            label3.Text = str1;
            label4.Text = str2;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Game_Load(object sender, EventArgs e)
        {

        }
        bool isValid(int[][] matrix, int i, int j, int el) //
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
    }
}
