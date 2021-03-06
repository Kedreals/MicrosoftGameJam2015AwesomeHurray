﻿using AtomicSheeps.Classes.GameStates;
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
        static List<AbstractEnemy> DrawList;

        static TimeSpan delay = new TimeSpan(0,0,0,0,100);
        static TimeSpan nextEnemy;
        static bool SpawnNextWave = true;
        static int SpawnedNumber = 0;
        static int WaveSize;

        static EEnemy WaveType = EEnemy.Scissor;
        static EComparer C = new EComparer();

        class EComparer : Comparer<AbstractEnemy>
        {
            public override int Compare(AbstractEnemy x, AbstractEnemy y)
            {
                return (int)(x.Position.Y - y.Position.Y);
            }
        }

        enum EEnemy
        {
            None = -1,

            Scissor,
            Mob,
            Ninja,
            HarvestingMachine,

            Count
        }

        public static void Initialize()
        {
            Enemies = new List<AbstractEnemy>();
            DrawList = new List<AbstractEnemy>();
            nextEnemy = new TimeSpan(0, 0, 10);
            AbstractEnemy e = new Scissor(InGame.Level);
            WaveSize = e.WaveSize;
            delay = new TimeSpan(0, 0, 0, 0, e.TimeDelayMS);
            e.Kill();
        }

        public static void Add(AbstractEnemy e)
        {
            Enemies.Add(e);
            DrawList.Add(e);
        }

        static void RemoveAt(int i)
        {
            AbstractEnemy e = Enemies[i];
            Enemies.RemoveAt(i);
            for(int j = 0; j < DrawList.Count; ++j)
            {
                if (DrawList[j] == e)
                {
                    DrawList.RemoveAt(j);
                    break;
                }
            }
        }

        public static void Draw(RenderWindow win)
        {
            foreach (AbstractEnemy e in Enemies)
                if (e != null)
                    e.Draw(win);
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
            DrawList.Sort(C);
            if (SpawnNextWave)
                SpawnWave(gTime);

            if(Enemies.Count == 0 && !SpawnNextWave)
            {
                nextEnemy = gTime.TotalTime + new TimeSpan(0, 0, 10);
                SpawnNextWave = true;
                WaveType = (EEnemy)((int)(WaveType + 1) % (int)EEnemy.Count);
                AbstractEnemy e = (AbstractEnemy)Activator.CreateInstance(typeof(AbstractEnemy).Assembly.GetType("AtomicSheeps.Classes.GameObjects.Enemies." + WaveType.ToString().Split('.').Last()), InGame.Level);
                WaveSize = e.WaveSize * ((int)gTime.TotalTime.TotalMinutes + 1);
                delay = new TimeSpan(0, 0, 0, 0, e.TimeDelayMS);
                e.Kill();
            }

            for(int i = 0; i<Enemies.Count; ++i)
            {
                if (!Enemies[i].IsAlive)
                {
                    RemoveAt(i);
                    --i;
                }
                else
                    Enemies[i].Update(gTime);
            }
        }
    }
}
