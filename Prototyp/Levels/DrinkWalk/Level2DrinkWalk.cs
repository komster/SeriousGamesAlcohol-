using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Prototyp
{
    class Level2DrinkWalk : Level
    {


        private List<Entity> entitys = new List<Entity>();
        private Entity table;
        private Entity drink;
        private float mouseX;
        private float mouseY;

        private float lastMouseX;
        private float lastMouseY;

        private Vector2 movementDirection;
        private Vector2 wingleDirection;

        private bool drinkPicktUp = false;
        private State state = State.levelDrinkWalk;

        private int wingle = 0;
        private bool wingleUp = true;

        public override void CreateLevel()
        {

            
        }
        public override void SetMouseCord(float x, float y)
        {
            lastMouseX = mouseX;
            lastMouseY = mouseY;

            mouseX = x;
            mouseY = y;

            if (drinkPicktUp == true)
            {
                movementDirection.X = mouseX - lastMouseX;
                movementDirection.Y = mouseY - lastMouseY;

                //wingleDirection = Vector2.rotateVector(movementDirection, (90 * (float)Math.PI / 180));
                wingleDirection = movementDirection;
                //wingleDirection = wingleDirection * 4;
            }

        }
        public override State Update()
        {
            checkCollision();
            Thread.Sleep(20);
            if (drinkPicktUp == true)
            {
                if (wingleUp == true)
                {
                    wingle++;
                    drink.Move(mouseX + (float)wingleDirection.X * wingle, mouseY + (float)wingleDirection.Y * wingle);
                    if (wingle == 30)
                    {
                        wingleUp = false;
                    }
                }
                if (wingleUp == false)
                {
                    wingle--;
                    drink.Move(mouseX + (float)wingleDirection.X * wingle , mouseY + (float)wingleDirection.Y * wingle);
                    if (wingle == -30)
                    {
                        wingleUp = true;
                    }
                }

            }
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
            RectangleF mouse = new RectangleF(mouseX, mouseY, 1, 1);
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
