using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototyp
{


    public partial class Form1 : Form
    {
        Bitmap drawImage;
        Graphics formGraphics;
        State state = State.levelGoing;
        List<Level> levelList = new List<Level>();
        int levelIndex = 3;
        Level level;

        public Form1()
        {
            InitializeComponent();
            
            levelList.Add(new Level1DrinkWalk());
            levelList.Add(new Level2DrinkWalk());
            levelList.Add(new Level3DrinkWalk());
            levelList.Add(new Level1Car());
            NextLevel();
            button1.Hide();
        }

        public void NextLevel()
        {
            if (levelIndex < levelList.Count)
            {
                level = levelList[levelIndex];
                level.CreateLevel();
                timer1.Start();
            }
            else
            {
                state = State.dead;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            drawImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = drawImage;
            formGraphics = Graphics.FromImage(drawImage);

            if (state == State.levelDone)
            {
                formGraphics.DrawImage(Properties.Resources.drinking,new RectangleF(0,0,pictureBox1.Width,pictureBox1.Height));
            }
            if (state == State.dead)
            {
                formGraphics.DrawImage(Properties.Resources.Dead, new RectangleF(0, 0, pictureBox1.Width, pictureBox1.Height));
            }
            if (state == State.blackOut)
            {
                formGraphics.Clear(Color.Black);
            }
            if (state == State.levelGoing)
            {
                List<Entity> entitys = level.GetEntityList();
                for (int index = 0; index < entitys.Count; index++)
                {
                    formGraphics.DrawImage(entitys[index].getImage(), entitys[index].GetRecF());
                }
                Entity table = level.GetTable();
                formGraphics.FillRectangle(table.GetBrush(), table.GetRecF());
                Entity drink = level.GetDrink();
                formGraphics.FillRectangle(drink.GetBrush(), drink.GetRecF());
            }

            base.OnPaint(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            state = level.Update();

            if ( state == State.levelDone)
            {
                button1.Show();
                timer1.Stop();
            }
            Refresh();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            level.PickUpDrink();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            level.SetMouseCord(e.X,e.Y);
            Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            level.PlaceDrink();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            levelIndex++;
            button1.Hide();
            NextLevel();
        }
    }
}
