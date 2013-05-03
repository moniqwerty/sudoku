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
        public Game()
        {
            InitializeComponent();
            game = new Sudoku();
            game.GenerateGame(GameLevel.SIMPLE);
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
    }
}
