using AtomicSheeps.Classes.GameObjects.Enemies;
using AtomicSheeps.Core;
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
        Sprite sprite;
        float Damage;
        AbstractEnemy Target;
        float MovementSpeed = 0.5f;

        float Epsilon = 0.0625f;

        public bool IsAlive { get; private set; }

        public Projectile(AbstractEnemy target, float d, string TexturePath)
        {
            Target = target;
            IsAlive = true;
            Damage = d;
            sprite = new Sprite(new Texture(TexturePath));
            ProjectileHandler.Projectiles.Add(this);
        }

        public void Draw(RenderWindow win)
        {
            win.Draw(sprite);
        }

        public void Update(GameTime t)
        {
            sprite.Position = (Vec2f)sprite.Position + ((Vec2f)sprite.Position - Target.Position).GetNormalized() * MovementSpeed * t.EllapsedTime.Milliseconds;

            if(Target.Position.Distance(sprite.Position)<=Epsilon)
            {
                Target.DoDamage(Damage);
                IsAlive = false;
            }

        }
    }
}
