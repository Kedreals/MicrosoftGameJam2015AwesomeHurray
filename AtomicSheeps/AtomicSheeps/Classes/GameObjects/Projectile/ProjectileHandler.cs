using AtomicSheeps.Core;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Classes.GameObjects.Projectile
{
    class ProjectileHandler
    {
        public static List<Projectile> Projectiles;

        public static void Initialize()
        {
            Projectiles = new List<Projectile>();
        }

        public static void Update(GameTime t)
        {
            for(int i = 0; i<Projectiles.Count; ++i)
            {
                if (!Projectiles[i].IsAlive)
                {
                    Projectiles.RemoveAt(i);
                    --i;
                }
                else
                    Projectiles[i].Update(t);
            }
        }

        public static void Draw(RenderWindow win)
        {
            foreach (Projectile p in Projectiles)
                p.Draw(win);
        }
    }
}
