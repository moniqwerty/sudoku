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

        public static int WIDTH = 800;
        public static int HEIGHT = 700;
        public int time { get; set; }

        public static int startPositionX = 320;
        public static int startPositionY = 120;
        public static int gridWidth = 450;

        public static float CubeSize = gridWidth / 3.0F;
        float SmallCubeSize = CubeSize / 3.0F;

        public Pen pen;

        public List<Label> labels;
        public List<int> errorList;
        public List<int> firstGenerated;
        public TextBox textBox1;

        public Game(Form1 f)
        {

            this.form1 = f;

            InitializeComponent();
            timer1.Interval = 1000;
            time = 0;
            timer1.Start();
            game = new Sudoku();
            this.Width = WIDTH;
            this.Height = HEIGHT;


            textBox1 = new TextBox();

            this.textBox1.TabIndex = 1;

            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            textBox1.Font = new Font("Papyrus", 16F, (FontStyle.Bold), GraphicsUnit.Point, ((byte)(0)));
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.Visible = false;
            this.Controls.Add(textBox1);

            firstGenerated = new List<int>();
            labels = new List<Label>();
            errorList = new List<int>();
            int k = 1;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {

                    Label label = new Label();
                    label.Location = new Point(startPositionX + j * (int)SmallCubeSize + 3, startPositionY + i * (int)SmallCubeSize + 3);
                    if (k < 10)
                    {
                        label.Name = string.Format("label0{0}", k);
                    }
                    else
                    {
                        label.Name = string.Format("label{0}", k);
                    }
                    label.BackColor = Color.Tan;
                    label.Font = new Font("Papyrus", 16F, (FontStyle.Bold), GraphicsUnit.Point, ((byte)(0)));
                    label.Size = new Size((int)SmallCubeSize-5, (int)SmallCubeSize-5);
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    labels.Add(label);
                    k++;
                }
            }

            for (int i = 0; i < 81; i++)
            {
                labels[i].Click += new EventHandler(Game_Click);
                this.Controls.Add(labels[i]);
            }

            pen = new Pen(Color.Brown, 3);

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
            k = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {

                    if (mset[i, j] != 0)
                    {
                        labels[k].Text = Convert.ToString(mset[i, j]);
                        firstGenerated.Add(k);
                    }
                    k++;
                }

            }
        }
                              
        void textBox1_TextChanged(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(textBox1.Name.Substring(textBox1.Name.Length - 2));
            if (textBox1.TextLength != 0)
            {
                int n;
                bool isNumeric = int.TryParse(textBox1.Text, out n);
                if (isNumeric)
                {
                    if (Convert.ToInt32(textBox1.Text) < 10 && Convert.ToInt32(textBox1.Text) > 0)
                    {
                        if (labels[i - 1].Text != textBox1.Text)
                        {

                            bool isNum = int.TryParse(textBox1.Text, out n);
                            if (isNum)
                            {
                                labels[i - 1].Text = textBox1.Text.Substring(0, 1);
                                if (!isValid((i - 1) / 9, (i - 1) % 9, labels[i - 1].Text))
                                {
                                    errorList.Add(i);
                                    labels[i - 1].ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    if (errorList.Contains(i))
                                    {
                                        errorList.Remove(i);
                                    }
                                    labels[i - 1].ForeColor = System.Drawing.Color.Black;
                                }
                                labels[i - 1].Visible = true;
                                textBox1.Visible = false;
                                foreach (int q in errorList)
                                {
                                    if (isValid((q - 1) / 9, (q - 1) % 9, labels[q - 1].Text))
                                    {
                                        errorList.Remove(1);
                                        labels[q - 1].ForeColor = System.Drawing.Color.Black;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                labels[i - 1].Text = "";
                if (errorList.Contains(i))
                {
                    errorList.Remove(i);
                    labels[i - 1].ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        private void DrawGrid(Graphics paint)
        {
            paint.DrawLine(pen, startPositionX, startPositionY, startPositionX + gridWidth, startPositionY);
            paint.DrawLine(pen, startPositionX, startPositionY, startPositionX, startPositionY + gridWidth);
            paint.DrawLine(pen, startPositionX, startPositionY + gridWidth, startPositionX + gridWidth, startPositionY + gridWidth);
            paint.DrawLine(pen, startPositionX + gridWidth, startPositionY, startPositionX + gridWidth, startPositionY + gridWidth);

            Pen penMiddle = new Pen(Color.Brown, 4);

            paint.DrawLine(penMiddle, startPositionX + CubeSize, startPositionY, startPositionX + CubeSize, startPositionY + gridWidth);
            paint.DrawLine(penMiddle, startPositionX + 2 * CubeSize, startPositionY, startPositionX + 2 * CubeSize, startPositionY + gridWidth);
            paint.DrawLine(penMiddle, startPositionX, startPositionY + CubeSize, startPositionX + gridWidth, startPositionY + CubeSize);
            paint.DrawLine(penMiddle, startPositionX, startPositionY + 2 * CubeSize, startPositionX + gridWidth, startPositionY + 2 * CubeSize);

            Pen penThin = new Pen(Color.Brown,2);

            for (int i = 1; i < 10; i++)
            {
                paint.DrawLine(penThin, startPositionX + i * SmallCubeSize, startPositionY, startPositionX + i * SmallCubeSize, startPositionY + gridWidth);
            }

            for (int i = 1; i < 10; i++)
            {
                paint.DrawLine(penThin, startPositionX, startPositionY + i * SmallCubeSize, startPositionX + gridWidth, startPositionY + i * SmallCubeSize);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Game_Load(object sender, EventArgs e)
        {

        }
        bool isValid(int i, int j, string el) //
        {

            for (int k = 0; k < 9; k++)
            {
                if (k == j) continue;
                if(labels[i*9+k].Text==el)

                {
                    
                    return false;
                }
            }

            for (int k = 0; k < 9; k++)
            {
                if (k == i) continue;
                if (labels[k * 9 + j].Text==el)

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
                    if (k == i) continue;
                    if (m == i) continue;
                    if (labels[k * 9 + m].Text==el)

                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            DrawGrid(e.Graphics);
        }

        private void Game_Click(object sender, EventArgs e)
        {
            
            Label l = sender as Label;
            if (l != null)
            {
                int i = Convert.ToInt32(l.Name.Substring(l.Name.Length - 2));                
                if (!firstGenerated.Contains(i - 1))
                {                    
                    textBox1.Location = labels[i - 1].Location;
                    textBox1.Size = new Size(labels[i - 1].Size.Width,labels[i-1].Size.Height);
                    textBox1.Name = labels[i - 1].Name;
                    textBox1.BackColor = Color.Tan;
                    textBox1.Visible = true;
                    textBox1.Text = labels[i - 1].Text;
                    textBox1.Select();
                    textBox1.SelectionStart = 0;
                    textBox1.SelectionLength = textBox1.TextLength;
                }
                
            }
                       
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            time++;
            lblTime.Text = string.Format("{0:00}:{1:00}", time / 60, time % 60);
        }

        private void Game_Click_1(object sender, EventArgs e)
        {
            if (textBox1.ContainsFocus)
            {

                textBox1.Visible = false;
            }
        }
    }
}
