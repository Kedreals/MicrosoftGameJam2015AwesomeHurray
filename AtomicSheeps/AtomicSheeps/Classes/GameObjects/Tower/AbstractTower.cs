using AtomicSheeps.Core;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Classes.GameObjects.Tower
{
    abstract class AbstractTower
    {
        protected Sprite sprite;
        public float damage { get; protected set; }
        public float range { get; protected set; }
        public float costs { get; protected set; }

        public AbstractTower()
        {
            TowerHandler.Towers.Add(this);
        }

        public Vec2f Position { get { return sprite.Position; } }

        protected void Shooting()
        {

        }

        public void Update(GameTime gTime)
        {

        }
        public void Draw(RenderWindow win)
        {
            win.Draw(sprite);
        }
    }
}
