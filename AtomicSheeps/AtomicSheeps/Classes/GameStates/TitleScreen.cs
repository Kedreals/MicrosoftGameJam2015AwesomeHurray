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
        }

        public void LoadContent()
        {
            Texture tex = new Texture("Assets/Textures/TitelScreen.png");
            Background = new Sprite(tex);

            Background.Scale = Game.WindowSize / new Vec2f(Background.Texture.Size.X, Background.Texture.Size.Y);
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(Background);
        }

        public EGameStates Update(GameTime time)
        {
            return ReturnState;
        }
    }
}
