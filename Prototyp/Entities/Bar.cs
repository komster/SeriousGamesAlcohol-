using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Prototyp
{
    class Bar : Entity
    {

        private RectangleF recF;
        private Image image;

        public Bar(float posX, float posY, float sizeX, float sizeY)
        {
            image = Properties.Resources.bardesk;
            recF = new RectangleF(posX - (sizeX/2),posY - (sizeY/2),sizeX,sizeY);
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
