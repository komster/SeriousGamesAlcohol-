using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Prototyp.Entities
{
    class CarLvlBackground : Entity
    {

        private SolidBrush brush;

        private Image Img;

        private RectangleF recF;

        private int PosX;
        private int PosY;
        private int SX;
        private int SY;

        public CarLvlBackground(int SizeX, int SizeY)
        {
            //Img = Properties.Resources.Road;

            PosX = SizeX / 2;
            PosY = SizeY / 2;

            recF = new RectangleF(PosX, PosY, SizeX, SizeY);
        }

        public override RectangleF GetRecF()
        {
            return recF;
        }
        public override SolidBrush GetBrush()
        {
            return brush;
        }

        public int getPosX()
        {
            return PosX;
        }

    }
}
