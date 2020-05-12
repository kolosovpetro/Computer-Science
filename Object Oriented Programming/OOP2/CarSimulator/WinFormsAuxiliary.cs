using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace CarSimulator
{
    public static class WinFormsAuxiliary
    {
        public static void ChangeLabelText(Label label, string text)
        {
            label.Text = string.Format(text);
            label.Update();
        }

        public static void Animation(PictureBox pb1)
        {
            var interval = 52 - 247;
            var intervalOffset = 247;
            var xCoo = pb1.Location.X;
            xCoo -= intervalOffset;
            var yCoo = pb1.Location.Y;
            var xCooNew = (xCoo + 1) % interval;
            pb1.Location = new Point(xCooNew + intervalOffset, yCoo);
        }
    }
}
