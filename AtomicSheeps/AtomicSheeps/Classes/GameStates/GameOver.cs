using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtomicSheeps.Core;
using SFML.Graphics;

namespace AtomicSheeps.Classes.GameStates
{
    class GameOver : IGameState
    {
        public void Draw(RenderWindow window)
        {
        }

        public void Initialize()
        {
        }

        public void LoadContent()
        {
        }

        public EGameStates Update(GameTime time)
        {
            return EGameStates.GameOver;
        }
    }
}
