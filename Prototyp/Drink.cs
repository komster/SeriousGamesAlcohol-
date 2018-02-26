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
        private SolidBrush brush;

        private float sizeValue;

        public Drink(SolidBrush solidBrush, float posX, float posY, float size)
        {
            sizeValue = size;
            brush = solidBrush;
            recF = new RectangleF(posX - (size / 2), posY - (size / 2), size, size);
            startRecF = recF;
        }
        public override RectangleF GetRecF()
        {
            return recF;
        }
        public override SolidBrush GetBrush()
        {
            return brush;
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
