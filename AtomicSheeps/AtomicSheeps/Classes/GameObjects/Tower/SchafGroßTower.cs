using AtomicSheeps.Core;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Classes.GameObjects.Tower
{
    class SchafGroßTower : AbstractTower
    {
        public SchafGroßTower() : base()
        {

        }

        protected override void LoadStats()
        {
            sprite = new Sprite(new Texture("Assets/Textures/SchafGross.png"));
            ProjectiePath = "Assets/Textures/LambOfDoom.png";
            sprite.Scale = new Vec2f(0.66f, 0.66f);
            Damage = 20;
            Cooldown = new TimeSpan(0, 0, 3);
            Range = 192;
            Costs = 20;
            sprite.Position = new Vec2f(128+64, Game.WindowSize.Y - 192);
        }

    }
}
