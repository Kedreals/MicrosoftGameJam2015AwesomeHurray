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
        int maxSpawn = 200;
        public int WaveSize { get { return (int)(maxSpawn * 1 / Life); } }
        public int TimeDelayMS { get { return (int)(100 * 1 / MovementSpeed); } }
        float MaxLife;
        protected float MovementSpeed;
        int VertexIndex;
        int Movement = 0;
        int i = 0;
        int AnimationSteps;
        int AnimationRate;
        protected int Money;

        List<Vec2f> Verticies;

        public AbstractEnemy(MapFolder.Map m) : base()
        {
            LoadStats();

            Life *= (int)(AbstractGame.gameTime.TotalTime.TotalMinutes + 1);
            maxSpawn *= (int)(AbstractGame.gameTime.TotalTime.TotalMinutes + 1);

            AnimationSteps = TextureList.Count / 4;
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

            sprite.Texture = TextureList[i + Movement * AnimationSteps];
        }

        public void Update(GameTime gTime)
        {
            if (IsAlive)
            {
                Animate(gTime);

                LifeBar.Scale = new Vec2f(Life / MaxLife, 1);
                LifeBar.Position = (Vec2f)sprite.Position + new Vec2f(0, LifeBar.Texture.Size.Y);

                if (Position.Distance(Verticies[VertexIndex]) < Help.Epsilon)
                    VertexIndex++;
                sprite.Position = Position + (Verticies[VertexIndex] - Position).GetNormalized() * MovementSpeed * gTime.EllapsedTime.Milliseconds;

                float x = (Verticies[VertexIndex] - Position).X;
                float y = (Verticies[VertexIndex] - Position).Y;

                Vec2i v = new Vec2i((Math.Abs(x) >= 1) ? (int)x / (int)Math.Abs(x) : 0, (Math.Abs(y) >= 1) ? (int)y / (int)Math.Abs(y) : 0);

                if (v == new Vec2i(1, 0))
                    Movement = 0;
                if (v == new Vec2i(-1, 0))
                    Movement = 1;
                if (v == new Vec2i(0, -1))
                    Movement = 2;
                if (v == new Vec2i(0, 1))
                    Movement = 3;

                if (Life <= 0)
                {
                    IsAlive = false;
                    InGame.Money += Money;
                }
            }
        }

        public void Kill()
        {
            IsAlive = false;
        }

        public void Draw(RenderWindow win)
        {
            win.Draw(sprite);
            win.Draw(LifeBar);
        }
    }
}
