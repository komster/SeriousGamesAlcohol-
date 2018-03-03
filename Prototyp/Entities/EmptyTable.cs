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
        private List<RectangleF> hitBoxes = new List<RectangleF>();
        private Image image;

        public EmptyTable(float posX, float posY, float size)
        {
            image = Properties.Resources.table4;
            recF = new RectangleF(posX - (size / 2), posY - (size / 2), size, size);
            createHitBoxes();
        }
        private void createHitBoxes()
        {
            hitBoxes.Add(new RectangleF(recF.Location, recF.Size));
        }
        public override RectangleF GetRecF()
        {
            return recF;
        }
        public override List<RectangleF> GetHitBoxes()
        {
            return hitBoxes;
        }
        public override Image GetImage()
        {
            return image;
        }
    }
}
