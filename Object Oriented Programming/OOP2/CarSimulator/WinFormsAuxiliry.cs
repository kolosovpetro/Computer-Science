using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace CarSimulator
{
    public class WinFormsAuxiliry
    {
        public static void ChangeLabelText(Label label, string text)
        {
            label.Text = string.Format(text);
            label.Update();
        }

        public static void Animation(PictureBox pb1)
        {
            int interval, intervalOffset, xCoo, yCoo, xCooNew;
            interval = 52 - 247;                              //Max min location picture
            intervalOffset = 247;                              //Starting Point of PictureBox
            xCoo = pb1.Location.X;           //get xCoordinate of PictureBox
            xCoo -= intervalOffset;                            //Substract Offset in order to calculate next Point
            yCoo = pb1.Location.Y;           //get yCoordinate of PictureBox
            xCooNew = (xCoo + 1) % interval;               //calculate new xCoordinate of PictureBox
            pb1.Location = new Point(xCooNew + intervalOffset, yCoo);
        }
    }
}
