using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Prototyp
{
    class Level2DrinkWalk : Level
    {


        private List<Entity> entitys = new List<Entity>();
        private Entity table;
        private Entity drink;
        private float mouseX;
        private float mouseY;

        private bool drinkPicktUp = false;
        private State state = State.levelGoing;

        private int wingle = 0;
        private bool wingleUp = true;

        public override void CreateLevel()
        {
            CreateTableWithPeople(500, 100, 50);
            CreateTableWithPeople(330, 80, 50);
            CreateTableWithPeople(180, 90, 50);
            CreateTableWithPeople(330, 350, 50);
            CreateTableWithPeople(130, 380, 50);
            CreateTableWithPeople(480, 450, 50);
            CreateTableWithPeople(630, 480, 50);
            CreateTableWithPeople(620, 240, 50);
            CreateTableWithPeople(790, 250, 50);
            CreateTableWithPeople(890, 390, 50);
            table = new Table(new SolidBrush(Color.Chocolate), 800, 600, 90);
            drink = new Drink(new SolidBrush(Color.Yellow), 50, 240, 20);
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
        public void CreateTableWithPeople(float posX, float posY, float size)
        {
            entitys.Add(new Table(new SolidBrush(Color.BurlyWood), posX, posY, size));
            entitys.Add(new Person(new SolidBrush(Color.Black), posX + size, posY, size / 2));
            entitys.Add(new Person(new SolidBrush(Color.Black), posX - size, posY, size / 2));
            entitys.Add(new Person(new SolidBrush(Color.Black), posX, posY + size, size / 2));
            entitys.Add(new Person(new SolidBrush(Color.Black), posX, posY - size, size / 2));
        }
    }
}
