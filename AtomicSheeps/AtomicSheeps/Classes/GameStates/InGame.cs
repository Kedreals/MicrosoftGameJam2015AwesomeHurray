using AtomicSheeps.Core;
using SFML.Graphics;
using AtomicSheeps.Classes.MapFolder;
using SFML.Audio;
using AtomicSheeps.Classes.GameObjects.Enemies;
using System;
using AtomicSheeps.Classes.GameObjects.Tower;
using AtomicSheeps.Classes.GameObjects.ProjectileFolder;
using System.Collections.Generic;

namespace AtomicSheeps.Classes.GameStates
{
    class InGame : IGameState
    {
        public static float Money = 20;
        Text MoneyTxt;
        public static Map Level { get; private set; }
        Sound BackgroundMusic;
        Sprite Store;
        Sprite Infobox;
        List<AbstractTower> TowersList { get; set; }
        AbstractTower testTower;
        AbstractTower schafGroßTower;
        AbstractTower LastTower;
        public static int ExistingGameObjects = 0;

        Font font;
        Text txt;

        public void Draw(RenderWindow window)
        {
            Level.Draw(window);

            window.Draw(Infobox);
            window.Draw(txt);
            window.Draw(MoneyTxt);

            for (int i = 0; i < 25; ++i)
            {
                Store.Position = new Vec2f(128 + i % 18 * 64, (Game.WindowSize.Y - 192) + (i < 18 ? 0 : 1) * 64);
                window.Draw(Store);
            }

            EnemyHandler.Draw(window);
            TowerHandler.Draw(window);
            ProjectileHandler.Draw(window);
        }

        public void OnButtonPress(object sender, MouseButtonEventArgs e)
        {

            if (MouseControler.MouseIn(testTower.sprite) && Money >= testTower.Costs)
            {
                new TestTower();
                TowerHandler.Towers[TowerHandler.Towers.Count - 1].Selected = true;
                Money -= testTower.Costs;
            }

            if (MouseControler.MouseIn(schafGroßTower.sprite) && Money >= schafGroßTower.Costs)
            {
                new SchafGroßTower();
                TowerHandler.Towers[TowerHandler.Towers.Count - 1].Selected = true;
                Money -= schafGroßTower.Costs;
            }
        }
        public void OnButtonRelease(object sender, MouseButtonEventArgs e)
        {
            if (TowerHandler.Towers.Count > 2)
            {
                LastTower.Selected = false;
                LastTower.Activated = true;

                try
                {
                    LastTower.sprite.Position = Level.GetValidPosition(LastTower.Position + new Vec2f((LastTower.sprite.Texture.Size.X * LastTower.sprite.Scale.X) / 2,
                        (LastTower.sprite.Texture.Size.Y * LastTower.sprite.Scale.Y) / 2));
                }
                catch (PathException)
                {
                    Money += LastTower.Costs;
                    LastTower.IsAlive = false;
                }
            }
        }

        public void Initialize()
        {
            MouseControler.ButtonPressed += OnButtonPress;
            MouseControler.ButtonReleased += OnButtonRelease;

            EnemyHandler.Initialize();
            TowerHandler.Initialize();
            ProjectileHandler.Initialize();

            TowersList = new List<AbstractTower>();
            testTower = new TestTower();
            schafGroßTower = new SchafGroßTower();
            TowersList.Add(testTower);
            TowersList.Add(schafGroßTower);
        }

        public void DisplayTowerStats()
        {

            foreach (AbstractTower t in TowersList)
            {
                if (MouseControler.MouseIn(t.sprite))
                {
                    txt.DisplayedString = "Damage: " + t.Damage.ToString() + "\n" + "Range: " + t.Range.ToString() + "\n" + "Costs: " + t.Costs.ToString();
                }
            }
        }

        public void LoadContent()
        {
            Level = new Map(new System.Drawing.Bitmap("Assets/Bitmap-Levels/Level1.bmp"));
            Store = new Sprite(new Texture("Assets/Textures/Raster.png"));
            Infobox = new Sprite(new Texture("Assets/Textures/Infotafel.png"));
            Infobox.Position = new Vec2f(0, Game.WindowSize.Y - 192);

            font = new Font("Assets/Fonts/data-latin.ttf");

            txt = new Text("", font, 20);
            txt.Position = new Vec2f(Infobox.Position.X + 10, Infobox.Position.Y + 40);

            MoneyTxt = new Text("", font, 20);
            MoneyTxt.Position = new Vec2f(Infobox.Position.X + 10, Infobox.Position.Y + 10);

            BackgroundMusic = new Sound(new SoundBuffer("Assets/Sounds/Farm-SoundBible.com-1720780826.wav"));
            BackgroundMusic.Loop = true;
            BackgroundMusic.Volume = 100;
            BackgroundMusic.Play();
        }

        public EGameStates Update(GameTime time)
        {
            Console.WriteLine("Existing GameObject Count: " + ExistingGameObjects);

            try
            {
                EnemyHandler.Update(time);
                TowerHandler.Update(time);
                ProjectileHandler.Update(time);

                if (TowerHandler.Towers.Count > 2)
                {
                    LastTower = TowerHandler.Towers[TowerHandler.Towers.Count - 1];
                }

                DisplayTowerStats();

                MoneyTxt.DisplayedString = "Money: " + Money;
            }
            catch (ArgumentOutOfRangeException)
            {
                return EGameStates.GameOver;
            }

            return EGameStates.InGame;
        }
    }
}
