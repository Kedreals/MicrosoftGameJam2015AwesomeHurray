using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using AtomicSheeps.Core;

namespace AtomicSheeps.Classes.GameObjects.Tower
{
    class TestTower : AbstractTower
    {
        public TestTower() : base()
        {

        }

        protected override void LoadStats()
        {
            sprite = new SFML.Graphics.Sprite(new SFML.Graphics.Texture("Assets/Textures/SchafVerstrahlt.png"));
            Damage = 2;
            Cooldown = new TimeSpan(0,0,2);
            Range = 96;
            Costs = 5;
            sprite.Position = new Vec2f(100, 100);
        }
    }
}
