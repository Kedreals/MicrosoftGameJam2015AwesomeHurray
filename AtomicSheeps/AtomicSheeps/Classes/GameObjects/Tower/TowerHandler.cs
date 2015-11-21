using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtomicSheeps.Core;
using SFML.Graphics;

namespace AtomicSheeps.Classes.GameObjects.Tower
{
    static class TowerHandler
    {
        public static List<AbstractTower> Towers { get; private set; }

        public static void Initialize()
        {
            Towers = new List<AbstractTower>();
        }

        public static void Add(AbstractTower e)
        {
            Towers.Add(e);
        }

        public static void Draw(RenderWindow win)
        {
            foreach (AbstractTower e in Towers)
                if (e != null)
                    e.Draw(win);
        }

        public static void Update(GameTime gTime)
        {
            foreach (AbstractTower e in Towers)
                if (e != null)
                    e.Update(gTime);
        }
    }
}
