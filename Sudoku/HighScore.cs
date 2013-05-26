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
        //FileStream fileStream;
        public HighScore()
        {
            InitializeComponent();
            score = new List<Score>(11);
        }
        public void sortHighScore(Score s)
        {
            score.Add(s);
            if (score.Count() != 0)                
                score.Sort((x, y) => y.Points.CompareTo(x.Points));
            for (int i = 0; i < score.Count(); i++)
            {
                listBox1.Items.Add(string.Format("{0}. {1}", (i + 1), score[i]));                
            }
        }
        public List<Score> ReadScores(FileStream fileStream)
        {
            string line;
            List<Score> highScore = new List<Score>(); ;
            try
            {
                
                TextReader sr = new StreamReader(fileStream);
                line = sr.ReadLine();
                while (line != null)
                {
                    string[] parts = line.Split(' ');
                    if (parts.Length>=2) highScore.Add(new Score(parts[0],Convert.ToInt32(parts[1])));
                    line = sr.ReadLine();
                }
                sr.Close();
                score = highScore;
                if (score.Count() != 0)
                    score.Sort((x, y) => y.Points.CompareTo(x.Points));
                for (int i = 0; i < score.Count(); i++)
                {
                    listBox1.Items.Add(string.Format("{0}. {1}", (i + 1), score[i]));
                }
                //fileStream.Close();
            }
            catch (Exception e)
            {
                //Error.Text += "neprocitav";
                Console.WriteLine("Exception: " + e.Message);
                
            }

            return score;
        }
        public bool WriteScores(string fileName)
        {
            bool written = false;
            try
            {
                System.IO.File.Delete(@fileName);
                FileStream fileStream = new FileStream(@fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                TextWriter wr = new StreamWriter(fileStream);
                for (int i = 0; i < score.Count(); i++)
                {
                    wr.WriteLine(score[i].ToString());
                    //wr.WriteLine(string.Format("{0}", score[i]));
                }
                wr.Close();
                fileStream.Close();
                /*
                fileStream = new FileStream(@fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                TextReader sr = new StreamReader(fileStream);
                string line = sr.ReadLine();
                while (line != null)
                {
                    //Error.Text += "\n" + line;
                    line = sr.ReadLine();
                }
                sr.Close();
                fileStream.Close();*/
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
                
                return written;

        }

        private void HighScore_Load(object sender, EventArgs e)
        {

        }
    }
}
