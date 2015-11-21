using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtomicSheeps.Core;
using SFML.Graphics;

namespace AtomicSheeps.Classes.GameStates
{
    class TitelScreen : IGameState, IControlable
    {
        EGameStates ReturnState = EGameStates.TitelScreen;

        Sprite Background;
        CircleShape c;
        RenderTexture test;
        RenderStates shaderState;
        Shader testShader;

        public void OnKeyPress(object sender, KeyEventArgs e)
        {
            RemoveControls();
            ReturnState = EGameStates.MainMenu;
        }

        public void OnKeyRelease(object sender, KeyEventArgs e)
        {
        }

        public void OnButtonPress(object sender, MouseButtonEventArgs e)
        {
            RemoveControls();
            ReturnState = EGameStates.MainMenu;
        }

        public void OnButtonRelease(object sender, MouseButtonEventArgs e)
        {
        }

        public void AddControls()
        {
            KeyboardControler.KeyPressed += OnKeyPress;
            KeyboardControler.KeyReleased += OnKeyRelease;

            MouseControler.ButtonPressed += OnButtonPress;
            MouseControler.ButtonReleased += OnButtonRelease;
        }

        public void RemoveControls()
        {
            KeyboardControler.KeyPressed -= OnKeyPress;
            KeyboardControler.KeyReleased -= OnKeyRelease;

            MouseControler.ButtonPressed -= OnButtonPress;
            MouseControler.ButtonReleased -= OnButtonRelease;
        }

        public void Initialize()
        {
            AddControls();

            test = new RenderTexture((uint)Game.WindowSize.X, (uint)Game.WindowSize.Y);
            testShader = new Shader(null, "Shader/Overlap.frag");
            shaderState = new RenderStates(testShader);
            c = new CircleShape(120);

            Color col = Color.Red;
            col.A = 100;

            c.FillColor = col;
        }

        public void LoadContent()
        {
            Texture tex = new Texture("Assets/Textures/TitelScreen.png");
            Background = new Sprite(tex);

            Background.Scale = Game.WindowSize / new Vec2f(Background.Texture.Size.X, Background.Texture.Size.Y);
        }

        public void Draw(RenderWindow window)
        {
            if (Background != null)
            {
                window.Draw(Background, shaderState);
            }
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

            return ReturnState;
        }
    }
}
