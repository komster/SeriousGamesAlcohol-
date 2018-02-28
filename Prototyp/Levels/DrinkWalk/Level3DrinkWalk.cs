
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
        private float mouseX;
        private float mouseY;

        private bool drinkPicktUp = false;
        private State state = State.levelDrinkWalk;

        private int wingle = 0;
        private bool wingleUp = true;
        private int timer = 0;
        private bool blackOutBool = true;

        public override void CreateLevel()
        {
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
