using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtomicSheeps.Classes;

namespace AtomicSheeps
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g = new Game();

            for (int i = -1; i < (int)SFML.Window.Keyboard.Key.KeyCount; ++i)
                Console.WriteLine((SFML.Window.Keyboard.Key)i);

            g.Run();
        }
    }
}
