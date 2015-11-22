using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Core
{
    class Help
    {
        public static float Epsilon { get; private set; }
        static float baseEpsilon = 0.125f;

        public static void Update(GameTime t)
        {
            Epsilon = baseEpsilon * t.EllapsedTime.Milliseconds;
        }
    }
}
