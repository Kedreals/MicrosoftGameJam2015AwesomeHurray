using AtomicSheeps.Core;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Classes.GameObjects.Tower
{
    class RainbowSheep : AbstractTower
    {
        public RainbowSheep() : base()
        {

        }

        protected override void LoadStats()
        {
            sprite = new Sprite(new Texture("Assets/Textures/SchafUnicorn.png"));
            ProjectiePath = "Assets/Textures/Regenbogenball.png";
            Damage = 100;
            Cooldown = new TimeSpan(0, 0, 5);
            Range = 192;
            Costs = 50;
            sprite.Position = new Vec2f(128 + 128, Game.WindowSize.Y - 192);
        }
    }
}
