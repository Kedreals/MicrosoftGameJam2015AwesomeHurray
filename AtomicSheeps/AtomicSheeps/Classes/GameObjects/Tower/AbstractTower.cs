using AtomicSheeps.Classes.GameObjects.Enemies;
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
        public float Damage { get; protected set; }
        public float Range { get; protected set; }
        public float Costs { get; protected set; }
        public TimeSpan Cooldown { get; protected set; }

        public AbstractTower()
        {
            TowerHandler.Towers.Add(this);
        }

        public Vec2f Position { get { return sprite.Position; } }

        protected void Shooting(GameTime gTime)
        {
            float distance = 1000;
            float currentDistance;
            TimeSpan timeSpan = new TimeSpan();

            foreach (AbstractEnemy enemy in EnemyHandler.Enemies)
            {
                currentDistance = this.Position.Distance(enemy.Position);
                if (currentDistance <= Range && (timeSpan.Add(Cooldown)).CompareTo(gTime) != (-1) && currentDistance < distance)
                {
                    enemy.DoDamage(Damage);
                    timeSpan = gTime.TotalTime;
                    break;
                }
            }
        }
 
        public void Update(GameTime gTime)
        {
            Shooting(gTime);
        }
        public void Draw(RenderWindow win)
        {
            win.Draw(sprite);
        }
    }
}
