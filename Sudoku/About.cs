﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class About : Form
    {
        public Form parent;
        public About(Form p)
        {
            InitializeComponent();
            parent = p;
            /*den.ForeColor = Color.Black;
            dva.ForeColor = Color.Black;
            tri.ForeColor = Color.Black;
            cetiri.ForeColor = Color.Black;*/
            
        }

        private void About_Leave(object sender, EventArgs e)
        {
            parent.Show();
        }

        private void About_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }

        private void About_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
