using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Core
{
    class Controls
    {
        /// <summary>
        /// Keys for use within the game
        /// </summary>
        public enum Key
        {
            Unknown = -1,

            A,
            B,
            C,
            D,
            E,
            F,
            G,
            H,
            I,
            J,
            K,
            L,
            M,
            N,
            O,
            P,
            Q,
            R,
            S,
            T,
            U,
            V,
            W,
            X,
            Y,
            Z,

            Num0,
            Num1,
            Num2,
            Num3,
            Num4,
            Num5,
            Num6,
            Num7,
            Num8,
            Num9,
            Numpad0,
            Numpad1,
            Numpad2,
            Numpad3,
            Numpad4,
            Numpad5,
            Numpad6,
            Numpad7,
            Numpad8,
            Numpad9,

            Escape,
            LBracket,
            RBracket,
            Slash,
            Space,
            Return,
            Back,

            Left,
            Up,
            Right,
            Down,

            Count
        }

        /// <summary>
        /// casts SFML.Window.Keyboard.Key into Controls.Key
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public static Key Cast(SFML.Window.Keyboard.Key k)
        {
            for(int i = 0; i<(int)Key.Count; ++i)
                if(((Key)i).ToString().Split('.').Last().Equals(k.ToString().Split('.').Last()))
                    return (Key)i;

            return Key.Unknown;
        }
    }
}
