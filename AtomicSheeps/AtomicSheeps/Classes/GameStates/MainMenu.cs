using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtomicSheeps.Core;
using SFML.Graphics;

namespace AtomicSheeps.Classes.GameStates
{
    class MainMenu : IGameState, IControlable
    {
        EGameStates ReturnState;

        Sprite Background;


        public void OnKeyPress(object sender, KeyEventArgs e)
        {
        }

        public void OnKeyRelease(object sender, KeyEventArgs e)
        {
        }

        public void OnButtonPress(object sender, MouseButtonEventArgs e)
        {
        }

        public void OnButtonRelease(object sender, MouseButtonEventArgs e)
        {
        }

        public void Initialize()
        {
        }

        public void LoadContent()
        {
            ReturnState = EGameStates.MainMenu;

            Background = new Sprite(new Texture("Assets/Textures/MainMenu.png"));
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
