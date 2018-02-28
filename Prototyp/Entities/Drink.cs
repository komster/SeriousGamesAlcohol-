using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Prototyp
{
    class Drink : Entity
    {
        private RectangleF startRecF;
        private RectangleF recF;

        private Image image;

        private float sizeValue;

        public Drink(float posX, float posY, float size)
        {
            sizeValue = size;
            recF = new RectangleF(posX - (size / 2), posY - (size / 2), size, size);
            startRecF = recF;

            image = Properties.Resources.beertopview;
        }
        public override RectangleF GetRecF()
        {
            return recF;
        }
        public override Image GetImage()
        {
            return image;
        }
        public override void Move(float posX, float posY)
        {
            recF.X = posX - (sizeValue / 2);
            recF.Y = posY - (sizeValue / 2);
        }
        public override void resetEntity()
        {
            recF = startRecF;
        }

    }
}
