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
        State state = State.levelDrinkWalk;
        List<Level> levelList = new List<Level>();
        int levelIndex = 0;
        Level level;
        bool firstDraw = true;
        bool showButton = false;
        private System.Timers.Timer updateTimer = null;

        int beerSize = 100;

        public Form1()
        {
            InitializeComponent();
            updateTimer = new System.Timers.Timer();
            this.updateTimer.Interval = Convert.ToDouble(10);
            this.updateTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.UpdateTimer_Tick);
            updateTimer.Enabled = true;
            levelList.Add(new Level1DrinkWalk());
            levelList.Add(new Level2DrinkWalk());
            levelList.Add(new Level3DrinkWalk());
            levelList.Add(new Level1Car());
            NextLevel();
            button1.Visible = false;
            Refresh();
        }
        
        public void NextLevel()
        {
            if (levelIndex < levelList.Count)
            {
                level = levelList[levelIndex];
                level.CreateLevel(pictureBox1.Width, pictureBox1.Height);
                level.CreateLevel();
                updateTimer.Start();
                Refresh();
            }
            else
            {
                state = State.dead;
            }
        }
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            state = level.Update();

            if (state == State.levelDone)
            {
                updateTimer.Stop();
                showButton = true;
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
                firstDraw = true;
                if (showButton == true)
                {
                    button1.Visible = true;
                }
            }
            if (state == State.dead)
            {
                formGraphics.DrawImage(Properties.Resources.Dead, new RectangleF(0, 0, pictureBox1.Width, pictureBox1.Height));
            }
            if (state == State.blackOut)
            {
                formGraphics.Clear(Color.Black);
            }
            if (state == State.levelDrinkWalk)
            {
                if (firstDraw == true)
                {
                    formGraphics.DrawImage(Properties.Resources.floor, 0, 0, pictureBox1.Width, pictureBox1.Height);
                    List<Entity> entitys = level.GetEntityList();
                    for (int index = 0; index < entitys.Count; index++)
                    {
                        formGraphics.DrawImage(entitys[index].GetImage(), entitys[index].GetRecF());
                    }

                    Entity bar = level.GetBar();
                    formGraphics.DrawImage(bar.GetImage(), bar.GetRecF());

                    int numbersOfDrinks = level.GetNumbersOfDrinks();

                    for (int index = 0; index < numbersOfDrinks; index++)
                    {
                        formGraphics.DrawImage(Properties.Resources.beerlifepoints, (index * beerSize)+10, 10, beerSize, 100);
                    }

                    Bitmap screenBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    pictureBox1.DrawToBitmap(screenBitmap, new Rectangle(0, 0, screenBitmap.Width, screenBitmap.Height));

                    pictureBox1.BackgroundImage = screenBitmap;

                    firstDraw = false;
                }

                Entity table = level.GetTable();
                formGraphics.DrawImage(table.GetImage(), table.GetRecF());
                Entity drink = level.GetDrink();
                formGraphics.DrawImage(drink.GetImage(), drink.GetRecF());
            }

            base.OnPaint(e);
        }


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (state == State.levelDrinkWalk)
            {
                level.PickUpDrink();
                Refresh();
            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (state == State.levelDrinkWalk)
            {
                level.SetMouseCord(e.X, e.Y);
                Refresh();
            }

            Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (state == State.levelDrinkWalk)
            {
                level.PlaceDrink();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            showButton = false;
            levelIndex++;
            NextLevel();
        }
    }
}
