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
    abstract class AbstractEnemy : GameObject
    {
        protected Sprite sprite;

        protected List<Texture> TextureList;

        private Sprite LifeBar;
        public Vec2f Position { get { return sprite.Position; } }
        public Vec2f Size { get { return new Vec2f(sprite.Texture.Size.X, sprite.Texture.Size.Y) * (Vec2f)sprite.Scale; } }
        public bool IsAlive { get; protected set; }
        public float Life { get; protected set; }
        float MaxLife;
        protected float MovementSpeed;
        int VertexIndex;
        bool leftMovement;
        int i = 0;
        int AnimationSteps;
        int AnimationRate;

        List<Vec2f> Verticies;

        public AbstractEnemy(MapFolder.Map m) : base()
        {
            LoadStats();

            AnimationSteps = TextureList.Count / 2;
            AnimationRate = 1000 / AnimationSteps;

            IsAlive = true;
            MaxLife = Life;
            Verticies = m.Verticies;
            VertexIndex = 1;
            LifeBar = new Sprite(new Texture("Assets/Textures/Lebensbalken.png"));

            sprite.Position = Verticies[0];
            LifeBar.Position = (Vec2f)sprite.Position + new Vec2f(0, LifeBar.Texture.Size.Y);

            EnemyHandler.Add(this);
        }

        public void DoDamage(float damage)
        {
            Life -= damage;
        }

        protected abstract void LoadStats();

        protected void Animate(GameTime t)
        {
            i = (t.TotalTime.Milliseconds / AnimationRate) % AnimationSteps;

            if (leftMovement)
                sprite.Texture = TextureList[i + AnimationSteps];
            else
                sprite.Texture = TextureList[i];
            
        }

        public void Update(GameTime gTime)
        {
            Animate(gTime);

            LifeBar.Scale = new Vec2f(Life / MaxLife, 1);
            LifeBar.Position = (Vec2f)sprite.Position + new Vec2f(0, LifeBar.Texture.Size.Y);

            if (Position.Distance(Verticies[VertexIndex]) < Help.Epsilon)
                VertexIndex++;
            sprite.Position = Position + (Verticies[VertexIndex] - Position).GetNormalized() * MovementSpeed * gTime.EllapsedTime.Milliseconds;

            leftMovement = (Verticies[VertexIndex] - Position).X < 0;

            if (Life <= 0)
                IsAlive = false;
        }

        public void Draw(RenderWindow win)
        {
            win.Draw(sprite);
            win.Draw(LifeBar);
        }
    }
}
