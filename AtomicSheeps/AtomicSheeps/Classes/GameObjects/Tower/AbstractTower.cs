using AtomicSheeps.Classes.GameObjects.Enemies;
using AtomicSheeps.Core;
using SFML.Graphics;
using System;
using AtomicSheeps.Classes.GameObjects.ProjectileFolder;

namespace AtomicSheeps.Classes.GameObjects.Tower
{
    abstract class AbstractTower : GameObject
    {
        public Sprite sprite;
        public float Damage { get; protected set; }
        public float Range { get; protected set; }
        public float Costs { get; protected set; }
        public TimeSpan Cooldown { get; protected set; }
        public bool Selected { get; set; }
        public bool IsAlive { get; set; }
        public bool Activated { get; set; }
        TimeSpan timeSpan;

        CircleShape c;

        public AbstractTower() : base()
        {
            LoadStats();
            TowerHandler.Add(this);
            timeSpan = new TimeSpan();

            IsAlive = true;
            Activated = false;

            c = new CircleShape(Range);
            Color col = Color.Red;
            col.A = 100;
            c.FillColor = col;
        }

        protected abstract void LoadStats();

        public Vec2f Position { get { return sprite.Position; } }

        protected void Shooting(GameTime gTime)
        {
            float currentDistance;

            foreach (AbstractEnemy enemy in EnemyHandler.Enemies)
            {
                currentDistance = this.Position.Distance(enemy.Position);
                                
                if (!Selected && currentDistance <= Range && timeSpan.CompareTo(gTime.TotalTime) < 0)
                {
                    new Projectile(Position + new Vec2f((sprite.Texture.Size.X * sprite.Scale.X) / 2, (sprite.Texture.Size.Y * sprite.Scale.Y) / 2), 
                        enemy, Damage, "Assets/Textures/Wollball.png");
                    timeSpan = gTime.TotalTime.Add(Cooldown);
                    break;
                }
            }
        }

        public void Update(GameTime gTime)
        {
            if (Activated)
                Shooting(gTime);

            if(Selected)
            {
                sprite.Position = MouseControler.MousePosition - new Vec2f((sprite.Texture.Size.X * sprite.Scale.X)/2, (sprite.Texture.Size.Y * sprite.Scale.Y) / 2);
            }

            if (MouseControler.MouseIn(sprite))
            {
                c.Position = (Vec2f)sprite.Position - Range + new Vec2f((sprite.Texture.Size.X * sprite.Scale.X) / 2, (sprite.Texture.Size.Y * sprite.Scale.Y) / 2);
            }

        }
        public void Draw(RenderWindow win)
        {
            win.Draw(sprite);

            if (MouseControler.MouseIn(sprite))
                win.Draw(c);
        }
    }
}
