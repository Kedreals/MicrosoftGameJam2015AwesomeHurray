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
        Sprite Background;

        public void Draw(RenderWindow window)
        {
            window.Draw(Background);
        }

        public void Initialize()
        {
        }

        public void LoadContent()
        {
            Background = new Sprite(new Texture("Assets/Textures/Game Over.png"));
            Background.Scale = Game.WindowSize / new Vec2f(Background.Texture.Size.X, Background.Texture.Size.Y);
        }

        public EGameStates Update(GameTime time)
        {
            return EGameStates.GameOver;
        }
    }
}
