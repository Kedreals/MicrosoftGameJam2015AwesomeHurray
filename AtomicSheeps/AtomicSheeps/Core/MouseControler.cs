using AtomicSheeps.Classes;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Core
{
    class MouseButtonEventArgs
    {
        public MouseButton Button;
        public Vec2f Position;
    }

    enum MouseButton
    {
        None = -1,

        Left,
        Right,

        Count
    }

    static class MouseControler
    {
        static RenderWindow window;

        /// <summary>
        /// event that fires when a button is relized
        /// </summary>
        public static event EventHandler<MouseButtonEventArgs> ButtonReleased;

        /// <summary>
        /// is triggered once when a button is pressed
        /// </summary>
        public static event EventHandler<MouseButtonEventArgs> ButtonPressed;

        public static Vec2f MousePosition { get; private set; }

        /// <summary>
        /// triggers the relize event
        /// </summary>
        /// <param name="b"></param>
        static void OnButtonRelease(MouseButtonEventArgs e)
        {
            EventHandler<MouseButtonEventArgs> handler = ButtonReleased;
            if (ButtonReleased != null)
                handler(null, e);
        }

        /// <summary>
        /// triggers the button press event
        /// </summary>
        /// <param name="e"></param>
        static void OnButtonPress(MouseButtonEventArgs e)
        {
            EventHandler<MouseButtonEventArgs> handler = ButtonPressed;
            if (handler != null)
                handler(null, e);
        }

        static bool[] isPressed;
        static bool[] wasPressed;

        /// <summary>
        /// returns if the given sprite is pressed with the given Button
        /// </summary>
        /// <param name="sprite">the sprite that shall be pressed</param>
        /// <param name="b">the button that shall be checked</param>
        public static bool IsPressed(Sprite sprite, MouseButton b)
        {
            return MouseIn(sprite) && isPressed[(int)b];
        }

        public static bool IsPressed(MouseButton b)
        {
            return isPressed[(int)b];
        }

        /// <summary>
        /// initialize the controller
        /// </summary>
        public static void Initialize(RenderWindow win)
        {
            window = win;
            DebugInitialize();

            isPressed = new bool[(int)MouseButton.Count];
            for (int i = 0; i < isPressed.Length; ++i)
                isPressed[i] = false;

            wasPressed = new bool[(int)MouseButton.Count];
            for (int i = 0; i < wasPressed.Length; ++i)
                wasPressed[i] = false;
        }

        private static void DebugInitialize()
        {
            ButtonReleased += (sender, ev) => { Console.WriteLine("Released " + ev.Button); };
            ButtonPressed += (sender, ev) => { Console.WriteLine("Pressed " + ev.Button); };
        }

        /// <summary>
        /// checks if the mouse is in the rectangle
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool MouseIn(Rectangle rect)
        {
            Vec2f v = MousePosition;

            if (v.X < rect.Position.X || v.X > rect.Position.X + rect.Size.X)
                return false;

            if (v.Y < rect.Position.Y || v.Y > rect.Position.Y + rect.Size.Y)
                return false;

            return true;
        }

        /// <summary>
        /// gets the position in the given Rectangle
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static Vec2f PositionIn(Rectangle r)
        {
            return new Vec2f(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y) - r.Position;
        }

        /// <summary>
        /// checks if the mouse is within the sprite
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool MouseIn(Sprite sprite)
        {
            Vec2f v = new Vec2f(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y);
            Vec2f spriteSize = new Vec2f(sprite.Texture.Size.X * sprite.Scale.X, sprite.Texture.Size.Y * sprite.Scale.Y);

            if (v.X < sprite.Position.X || v.X > sprite.Position.X + spriteSize.X)
                return false;

            if (v.Y < sprite.Position.Y || v.Y > sprite.Position.Y + spriteSize.Y)
                return false;

            return true;
        }

        static Mouse.Button Cast(MouseButton b)
        {
            string name = b.ToString().Split('.').Last();

            string[] names = typeof(Mouse).GetNestedType("Button").GetEnumNames();

            for (int i = 0; i < names.Length; ++i)
                if (names[i].Equals(name))
                    return (Mouse.Button)i;

            return Mouse.Button.ButtonCount;
        }

        /// <summary>
        /// updates the mouse controller
        /// </summary>
        public static void Update()
        {
            Vector2i v = Mouse.GetPosition(window);
            MousePosition = new Vec2f(v.X, v.Y);

            for (int i = 0; i < isPressed.Length; ++i)
            {

                if (!isPressed[i] && Mouse.IsButtonPressed(Cast((MouseButton)i)))
                {
                    isPressed[i] = Mouse.IsButtonPressed((Mouse.Button)i);
                    MouseButtonEventArgs e = new MouseButtonEventArgs();
                    e.Button = (MouseButton)i;
                    e.Position.X = Mouse.GetPosition(window).X;
                    e.Position.Y = Mouse.GetPosition(window).Y;
                    OnButtonPress(e);
                }

                isPressed[i] = Mouse.IsButtonPressed(Cast((MouseButton)i));

                if (wasPressed[i] && !isPressed[i])
                {
                    MouseButtonEventArgs e = new MouseButtonEventArgs();
                    e.Button = (MouseButton)i;
                    e.Position.X = Mouse.GetPosition(window).X;
                    e.Position.Y = Mouse.GetPosition(window).Y;
                    OnButtonRelease(e);
                }

                wasPressed[i] = isPressed[i];
            }
        }
    }
}

