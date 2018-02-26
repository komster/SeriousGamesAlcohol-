using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototyp
{
    class Level
    {
        public virtual void CreateLevel()
        {

        }

        public virtual State Update()
        {
            return State.levelGoing;
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
