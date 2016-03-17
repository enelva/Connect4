using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    public class Slot
    {
        public Slot(/*int XBoard, int YBoard, */ string Color)
        {
            //xBoard = XBoard;
            //yBoard = YBoard;
            color = Color;
        }
        //public int xBoard { get; set; }
        //public int yBoard { get; set; }
        public string color { get; set; }



    }
}
