using AtomicSheeps.Core;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Classes.GameObjects.Tower
{
    abstract class Tower
    {
        Sprite sprite;
        public float damage { get; protected set; }
        public float range { get; protected set; }
        public float costs { get; protected set; }

        public Tower()
        {

        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(RenderWindow win);
    }
}
