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

        Sprite Start;
        Sprite Exit;
        Sprite Options;

        Vec2f MenuOffset = Game.WindowSize / 2 - new Vec2f(0, 100);

        Shader SelectedShader;
        RenderStates SelectedState;

        ESelectedSprite Selected;

        enum ESelectedSprite
        {
            None = -1,

            Start,
            Options,
            Exit,

            Count
        }

        public void OnKeyPress(object sender, KeyEventArgs e)
        {
            if(e.Key == Controls.Key.W)
            {
                if (Selected == ESelectedSprite.None)
                    Selected = ESelectedSprite.Start;
                else
                    Selected = (ESelectedSprite)(((int)Selected + (int)ESelectedSprite.Count - 1) % (int)ESelectedSprite.Count);
            }

            if(e.Key == Controls.Key.S)
            {
                if (Selected == ESelectedSprite.None)
                    Selected = ESelectedSprite.Start;
                else
                    Selected = (ESelectedSprite)(((int)Selected + 1) % (int)ESelectedSprite.Count);
            }

            if(e.Key == Controls.Key.Return)
            {
                if(Selected == ESelectedSprite.Exit)
                {
                    RemoveControls();

                    ReturnState = EGameStates.None;
                }

                if(Selected == ESelectedSprite.Start)
                {
                    RemoveControls();

                    ReturnState = EGameStates.InGame;
                }
            }
        }

        public void OnKeyRelease(object sender, KeyEventArgs e)
        {
        }

        public void OnButtonPress(object sender, MouseButtonEventArgs e)
        {
            if(Selected == ESelectedSprite.Exit)
            {
                RemoveControls();

                ReturnState = EGameStates.None;
            }

            if(Selected == ESelectedSprite.Start)
            {
                RemoveControls();

                ReturnState = EGameStates.InGame;
            }
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
            SelectedShader = new Shader(null, "Shader/SelectedShader.frag");
            SelectedState = new RenderStates(SelectedShader);

            AddControls();
        }

        public void LoadContent()
        {
            ReturnState = EGameStates.MainMenu;
            Selected = ESelectedSprite.None;

            Background = new Sprite(new Texture("Assets/Textures/MainMenu.png"));
            Background.Scale = Game.WindowSize / new Vec2f(Background.Texture.Size.X, Background.Texture.Size.Y);


            Start = new Sprite(new Texture("Assets/Textures/Start.png"));
            Start.Position = MenuOffset;
            Options = new Sprite(new Texture("Assets/Textures/Options.png"));
            Options.Position = (Vec2f)Start.Position + new Vec2f(0, Start.Texture.Size.Y + 10);
            Exit = new Sprite(new Texture("Assets/Textures/Exit.png"));
            Exit.Position = (Vec2f)Options.Position + new Vec2f(0, Options.Texture.Size.Y + 10);
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(Background);

            if (Selected == ESelectedSprite.Start)
                window.Draw(Start, SelectedState);
            else
                window.Draw(Start);

            if (Selected == ESelectedSprite.Options)
                window.Draw(Options, SelectedState);
            else
                window.Draw(Options);

            if (Selected == ESelectedSprite.Exit)
                window.Draw(Exit, SelectedState);
            else
                window.Draw(Exit);
        }

        void CheckMouse()
        {
            if (MouseControler.MouseIn(Start))
                Selected = ESelectedSprite.Start;
            if (MouseControler.MouseIn(Options))
                Selected = ESelectedSprite.Options;
            if (MouseControler.MouseIn(Exit))
                Selected = ESelectedSprite.Exit;
        }

        public EGameStates Update(GameTime time)
        {
            CheckMouse();

            return ReturnState;
        }
    }
}
