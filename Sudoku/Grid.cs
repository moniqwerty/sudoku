using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Sudoku
{
    [Serializable]
    public class Grid
    {
        public Sudoku game;

        public List<int> values;
        public List<int> errorList;
        public List<int> firstGenerated;
        public int lastHint;
        public int hintTime = -1;
        public int numberOfHints = 3;
        public int time { get; set; }

        public int gameDiff;

        public Grid(int gameDiff)
        {
            game = new Sudoku();
            this.gameDiff = gameDiff;
           
            firstGenerated = new List<int>();
            values = new List<int>();
            errorList = new List<int>();

            for (int i = 0; i < 81; i++)
                values.Add(0);
            
            if (gameDiff == 0)
            {
                game.GenerateGame(GameLevel.SIMPLE);
            }
            if (gameDiff == 1)
            {
                game.GenerateGame(GameLevel.MEDIUM);
            }
            if (gameDiff == 2)
            {
                game.GenerateGame(GameLevel.COMPLEX);
            }
        }
        
    }
}
