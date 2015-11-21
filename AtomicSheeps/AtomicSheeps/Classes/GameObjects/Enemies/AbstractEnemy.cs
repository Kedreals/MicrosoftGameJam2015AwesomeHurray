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
        public bool IsAlive { get; protected set; }
        public float Life { get; protected set; }
        protected float MovementSpeed;
        int VertexIndex;
        float Epsilon = 0.0625f;

        List<Vec2f> Verticies;

        public AbstractEnemy(MapFolder.Map m)
        {
            LoadStats();

            IsAlive = true;
            Verticies = m.Verticies;
            VertexIndex = 1;

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
            if (Position.Distance(Verticies[VertexIndex]) < Epsilon)
                VertexIndex++;
            sprite.Position = Position + (Verticies[VertexIndex] - Position).GetNormalized() * MovementSpeed;

            if (Life <= 0)
                IsAlive = false;
        }

        public void Draw(RenderWindow win)
        {
            win.Draw(sprite);
        }
    }
}
