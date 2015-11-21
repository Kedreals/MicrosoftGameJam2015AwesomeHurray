using AtomicSheeps.Core;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Classes
{
    public enum EGameStates
    {
        None = -1,

        TitelScreen,
        MainMenu,
        InGame,
        GameOver,

        Count
    }

    interface IGameState
    {
        void Initialize();

        void LoadContent();

        EGameStates Update(GameTime time);

        void Draw(RenderWindow window);
    }
}
