using AtomicSheeps.Core;
using SFML.Graphics;
using AtomicSheeps.Classes.MapFolder;
using SFML.Audio;
using AtomicSheeps.Classes.GameObjects.Enemies;
using System;
using AtomicSheeps.Classes.GameObjects.Tower;

namespace AtomicSheeps.Classes.GameStates
{
    class InGame : IGameState
    {
        public static Map Level { get; private set; }
        Sound BackgroundMusic;
        Sprite Store;
        Sprite Infobox;
        Sprite TestTower;

        public void Draw(RenderWindow window)
        {
            Level.Draw(window);

            window.Draw(Infobox);
            for (int i = 0; i < 25; ++i)
            {
                Store.Position = new Vec2f(128 + i % 18 * 64, (Game.WindowSize.Y - 192) + (i<18?0:1) * 64);
                window.Draw(Store);
            }

            window.Draw(TestTower);
            
            EnemyHandler.Draw(window);
            TowerHandler.Draw(window);
        }

        public void Initialize()
        {            
            EnemyHandler.Initialize();
            TowerHandler.Initialize();
            new TestEnemy(Level);
            //new TestTower();
        }

        public void LoadContent()
        {
            Level = new Map(new System.Drawing.Bitmap("Assets/Bitmap-Levels/Level1.bmp"));
            Store = new Sprite(new Texture("Assets/Textures/Raster.png"));
            Infobox = new Sprite(new Texture("Assets/Textures/Infotafel.png"));
            Infobox.Position = new Vec2f(0, Game.WindowSize.Y - 192);

            TestTower = new Sprite(new Texture("Assets/Textures/SchafVerstrahlt.png"));
            TestTower.Position = new Vec2f(128, Game.WindowSize.Y - 192);

            BackgroundMusic = new Sound(new SoundBuffer("Assets/Sounds/Farm-SoundBible.com-1720780826.wav"));
            BackgroundMusic.Loop = true;
            BackgroundMusic.Volume = 100;
            BackgroundMusic.Play();
        }

        public EGameStates Update(GameTime time)
        {
            try
            {
                EnemyHandler.Update(time);
                TowerHandler.Update(time);
            }
            catch (ArgumentOutOfRangeException)
            {
                return EGameStates.GameOver;
            }


            return EGameStates.InGame;
        }
    }
}
