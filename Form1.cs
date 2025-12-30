using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_Project.Properties;

namespace Tic_Tac_Toe_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        enPlayer CurrentPlayer = enPlayer.Player1;
        stStatusGame StatusGame;
        enum enPlayer
        {
            Player1,
            Player2
        }

        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            GameInProgress   
        }

        struct stStatusGame
        {
            public enWinner Winner;
            public bool GameOver;
            public short GameCount;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.FromArgb(255, 255, 255, 255);
            Pen Pen = new Pen(White);
            Pen.Width = 10;

            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(Pen, 950, 100, 950, 600);
            e.Graphics.DrawLine(Pen, 700, 100, 700, 600);
            e.Graphics.DrawLine(Pen, 450, 100, 450, 600);

            e.Graphics.DrawLine(Pen, 450, 250, 1190, 250);
            e.Graphics.DrawLine(Pen, 450, 400, 1190, 400);

        }

        public bool CheckValue(PictureBox pcBox1, PictureBox pcBox2, PictureBox pcBox3)
        {
            if(pcBox1.Tag.ToString() != "?" && pcBox1.Tag.ToString() == pcBox2.Tag.ToString() && pcBox2.Tag.ToString() == pcBox3.Tag.ToString())
            {
                pcBox1.BackColor = Color.GreenYellow;
                pcBox2.BackColor = Color.GreenYellow;
                pcBox3.BackColor = Color.GreenYellow;

                if(pcBox1.Tag.ToString() == "X")
                {
                    StatusGame.Winner = enWinner.Player1;
                    StatusGame.GameOver = true;
                    EndGame();
                    return true;

                } else
                {
                    StatusGame.Winner = enWinner.Player2;
                    StatusGame.GameOver = true;
                    EndGame();
                    return true;
                }
            }

            StatusGame.GameOver = false;
            return false;
        }

        void EndGame()
        {
            lblInProgress.Text = "Game Over";
            switch(StatusGame.Winner)
            {
                case enWinner.Player1:

                    lblInProgress.Text = "Player 1";
                    break;

                case enWinner.Player2:

                    lblInProgress.Text = "Player 2";
                    break;

                default:

                    lblInProgress.Text = "Draw";
                    break;
            }

            MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CheckWinner()
        {
            if (CheckValue(pcBox1, pcBox2, pcBox3))
                return;

            if (CheckValue(pcBox4, pcBox5, pcBox6))
                return;

            if (CheckValue(pcBox7, pcBox8, pcBox9))
                return;

            if (CheckValue(pcBox1, pcBox4, pcBox7))
                return;

            if (CheckValue(pcBox2, pcBox5, pcBox8))
                return;

            if (CheckValue(pcBox3, pcBox6, pcBox9))
                return;

            if (CheckValue(pcBox1, pcBox5, pcBox9))
                return;

            if (CheckValue(pcBox3, pcBox5, pcBox7))
                return;
        }
        public void ChangeImage(PictureBox pcBox)
        {
            if(pcBox.Tag.ToString() == "?")
            {
                switch(CurrentPlayer)
                {
                    case enPlayer.Player1:

                        pcBox.Image = Resources.X;
                        CurrentPlayer = enPlayer.Player2;
                        lblPlayer.Text = "Player 2";
                        StatusGame.GameCount++;
                        pcBox.Tag = "X";
                        CheckWinner();
                        break;

                    case enPlayer.Player2:

                        pcBox.Image = Resources.O;
                        CurrentPlayer = enPlayer.Player1;
                        lblPlayer.Text = "Player 1";
                        StatusGame.GameCount++;
                        pcBox.Tag = "O";
                        CheckWinner();
                        break;                   
                }
            }
            else
            {
                MessageBox.Show("Wrong Choice", "Wrong Choice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if(StatusGame.GameCount == 9)
            {
                StatusGame.GameOver = true;
                StatusGame.Winner = enWinner.Draw;
                EndGame();
            }
        }

        void ResetCheckBox(PictureBox pcBox)
        {
            pcBox.Image = Resources.question_mark_96;
            pcBox.Tag = "?";
            pcBox.BackColor = Color.Transparent;

        }
        void RestartGame()
        {
            ResetCheckBox(pcBox1);
            ResetCheckBox(pcBox2);
            ResetCheckBox(pcBox3);
            ResetCheckBox(pcBox4);
            ResetCheckBox(pcBox5);
            ResetCheckBox(pcBox6);
            ResetCheckBox(pcBox7);
            ResetCheckBox(pcBox8);
            ResetCheckBox(pcBox9);

            CurrentPlayer = enPlayer.Player1;
            lblPlayer.Text = "Player 1";
            StatusGame.Winner = enWinner.GameInProgress;
            StatusGame.GameCount = 0;
            StatusGame.GameOver = false;
            lblInProgress.Text = "In Progress";


        }
        private void pcBox1_Click(object sender, EventArgs e)
        {
            ChangeImage(pcBox1);
        }

        private void pcBox2_Click(object sender, EventArgs e)
        {
            ChangeImage(pcBox2);

        }

        private void pcBox3_Click(object sender, EventArgs e)
        {
            ChangeImage(pcBox3);

        }

        private void pcBox4_Click(object sender, EventArgs e)
        {
            ChangeImage(pcBox4);

        }

        private void pcBox5_Click(object sender, EventArgs e)
        {
            ChangeImage(pcBox5);

        }

        private void pcBox6_Click(object sender, EventArgs e)
        {
            ChangeImage(pcBox6);

        }

        private void pcBox7_Click(object sender, EventArgs e)
        {
            ChangeImage(pcBox7);

        }

        private void pcBox8_Click(object sender, EventArgs e)
        {
            ChangeImage(pcBox8);

        }

        private void pcBox9_Click(object sender, EventArgs e)
        {
            ChangeImage(pcBox9);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}
