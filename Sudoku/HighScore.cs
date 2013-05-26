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
    public partial class HighScore : Form
    {
        List<Score> score;

        public HighScore()
        {
            InitializeComponent();
            score = new List<Score>(11);
        }
        public void sortHighScore(Score s)
        {
            if (score.Count() != 0)                
                score.Sort((x, y) => y.Points.CompareTo(x.Points));

            score.Add(s);
            for (int i = 0; i < score.Count(); i++)
            {
                listBox1.Items.Add(string.Format("{0}. {1}", (i + 1), score[i]));                
            }
        }
        public List<Score> ReadScores(string fileName)
        {
            string line;
            List<Score> highScore = new List<Score>(); ;
            try
            {
                TextReader sr = new StreamReader(@fileName);
                line = sr.ReadLine();
                while (line != null)
                {
                    string[] parts = line.Split(' ');
                    highScore.Add(new Score(parts[0],Convert.ToInt32(parts[1])));
                    line = sr.ReadLine();
                }
                sr.Close();
                score = highScore;
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                
            }

            return score;
        }
        public bool WriteScores(string fileName)
        {
            bool written = false;
            try
            {
                TextWriter wr = new StreamWriter(@fileName);
                for (int i = 0; i < score.Count(); i++)
                {
                    wr.WriteLine(string.Format("{0}", score[i]));
                    wr.WriteLine("tuka");
                }
                wr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return written;
        }
    }
}
