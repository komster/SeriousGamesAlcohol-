using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Prototyp.Entities
{
    class EmptyTable : Entity
    {

        private RectangleF recF;
        private Image image;

        public EmptyTable(float posX, float posY, float size)
        {
            image = Properties.Resources.table4;
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
