﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4
{
    public partial class Form1 : Form
    {
        public string player1Color_Red = "Red";
        public string player2Color_Yellow = "Yellow";
        public string player1Name = "Mikael";
        public string player2Name = "Jon";
        public const int moduluscheck = 2;
        public int rounds = 0;
        public Slot[,] board;
        public const int boardXWidth = 7;
        public const int boardYHeight = 6;

        public Form1()
        {
            InitializeComponent();
            //CheckForPreviousClick();

            board = new Slot[boardXWidth, boardYHeight]; // X, Y

            for (int y = 0; y < boardYHeight; y++) // Går igenom alla rader (Y), uppifrån och ner...
            {
                for (int x = 0; x < boardXWidth; x++) // GÅr igenom alla celler i raedrna (X), från höger till vänster...
                {
                    Slot slot = new Slot("Empty");
                    board[x, y] = slot;
                }
            }
            MessageBox.Show("Spelare1 (Röd) börjar!");
        }


        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            string tmpName = p.Name.ToString();
            string[] tmpNameArray = tmpName.Split('x');
            int xCoordinate = Convert.ToInt32(tmpNameArray[1]);
            int yCoordinate = Convert.ToInt32(tmpNameArray[2]);

            if (CheckIfSomethingBelow(xCoordinate, yCoordinate) == true)
            {
                ChangeColor(p, xCoordinate, yCoordinate);

                if (CheckIfSomeOneWon() == true)
                {
                    if (board[xCoordinate, yCoordinate].color == "Red")
                    {
                        MessageBox.Show("Spelare1 (Röd) har vunnit!");
                    }
                    if (board[xCoordinate, yCoordinate].color == "Yellow")
                    {
                        MessageBox.Show("Spelare2 (Gul) har vunnit!");
                    }
                }
                if (GameTie() == true)
                {
                    MessageBox.Show("Det blev oavgjort!");
                }
            }

            
        }

        private bool GameTie()
        {
            bool gameTie = false;
            int numberOfSlots = boardXWidth * boardYHeight;
            int fullSlots = 0;

            for (int x = 0; x < boardXWidth; x++)
            {
                for (int y = 0; y < boardYHeight; y++)
                {
                    if (board[x,y].color != "Empty")
                    { fullSlots++; }
                }
            }

            if (numberOfSlots == fullSlots)
            { gameTie = true; }

            return gameTie;
        }

        private bool CheckIfSomeOneWon()
        {
            bool someOneWon = false;

            #region Kollar alla RADER
            for (int y = 0; y < boardYHeight; y++)
            {
                for (int x = 0; x < (boardXWidth - 3); x++)
                {
                    if (board[x, y].color == board[(x + 1), y].color && board[x, y].color == board[(x + 2), y].color && board[x, y].color == board[(x + 3), y].color && board[x, y].color != "Empty")
                    {
                        someOneWon = true;
                    }
                }
            }
            #endregion

            #region Kollar alla KOLUMNER
            for (int x = 0; x < boardXWidth; x++)
            {
                for (int y = 0; y < (boardYHeight - 3); y++)
                {
                    if (board[x, y].color == board[x, (y + 1)].color && board[x, y].color == board[x, (y+2)].color && board[x, y].color == board[x,(y+3)].color && board[x, y].color != "Empty")
                    {
                        someOneWon = true;
                    }
                }
            }
            #endregion

            #region Kollar Diagonaler åt Höger
            for (int x = 0; x < (boardXWidth -3); x++)
            {
                for (int y = 0; y < (boardYHeight - 3); y++)
                {
                    if (board[x, y].color == board[(x + 1), (y + 1)].color && board[x, y].color == board[(x + 2), (y + 2)].color && board[x, y].color == board[(x + 3), (y + 3)].color && board[x, y].color != "Empty")
                    {
                        someOneWon = true;
                    }
                }
            }
            #endregion

            #region Kollar Diagonaler åt Vänster
            for (int x = 6; x > 2; x--) // HÅRDKODAT!
            {
                for (int y = 0; y < (boardYHeight - 3); y++)
                {
                    if (board[x, y].color == board[(x - 1), (y + 1)].color && board[x, y].color == board[(x - 2), (y + 2)].color && board[x, y].color == board[(x - 3), (y + 3)].color && board[x, y].color != "Empty")
                    {
                        someOneWon = true;
                    }
                }
            }
            #endregion

            return someOneWon;
        }

        private bool CheckIfSomethingBelow(int xCoordinate, int yCoordinate)
        {
            bool isTrue = false;

            if (board[xCoordinate, yCoordinate].color == "Empty")
            {
                if (yCoordinate == 0)
                {
                    isTrue = true;
                }
                else if (board[xCoordinate, (yCoordinate - 1)].color != "Empty")
                {
                    isTrue = true;
                }
                else
                {
                    MessageBox.Show("Ogiltigt drag, försök igen");
                }
            }
            return isTrue;
        }

        private void ChangeColor(PictureBox thisPictureBox, int xCord, int yCord)
        {
            if (rounds % moduluscheck == 0)
            {
                //// JONS DATOR
                //thisPictureBox.Image = Image.FromFile(@"C:\Users\Administrator\Source\Repos\Connect4\Connect4\Images\Connect4" + player1Color + ".png");

                //MIKAELS DATOR
                thisPictureBox.Image = Image.FromFile(@"C:\Users\Administrator\Documents\visual studio 2015\Projects\Connect4\Connect4\Images\Connect4" + player1Color_Red + ".png");
                board[xCord, yCord].color = player1Color_Red;
            }
            else
            {
                //// JONS DATOR
                //thisPictureBox.Image = Image.FromFile(@"C:\Users\Administrator\Source\Repos\Connect4\Connect4\Images\Connect4" + player2Color + ".png");

                // MIKAELS DATOR
                thisPictureBox.Image = Image.FromFile(@"C:\Users\Administrator\Documents\visual studio 2015\Projects\Connect4\Connect4\Images\Connect4" + player2Color_Yellow + ".png");
                board[xCord, yCord].color = player2Color_Yellow;
            }
            rounds++;
        }


    }
}
