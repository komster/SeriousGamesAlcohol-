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

        private Image Img;

        private RectangleF recF;

        private float PosX;
        private float PosY;
        private float SX;
        private float SY;

        public CarLvlBackground(float SizeX, float SizeY)
        {
            Img = Properties.Resources.Road;

            PosX = 0;
            PosY = 0;
            SX = SizeX;
            SY = SizeY;

            recF = new RectangleF(PosX, PosY, SX, SY);
        }

        public void Update()
        {
            recF.X = PosX;
        }

        public override RectangleF GetRecF()
        {
            return recF;
        }

        public override Image GetImage()
        {
            return Img;
        }

        public void setPosX(float value)
        {
            PosX = PosX + value;
        }

    }
}
