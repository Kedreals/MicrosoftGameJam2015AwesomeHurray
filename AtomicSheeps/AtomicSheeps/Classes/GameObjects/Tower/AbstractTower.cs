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
        public bool Selected { get; protected set; }

        CircleShape c;

        public AbstractTower()
        {
            LoadStats();
            MouseControler.ButtonPressed += OnButtonPress;
            MouseControler.ButtonReleased += OnButtonRelease;
            TowerHandler.Towers.Add(this);

            c = new CircleShape(Range);
            Color col = Color.Red;
            col.A = 100;
            c.FillColor = col;
        }

        protected abstract void LoadStats();

        public Vec2f Position { get { return sprite.Position; } }

        protected void Shooting(GameTime gTime)
        {
            float distance = 1000;
            float currentDistance;
            TimeSpan timeSpan = new TimeSpan();

            foreach (AbstractEnemy enemy in EnemyHandler.Enemies)
            {
                currentDistance = this.Position.Distance(enemy.Position);
                if (currentDistance <= Range && (timeSpan.Add(Cooldown)).CompareTo(gTime.TotalTime) != (-1) && currentDistance < distance)
                {
                    enemy.DoDamage(Damage);
                    timeSpan = gTime.TotalTime;
                    break;
                }
            }
        }

        public void OnButtonPress(object sender, MouseButtonEventArgs e)
        {
            if (MouseControler.MouseIn(sprite))
                Selected = true;
        }

        public void OnButtonRelease(object sender, MouseButtonEventArgs e)
        {
           Selected = false;
        }

        public Sprite IsMouseInMe()
        {
            return sprite;
        }

        public void Update(GameTime gTime)
        {
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
