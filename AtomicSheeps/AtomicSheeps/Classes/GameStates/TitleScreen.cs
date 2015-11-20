using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtomicSheeps.Core;
using SFML.Graphics;

namespace AtomicSheeps.Classes.GameStates
{
    class TitelScreen : GameState
    {
        Sprite Background;

        public void Draw(RenderWindow window)
        {
            if (Background != null)
                window.Draw(Background);
        }

        public void Initialize()
        {
            
        }

        public void LoadContent()
        {
            Texture tex = new Texture("Assets/Textures/TitelScreen.png");
            Background = new Sprite(tex);

            Background.Scale = Game.WindowSize / new Vec2f(Background.Texture.Size.X, Background.Texture.Size.Y);
        }

        public EGameStates Update(GameTime time)
        {
            return EGameStates.TitelScreen;
        }
    }
}
