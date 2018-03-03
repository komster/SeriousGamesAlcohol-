using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Prototyp
{
    class Level1DrinkWalk : Level
    {
        private List<Entity> entitys = new List<Entity>();
        private List<RectangleF> hitBoxes = new List<RectangleF>();
        private Entity table;
        private Entity drink;
        private Entity bar;
        private float mouseX;
        private float mouseY;

        private bool drinkPicktUp = false;
        private State state = State.levelDrinkWalk;
        private int numbersOfDrinks = 0;

        public override void CreateLevel()
        {
            entitys = Entities.DrinkWalkMap.createEntitys();
            bar = Entities.DrinkWalkMap.createBar();
            table = Entities.DrinkWalkMap.createTable();
            drink = Entities.DrinkWalkMap.createDrink();
            for (int index = 0; index < entitys.Count; index++)
            {
                hitBoxes.AddRange(entitys[index].GetHitBoxes());
            }
        }
        public override void SetMouseCord(float x, float y)
        {
            mouseX = x;
            mouseY = y;

            if (drinkPicktUp == true)
            {
                drink.Move(mouseX,mouseY);
            }
        }
        public override State Update()
        {
            checkCollision();
            return state;
        }
        public override int GetNumbersOfDrinks()
        {
            return numbersOfDrinks;
        }
        public void checkCollision()
        {
            for (int index = 0; index < entitys.Count; index++)
            {
                if (drink != null && entitys.Count != 0)
                {
                    if (drink.GetRecF().IntersectsWith(entitys[index].GetRecF()))
                    {
                        drinkPicktUp = false;
                        drink.resetEntity();
                    }
                }

            }

        }

        public override void PickUpDrink()
        {
            RectangleF mouse = new RectangleF(mouseX,mouseY,1,1);
            if (mouse.IntersectsWith(drink.GetRecF()))
            {
                drinkPicktUp = true;
            }
        }
        public override void PlaceDrink()
        {
            if (table.GetRecF().IntersectsWith(drink.GetRecF()))
            {
                drinkPicktUp = false;
                state = State.levelDone;
            }
            else
            {
                drinkPicktUp = false;
                drink.resetEntity();
            }
        }

        public override Entity GetBar()
        {
            return bar;
        }
        public override List<Entity> GetEntityList()
        {
            return entitys;
        }

        public override Entity GetDrink()
        {
            return drink;
        }
        public override Entity GetTable()
        {
            return table;
        }
    }
}
