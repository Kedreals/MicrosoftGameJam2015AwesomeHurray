using AtomicSheeps.Core;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Classes.GameObjects.Enemies
{
    static class EnemyHandler
    {
        public static List<AbstractEnemy> Enemies { get; private set; }

        public static void Initialize()
        {
            Enemies = new List<AbstractEnemy>();
        }

        public static void Add(AbstractEnemy e)
        {
            Enemies.Add(e);
        }

        public static void Draw(RenderWindow win)
        {
            foreach(AbstractEnemy e in Enemies)
                if (e != null)
                    e.Draw(win);
        }

        public static void Update(GameTime gTime)
        {
            foreach (AbstractEnemy e in Enemies)
                if (e != null)
                    e.Update(gTime);
        }
    }
}
