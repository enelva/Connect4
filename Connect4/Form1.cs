using System;
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
        public string player1Color = "Red";
        public string player2Color = "Yellow";
        public string player1Name = "Mikael";
        public string player2Name = "Jon";
        public const int moduluscheck = 2;
        public int rounds = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ChangeColor(this.pictureBox1, player1Color);
        }

        private void ChangeColor(PictureBox thisPictureBox, string color)
        {
            if (rounds % moduluscheck == 0)
            {
                thisPictureBox.Image = Image.FromFile(@"C:\Users\Administrator\Documents\visual studio 2015\Projects\Connect4\Connect4\Images\Connect4" + player1Color + ".png");
            }
            else
            {
                thisPictureBox.Image = Image.FromFile(@"C:\Users\Administrator\Documents\visual studio 2015\Projects\Connect4\Connect4\Images\Connect4" + player2Color + ".png");
            }
            rounds++;
        }
    }
}
