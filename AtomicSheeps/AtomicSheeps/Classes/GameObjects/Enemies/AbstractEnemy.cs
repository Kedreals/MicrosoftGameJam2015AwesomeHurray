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
    abstract class AbstractEnemy
    {
        protected Sprite sprite;
        public float Life { get; protected set; }
        protected float MovementSpeed;

        List<Vec2f> Verticies;

        public AbstractEnemy(MapFolder.Map m)
        {
            LoadStats();

            Verticies = m.Verticies;

            sprite.Position = Verticies[0];

            EnemyHandler.Add(this);
        }

        public void DoDamage(float damage)
        {
            Life -= damage;
        }

        protected abstract void LoadStats();

        public Vec2f Position { get { return sprite.Position; } }

        public void Update(GameTime gTime)
        {

        }

        public void Draw(RenderWindow win)
        {
            win.Draw(sprite);
        }
    }
}
