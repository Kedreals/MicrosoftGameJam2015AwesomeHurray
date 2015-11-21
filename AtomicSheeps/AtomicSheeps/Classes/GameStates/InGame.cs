using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtomicSheeps.Core;
using SFML.Graphics;
using AtomicSheeps.Classes.MapFolder;

namespace AtomicSheeps.Classes.GameStates
{
    class InGame : IGameState
    {
        Map Level1;

        public void Draw(RenderWindow window)
        {
            Level1.Draw(window);
        }

        public void Initialize()
        {
        }

        public void LoadContent()
        {
            Level1 = new Map(new System.Drawing.Bitmap("Assets/Bitmap-Levels/Level1.bmp"));
        }

        public EGameStates Update(GameTime time)
        {
            return EGameStates.InGame;
        }
    }
}
