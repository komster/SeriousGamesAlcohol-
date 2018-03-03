using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Prototyp.Levels.DrinkWalk
{
    class LevelDebugDrinkWalk : Level
    {
        private List<Entity> entitys = new List<Entity>();
        private List<RectangleF> hitBoxes = new List<RectangleF>();
        private State state = State.debugDrinkWalk;

        public override void CreateLevel()
        {
            entitys.Add(new TableWithPersons(300, 150, 200,0));
            entitys.Add(new TableWithPersons(700, 150, 200, 1));
            entitys.Add(new TableWithPersons(300, 500, 200, 2));
            entitys.Add(new Entities.EmptyTable(700, 500, 200));
            for (int index = 0; index < entitys.Count; index++)
            {
                hitBoxes.AddRange(entitys[index].GetHitBoxes());
            }
        }
        public override State Update()
        {
            return state;
        }

        public override List<Entity> GetEntityList()
        {
            return entitys;
        }
        public override List<RectangleF> getHitBoxes()
        {
            return hitBoxes;
        }

    }
}
