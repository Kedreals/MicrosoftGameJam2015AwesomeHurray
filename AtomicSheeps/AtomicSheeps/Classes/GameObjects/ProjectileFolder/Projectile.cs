using AtomicSheeps.Classes.GameObjects.Enemies;
using AtomicSheeps.Core;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Classes.GameObjects.ProjectileFolder
{
    class Projectile : GameObject
    {
        Sprite sprite;
        float Damage;
        AbstractEnemy Target;
        Vec2f TargetPosition;
        float MovementSpeed = 0.5f;

        public bool IsAlive { get; private set; }

        public Projectile(Vec2f startPos, AbstractEnemy target, float d, string TexturePath) : base()
        {
            Target = target;
            IsAlive = true;
            Damage = d;
            sprite = new Sprite(new Texture(TexturePath));

            sprite.Position = startPos;
            ProjectileHandler.Projectiles.Add(this);
        }

        public void Draw(RenderWindow win)
        {
            win.Draw(sprite);
        }

        public void Update(GameTime t)
        {
            if (!Target.IsAlive)
                IsAlive = false;

            TargetPosition = (Target.Position + Target.Size / 2 - new Vec2f(sprite.Texture.Size.X, sprite.Texture.Size.Y) / 2);

            sprite.Position = (Vec2f)sprite.Position + (TargetPosition - (Vec2f)sprite.Position).GetNormalized() * MovementSpeed * t.EllapsedTime.Milliseconds;

            if(TargetPosition.Distance(sprite.Position)<=Help.Epsilon)
            {
                Target.DoDamage(Damage);
                IsAlive = false;
            }

        }
    }
}
