using AtomicSheeps.Core;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Classes.GameObjects.Tower
{
    class SheepSniper : AbstractTower
    {
        public SheepSniper() : base()
        {

        }

        protected override void LoadStats()
        {
            sprite = new Sprite(new Texture("Assets/Textures/SchafSniper.png"));
            ProjectiePath = "Assets/Textures/Wollball.png";
            Damage = 30;
            Cooldown = new TimeSpan(0, 0, 8);
            Range = 192*2;
            Costs = 25;
            sprite.Position = new Vec2f(128 + 128 + 64, Game.WindowSize.Y - 192);
        }
    }
}
