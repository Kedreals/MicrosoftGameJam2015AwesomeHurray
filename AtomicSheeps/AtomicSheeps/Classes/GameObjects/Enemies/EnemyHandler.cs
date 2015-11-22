using AtomicSheeps.Classes.GameStates;
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

        static int delay = 100;
        static TimeSpan lastEnemy = new TimeSpan();

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
            if (gTime.TotalTime.Seconds > 10)
            {
                if ((gTime.TotalTime - lastEnemy).Milliseconds > delay)
                {
                    new Scissor(InGame.Level);
                    lastEnemy = gTime.TotalTime;
                }
            }
            for(int i = 0; i<Enemies.Count; ++i)
            {
                if (!Enemies[i].IsAlive)
                {
                    Enemies.RemoveAt(i);
                    --i;
                }
                else
                    Enemies[i].Update(gTime);
            }
        }
    }
}
