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
        private Entity bar;
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
        private int numbersOfDrinks = 1;

        public override void CreateLevel()
        {
            bar = new Bar(940, 520, 150, 230);
            entitys.Add(new TableWithPersons(880, 320, 150));
            entitys.Add(new TableWithPersons(800, 150, 150));
            entitys.Add(new TableWithPersons(600, 100, 150));
            entitys.Add(new TableWithPersons(400, 100, 150));
            entitys.Add(new TableWithPersons(200, 100, 150));
            entitys.Add(new TableWithPersons(100, 300, 150));
            entitys.Add(new TableWithPersons(320, 550, 150));
            entitys.Add(new TableWithPersons(450, 350, 150));
            entitys.Add(new TableWithPersons(580, 550, 150));
            table = new Entities.EmptyTable(100, 550, 150);
            drink = new Drink(900, 480, 20);
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
            //Thread.Sleep(20);
            //if (drinkPicktUp == true)
            //{
            //    if (wingleUp == true)
            //    {
            //        wingle++;
            //        drink.Move(mouseX + (float)wingleDirection.X * wingle, mouseY + (float)wingleDirection.Y * wingle);
            //        if (wingle == 30)
            //        {
            //            wingleUp = false;
            //        }
            //    }
            //    if (wingleUp == false)
            //    {
            //        wingle--;
            //        drink.Move(mouseX + (float)wingleDirection.X * wingle , mouseY + (float)wingleDirection.Y * wingle);
            //        if (wingle == -30)
            //        {
            //            wingleUp = true;
            //        }
            //    }

            //}
            if (drinkPicktUp == true)
            {
                drink.Move(mouseX, mouseY + wingle);
                if (wingleUp == true)
                {
                    wingle++;
                    if (wingle == 30)
                    {
                        wingleUp = false;
                    }
                }
                if (wingleUp == false)
                {
                    wingle--;
                    if (wingle == -30)
                    {
                        wingleUp = true;
                    }
                }

            }
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
