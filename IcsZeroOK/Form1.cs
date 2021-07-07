﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IcsZeroOK
{
    public partial class mainForm : System.Windows.Forms.Form
    {
        int currentUser;
        Label[,] board = new Label[3, 3];
        public mainForm()
        {
            InitializeComponent();
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            InitGame();
        }

        private void InitGame()
        {
            if (FirstRun())
                CreateBoard();
            else
                ResetBoard();
            currentUser = 1;
        }

        private bool FirstRun()
        {
            return board[0, 0] == null;
        }

        private void CreateBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    board[i, j] = new Label();

                    this.board[i, j].BackColor = System.Drawing.Color.Lime;
                    this.board[i, j].Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    this.board[i, j].Left = 100 + j * 54;
                    this.board[i, j].Top = 50 + i * 54;
                    this.board[i, j].Size = new System.Drawing.Size(50, 50);
                    this.board[i, j].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                    this.board[i, j].Click += Play;
                    this.board[i, j].MouseEnter += OnMouseEnter;
                    this.board[i, j].MouseLeave += OnMouseLeave;


                    Controls.Add(board[i, j]);

                }
            }

        }

        private void Play(object sender, EventArgs e)
        {
            if (((Label)sender).Text == "")
                if (currentUser == 1)
                {
                    ((Label)sender).Text = "0";
                    currentUser = 2;
                }
                else
                {
                    ((Label)sender).Text = "1";
                    currentUser = 1;
                }

            int winner = CheckWinner();
            if (winner != 0)
            {
                ShowWinner(winner);
                ResetBoard();
            }
        }

        private void ResetBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    board[i, j].Text = "";

                }
            }
        }
        private void ShowWinner(int winner)
        {
            if (winner == 1) MessageBox.Show("A castigat Toni");
            if (winner == 2) MessageBox.Show("A castigat Gigi");

        }

        private int CheckWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0].Text == board[i, 1].Text &&
                    board[i, 1].Text == board[i, 2].Text && board[i, 0].Text != "")
                        return board[i, 0].Text == "0" ? 1 : 2;
                if (board[0, i].Text == board[1, i].Text &&
                    board[1, i].Text == board[2, i].Text && board[0, i].Text != "")
                        return board[0, i].Text == "0" ? 1 : 2;
            }

            if (board[0, 0].Text == board[1, 1].Text &&
                    board[1, 1].Text == board[2, 2].Text && board[0, 0].Text != "")
                        return board[0, 0].Text == "0" ? 1 : 2;
 
            if (board[2, 0].Text == board[1, 1].Text &&
                    board[1, 1].Text == board[0, 2].Text && board[2, 0].Text != "")
                        return board[2, 0].Text == "0" ? 1 : 2;        
            return 0;
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.Lime;
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.Yellow;
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            Label testLabel = new Label();

            testLabel.Text = "Franzela";
            testLabel.Left = 100;
            testLabel.Top = 20;

            this.Controls.Add(testLabel);
        }
    }
}
