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
        CircleShape c;
        RenderTexture test;
        RenderStates shaderState;
        Shader testShader;

        public void Draw(RenderWindow window)
        {
            if (Background != null)
            {
                window.Draw(Background, shaderState);
            }
        }

        public void Initialize()
        {
            
        }

        public void LoadContent()
        {
            Texture tex = new Texture("Assets/Textures/TitelScreen.png");
            Background = new Sprite(tex);

            Background.Scale = Game.WindowSize / new Vec2f(Background.Texture.Size.X, Background.Texture.Size.Y);

            test = new RenderTexture((uint)Game.WindowSize.X, (uint)Game.WindowSize.Y);
            testShader = new Shader(null, "Shader/Overlap.frag");
            shaderState = new RenderStates(testShader);
            c = new CircleShape(120);

            Color col = Color.Red;
            col.A = 100;

            c.FillColor = col;

        }

        public EGameStates Update(GameTime time)
        {
            Vec2f pos = MouseControler.MousePosition;

            c.Position = new Vec2f(0, Game.WindowSize.Y) - new Vec2f(-pos.X, pos.Y);
            c.Position = (Vec2f)c.Position - new Vec2f(c.Radius, c.Radius);

            test.Clear(Color.White);
            test.Draw(c);
            test.Draw(c);
            test.Display();

            testShader.SetParameter("overlay", test.Texture);

            return EGameStates.TitelScreen;
        }
    }
}
