using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototyp
{
    class Level1Car : Level
    {
        private List<Entity> entitys = new List<Entity>();

        private State state = State.levelCar;

        private float ScreenWidth;
        private float ScreenHeight;

        public override void CreateLevel(int ScreenW, int ScreenH)
        {
            ScreenWidth = ScreenW;
            ScreenHeight = ScreenH;

            entitys.Add(new Entities.CarLvlBackground(ScreenWidth, ScreenHeight));
        }

        public override State Update()
        {
            ScrollingBG();
            return state;
        }

        public override List<Entity> GetEntityList()
        {
            return entitys;
        }

        private void ScrollingBG()
        {
            foreach (Entities.CarLvlBackground BG in entitys)
            {
                //BG.setPosX(1f);
                BG.Update();
            }
        }
    }
}
