
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Prototyp
{
    class Level3DrinkWalk : Level
    {
        private List<Entity> entitys = new List<Entity>();
        private Entity table;
        private Entity drink;
        private Entity bar;
        private float mouseX;
        private float mouseY;

        private bool drinkPicktUp = false;
        private State state = State.levelDrinkWalk;

        private int wingle = 0;
        private bool wingleUp = true;
        private int timer = 0;
        private bool blackOutBool = true;
        private int numbersOfDrinks = 2;

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
            mouseX = x;
            mouseY = y;
        }
        public override State Update()
        {
            checkCollision();
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
            if (timer == 0)
            {
                blackOutBool = blackOut();
            }
            timer++;
            if (timer == 20)
            {
                timer = 0;
            }

            if (blackOutBool == true)
            {
                return State.blackOut;
            }
            else
            {
                return state;
            }
        }
        public override int GetNumbersOfDrinks()
        {
            return numbersOfDrinks;
        }
        private bool blackOut()
        {
            Random random = new Random();
            int randomChance = random.Next(0, 10);
            if (randomChance > 1)
            {
                return false;
            }
            else
            {
                return true;
            }
                
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
