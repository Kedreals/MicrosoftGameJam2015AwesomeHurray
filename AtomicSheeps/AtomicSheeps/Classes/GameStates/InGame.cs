using AtomicSheeps.Core;
using SFML.Graphics;
using AtomicSheeps.Classes.MapFolder;
using SFML.Audio;

namespace AtomicSheeps.Classes.GameStates
{
    class InGame : IGameState
    {
        Map Level;
        CircleShape c;
        Sound BackgroundMusic;

        public void Draw(RenderWindow window)
        {
            Level.Draw(window);
            window.Draw(c);
        }

        public void Initialize()
        {
            c = new CircleShape(120);

            Color col = Color.Red;
            col.A = 100;

            c.FillColor = col;

        }

        public void LoadContent()
        {
            Level = new Map(new System.Drawing.Bitmap("Assets/Bitmap-Levels/Level1.bmp"));
            BackgroundMusic = new Sound(new SoundBuffer("Assets/Sounds/Farm-SoundBible.com-1720780826.wav"));
            BackgroundMusic.Loop = true;
            BackgroundMusic.Volume = 100;
            BackgroundMusic.Play();
        }

        public EGameStates Update(GameTime time)
        {
            Vec2f pos = MouseControler.MousePosition;

            c.Position = pos;
            c.Position = (Vec2f)c.Position - new Vec2f(c.Radius, c.Radius);

            return EGameStates.InGame;
        }
    }
}
