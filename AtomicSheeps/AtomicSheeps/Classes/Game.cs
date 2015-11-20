using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtomicSheeps.Core;
using SFML.Graphics;

namespace AtomicSheeps.Classes
{
    class Game : AbstractGame
    {
        static uint WindowSizeX = 1280;
        static uint WindowSizeY = 720;

        EGameStates currentGameState, prevGameState;
        GameState gameState;

        public Game() : base(WindowSizeX, WindowSizeY, "Titel", SFML.Window.Styles.Default)
        {
            prevGameState = EGameStates.None;
            currentGameState = EGameStates.TitelScreen;
        }

        /// <summary>
        /// changes the gameState if the current EGameState is changed
        /// </summary>
        private void HandleGameState()
        {
            //if (currentGameState == EGameStates.None)
            //{
            //    win.Close();
            //    return;
            //}

            //bool StateFound = false;

            //string className = currentGameState.ToString().Split('.').Last();

            //IEnumerable<Type> classes = typeof(Game).Assembly.GetTypes().Where(type => type.GetInterfaces().Contains(typeof(GameState)));

            //foreach (Type t in classes)
            //{
            //    if (t.Name.Equals(className))
            //    {
            //        gameState = (GameState)Activator.CreateInstance(t);
            //        StateFound = true;
            //    }
            //}

            //if (!StateFound)
            //    throw new NotFiniteNumberException();

            //gameState.LoadContent();

            //gameState.Initialize();

            //prevGameState = currentGameState;
        }

        public override void Update(GameTime gameTime)
        {
            MouseControler.Update();
            KeyboardControler.Update();

            if (currentGameState != prevGameState)
            {
                HandleGameState();
            }

            //currentGameState = gameState.Update(gameTime);
        }

        public override void Draw(RenderWindow win)
        {
            //gameState.Draw(win);
        }
    }
}
