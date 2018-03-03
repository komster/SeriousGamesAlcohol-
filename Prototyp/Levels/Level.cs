using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Prototyp
{
    class Level
    {
        public virtual void CreateLevel()
        {

        }

        public virtual void CreateLevel(int X, int Y)
        {

        }

        public virtual State Update()
        {
            return State.levelDone;
        }
        public virtual int GetNumbersOfDrinks()
        {
            return 0;
        }
        public virtual List<Entity> GetEntityList()
        {
            return null;
        }
        public virtual Entity GetTable()
        {
            return null;
        }
        public virtual Entity GetDrink()
        {
            return null;
        }
        public virtual Entity GetBar()
        {
            return null;
        }
        public virtual List<RectangleF> getHitBoxes()
        {
            return null;
        }
        public virtual void SetMouseCord(float x, float y)
        {

        }
        public virtual void PickUpDrink()
        {

        }
        public virtual void PlaceDrink()
        {

        }
    }
}
