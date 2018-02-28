using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Prototyp
{
    class Person : Entity
    {

        private RectangleF recF;
        private SolidBrush brush; 

        public Person(SolidBrush solidBrush,float posX, float posY, float size)
        {
            brush = solidBrush;
            recF = new RectangleF(posX - (size/2),posY - (size/2),size,size);
        }
        public override RectangleF GetRecF()
        {
            return recF;
        }
        public override SolidBrush GetBrush()
        {
            return brush;
        }
    }
}
