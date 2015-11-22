using AtomicSheeps.Classes.GameObjects.Enemies;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Classes.GameObjects.Projectile
{
    class Projectile
    {
        public Sprite sprite;

        public Projectile(string texture)
        {

        }

        public void Draw(RenderWindow win)
        {
            win.Draw(sprite);
        }
    }
}
