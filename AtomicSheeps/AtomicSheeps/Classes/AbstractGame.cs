using SFML.Graphics;
using AtomicSheeps.Core;

namespace AtomicSheeps.Classes
{
    abstract class AbstractGame
    {
        protected static RenderWindow win;
        protected static GameTime gameTime;

        /// <summary>
        /// creates a game
        /// </summary>
        /// <param name="width">width of the window</param>
        /// <param name="height">height of the window</param>
        /// <param name="title">titel of the window</param>
        /// <param name="screen">style of the window</param>
        public AbstractGame(uint width, uint height, string title, SFML.Window.Styles screen)
        {
            win = new RenderWindow(new SFML.Window.VideoMode(width, height), title, screen);

            win.Closed += (sender, e) => { ((RenderWindow)sender).Close(); };

            gameTime = new GameTime();
            MouseControler.Initialize(win);
            KeyboardControler.Initialize();
        }

        /// <summary>
        /// Draws everything, checks logic calls all updates, overall let the game run
        /// </summary>
        public void Run()
        {
            gameTime.Start();

            while (win.IsOpen())
            {
                win.Clear(new Color(101, 156, 239)); //CornFlowerBlue
                win.DispatchEvents();
                gameTime.Update();
                Update(gameTime);
                Draw(win);
                win.Display();
            }
        }

        public abstract void Draw(RenderWindow win);

        public abstract void Update(GameTime gameTime);
    }
}
