using AtomicSheeps.Core;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Classes.GameObjects.Tower
{
    class ChainsawSheep : AbstractTower
    {
        public ChainsawSheep() : base()
        {

        }

        protected override void LoadStats()
        {
            sprite = new Sprite(new Texture("Assets/Textures/SchafKlein.png"));
            ProjectiePath = "Assets/Textures/Feuerball.png";
            Damage = 1;
            Cooldown = new TimeSpan(0, 0, 1);
            Range = 96;
            Costs = 1;
            sprite.Position = new Vec2f(128 + 128 + 128, Game.WindowSize.Y - 192);
        }
    }
}
