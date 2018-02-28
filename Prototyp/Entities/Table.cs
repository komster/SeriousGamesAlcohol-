using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Prototyp
{
    class Table : Entity
    {
        Random random = new Random();

        private RectangleF recF;

        private Image image;

        public Table(float posX, float posY, float size)
        {
            int value = random.Next(0,3);
            switch(value)
            {
                case 0:
                    image = Properties.Resources.tablecombo1;
                    break;
                case 1:
                    image = Properties.Resources.tablecombo2;
                    break;
                case 2:
                    image = Properties.Resources.tablecombo3;
                    break;
            }
            recF = new RectangleF(posX - (size / 2), posY - (size / 2), size, size);
        }
        public override RectangleF GetRecF()
        {
            return recF;
        }
        public override Image GetImage()
        {
            return image;
        }
    }
}
