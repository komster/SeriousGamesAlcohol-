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
        private Entity table;
        private Entity drink;
        private float mouseX;
        private float mouseY;

        private bool drinkPicktUp = false;
        private State state = State.levelDrinkWalk;

        public override void CreateLevel()
        {
            table = new Table(800,600,90);
            drink = new Drink(50, 240, 20);
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

        public void checkCollision()
        {
            for (int index = 0; index < entitys.Count; index++)
            {
                if (drink.GetRecF().IntersectsWith(entitys[index].GetRecF()))
                {
                    drinkPicktUp = false;
                    drink.resetEntity();
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
