using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santa_Claus_Coming_to_Town
{
    public partial class Form1 : Form
    {
        int gravity = 5;
        int treeSpeed = 6;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Santa.Top += gravity;
            TreeTop.Left -= treeSpeed;
            TreeBottom.Left -= treeSpeed;
            ScoreLabel.Text = $"Score: {score}";
            if (TreeTop.Left < -100)
            {
                TreeTop.Left = 500;
                score++;
            }
            if (TreeBottom.Left < -100)
            {
                TreeBottom.Left = 600;
                score++;
            }
            if (Santa.Bounds.IntersectsWith(TreeTop.Bounds) || Santa.Bounds.IntersectsWith(TreeBottom.Bounds) || Santa.Bounds.IntersectsWith(Ground.Bounds) || Santa.Top < -25)
            {
                GameOver();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }
        private void GameOver()
        {
            timer1.Stop();
            ScoreLabel.Text = $"Game over! {score}p";
            button1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new Form1();
            NewForm.Show();
            this.Dispose(false);
        }
    }
}
