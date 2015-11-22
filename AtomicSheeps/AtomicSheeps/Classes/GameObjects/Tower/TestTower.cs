using System;
using AtomicSheeps.Core;
using SFML.Graphics;

namespace AtomicSheeps.Classes.GameObjects.Tower
{
    class TestTower : AbstractTower
    {
        public TestTower() : base()
        {

        }

        protected override void LoadStats()
        {
            sprite = new Sprite(new Texture("Assets/Textures/SchafVerstrahlt.png"));
            ProjectiePath = "Assets/Textures/Wollball.png";
            Damage = 2;
            Cooldown = new TimeSpan(0,0,1);
            Range = 96;
            Costs = 5;
            sprite.Position = new Vec2f(128, Game.WindowSize.Y - 192);
        }
    }
}
