using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public class Score
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public Score(string name,int points)
        {
            this.Name = name;
            this.Points = points;
        }
        public override string ToString()
        {
            return Name+" "+Convert.ToString(Points);
        }
    }
}
