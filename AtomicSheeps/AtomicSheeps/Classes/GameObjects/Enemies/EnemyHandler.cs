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
    static class EnemyHandler
    {
        public static List<AbstractEnemy> Enemies { get; private set; }

        static TimeSpan delay = new TimeSpan(0,0,0,0,100);
        static TimeSpan nextEnemy;
        static bool SpawnNextWave = true;
        static int SpawnedNumber = 0;
        static int WaveSize;

        static EEnemy WaveType = EEnemy.Scissor;

        enum EEnemy
        {
            None = -1,

            Scissor,
            Mob,

            Count
        }

        public static void Initialize()
        {
            Enemies = new List<AbstractEnemy>();
            nextEnemy = new TimeSpan(0, 0, 10);
            WaveSize = 10;
        }

        public static void Add(AbstractEnemy e)
        {
            Enemies.Add(e);
        }

        public static void Draw(RenderWindow win)
        {
            for (int i = Enemies.Count - 1; i >= 0; --i)
                if (Enemies[i] != null)
                    Enemies[i].Draw(win);
        }

        static void SpawnWave(GameTime t)
        {
            if (t.TotalTime.CompareTo(nextEnemy) >= 0)
            {
                if (SpawnedNumber < WaveSize)
                {
                    SpawnedNumber++;

                    Type[] ty = typeof(AbstractEnemy).Assembly.GetTypes();

                    foreach (Type te in ty)
                        if (te.IsSubclassOf(typeof(AbstractEnemy)) && te.Name.Split('.').Last().Equals(WaveType.ToString().Split('.').Last()))
                            Activator.CreateInstance(te, InGame.Level);

                    nextEnemy = t.TotalTime + delay;
                }
                else
                {
                    SpawnNextWave = false;
                    SpawnedNumber = 0;
                }
            }
        }

        public static void Update(GameTime gTime)
        {
            if (SpawnNextWave)
                SpawnWave(gTime);

            if(Enemies.Count == 0 && !SpawnNextWave)
            {
                nextEnemy = gTime.TotalTime + new TimeSpan(0, 0, 10);
                SpawnNextWave = true;
                WaveType = (EEnemy)new Random().Next((int)EEnemy.Count);
                WaveSize = (int)WaveType + ((int)WaveType + 1 + gTime.TotalTime.Minutes) * 10;
            }

            for(int i = 0; i<Enemies.Count; ++i)
            {
                if (!Enemies[i].IsAlive)
                {
                    Enemies.RemoveAt(i);
                    --i;
                    InGame.Money += 10;
                }
                else
                    Enemies[i].Update(gTime);
            }
        }
    }
}
