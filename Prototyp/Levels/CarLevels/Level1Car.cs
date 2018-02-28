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
        private HashSet<Entities.CarLvlBackground> CBGSet = new HashSet<Entities.CarLvlBackground>();

        private State state = State.levelGoing;

        private int ScreenWidth;
        private int ScreenHeight;

        public override void CreateLevel(int ScreenW, int ScreenH)
        {
            ScreenWidth = ScreenW;
            ScreenHeight = ScreenH;

            CBGSet.Add(new Entities.CarLvlBackground(ScreenWidth, ScreenHeight));

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
            foreach (Entities.CarLvlBackground BG in CBGSet)
            {
                BG.Move(0.1f, 0.0f);
                if(BG.getPosX() < -0.1f) { CBGSet.Add(new Entities.CarLvlBackground(ScreenWidth, ScreenHeight)); }
                else if(BG.getPosX() > ScreenWidth) { CBGSet.Remove(BG); }
            }
        }
    }
}
