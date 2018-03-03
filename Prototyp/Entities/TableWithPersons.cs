using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Prototyp
{
    class TableWithPersons : Entity
    {
        Random random = new Random();

        private RectangleF recF;

        private List<RectangleF> hitBoxes = new List<RectangleF>();

        private Image image;

        public TableWithPersons(float posX, float posY, float size)
        {
            recF = new RectangleF(posX - (size / 2), posY - (size / 2), size, size);
            int value = random.Next(0, 3);

            switch (value)
            {
                case 0:
                    image = Properties.Resources.tablecombo1;
                    createHitBoxes(value);
                    break;
                case 1:
                    image = Properties.Resources.tablecombo2;
                    createHitBoxes(value);
                    break;
                case 2:
                    image = Properties.Resources.tablecombo3;
                    createHitBoxes(value);
                    break;
            }

        }
        public TableWithPersons(float posX, float posY, float size, int pic)
        {
            recF = new RectangleF(posX - (size / 2), posY - (size / 2), size, size);
            switch (pic)
            {
                case 0:
                    image = Properties.Resources.tablecombo1;
                    createHitBoxes(pic);
                    break;
                case 1:
                    image = Properties.Resources.tablecombo2;
                    createHitBoxes(pic);
                    break;
                case 2:
                    image = Properties.Resources.tablecombo3;
                    createHitBoxes(pic);
                    break;
            }

        }
        private void createHitBoxes(int table)
        {
            if (table == 0)
            {
                hitBoxes.Add(new RectangleF(recF.Location,recF.Size));
            }
            if (table == 1)
            {
                hitBoxes.Add(new RectangleF(recF.Location, recF.Size));
            }
            if (table == 2)
            {
                hitBoxes.Add(new RectangleF(recF.Location, recF.Size));
            }
        }
        public override List<RectangleF> GetHitBoxes()
        {
            return hitBoxes;
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
