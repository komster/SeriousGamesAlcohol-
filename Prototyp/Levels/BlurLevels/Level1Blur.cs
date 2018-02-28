using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

/*namespace Prototyp
{

    //DELETE
    //public sealed class BlurBitmapEffect
        

    class Level1Blur : Level
    {
        private List<Entity> entitys = new List<Entity>();
        private Entity table1;//rename to avoid bugs
        private Entity table2;//rename to avoid bugs
        private Entity drink1;//rename to avoid bugs
        private float mouseX;
        private float mouseY;

        

        private State state = State.levelGoing;

        private bool drink1PicktUp = false;//rename to avoid bugs

        public override void CreateLevel()
        {

            table1 = new Table(new SolidBrush(Color.Chocolate), 800, 400, 90);
            table2 = new Table(new SolidBrush(Color.Chocolate),100, 400, 90 );
            drink1 = new Drink(new SolidBrush(Color.Yellow), 120, 420, 20);
        }

        public override void SetMouseCord(float x, float y)
        {
            mouseX = x;
            mouseY = y;

            if (drink1PicktUp == true)
            {
                drink1.Move(mouseX, mouseY);
            }
        }
        public override State Update()
        {
           //create eventual blur here
           //also cheack if items are on tables and if not drop them on the floor
            return state;
        }

        public override void PickUpDrink()
        {
            RectangleF mouse = new RectangleF(mouseX, mouseY, 1, 1);
            if (mouse.IntersectsWith(drink1.GetRecF()))
            {
                drink1PicktUp = true;
            }
        }
        public override void PlaceDrink()
        {
            if (table1.GetRecF().IntersectsWith(drink1.GetRecF()))
            {
                drink1PicktUp = false;
                //state = State.levelDone;
            }
            else
            {
                drink1PicktUp = false;
                //drink1.resetEntity();
            }
        }

        public override List<Entity> GetEntityList()
        {
            return entitys;
        }

        public override Entity GetDrink()
        {
            return drink1;
        }
        public override Entity GetTable()
        {
            return table1;
        }

        public override Entity GetTable2()
        {
            return table2;
        }
    }
}
*/