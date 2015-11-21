using System;
using System.Collections.Generic;
using System.Linq;
using AtomicSheeps.Core;
using SFML.Graphics;

namespace AtomicSheeps.Classes
{
    class Game : AbstractGame
    {
        static uint WindowSizeX = 1280;
        static uint WindowSizeY = 768;

        public static Vec2f WindowSize { get { return new Vec2f(win.Size.X, win.Size.Y); } }

        EGameStates currentGameState, prevGameState;
        IGameState gameState;

        public Game() : base(WindowSizeX, WindowSizeY, "AtomicSheeps", SFML.Window.Styles.Default)
        {
            prevGameState = EGameStates.None;
            currentGameState = EGameStates.TitelScreen;
        }

        /// <summary>
        /// changes the gameState if the current EGameState is changed
        /// </summary>
        private void HandleGameState()
        {
            if (currentGameState == EGameStates.None)
            {
                win.Close();
                return;
            }

            bool StateFound = false;

            string className = currentGameState.ToString().Split('.').Last();

            IEnumerable<Type> classes = typeof(Game).Assembly.GetTypes().Where(type => type.GetInterfaces().Contains(typeof(IGameState)));

            foreach (Type t in classes)
            {
                if (t.Name.Equals(className))
                {
                    gameState = (IGameState)Activator.CreateInstance(t);
                    StateFound = true;
                }
            }

            if (!StateFound)
                throw new NotFiniteNumberException();

            gameState.LoadContent();

            gameState.Initialize();

            prevGameState = currentGameState;
        }

        public override void Update(GameTime gameTime)
        {
            MouseControler.Update();
            KeyboardControler.Update();

            if (currentGameState != prevGameState)
            {
                HandleGameState();
            }

            currentGameState = gameState.Update(gameTime);
        }

        public override void Draw(RenderWindow win)
        {
            gameState.Draw(win);
        }
    }
}
