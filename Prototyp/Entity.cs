using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Prototyp
{

    class Entity
    {
        public virtual RectangleF GetRecF()
        {
            return new RectangleF(1,1,1,1);
        }
        public virtual SolidBrush GetBrush()
        {
            return null;
        }
        public virtual void Move(float posX, float posY)
        {

        }
        public virtual void resetEntity()
        {

        }
    }
}

