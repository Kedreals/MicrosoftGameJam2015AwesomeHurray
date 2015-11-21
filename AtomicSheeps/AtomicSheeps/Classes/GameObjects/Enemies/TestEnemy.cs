using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Classes.GameObjects.Enemies
{
    class TestEnemy : AbstractEnemy
    {
        public TestEnemy(MapFolder.Map m) : base(m)
        {

        }

        protected override void LoadStats()
        {
            MovementSpeed = 0.2f;
            sprite = new SFML.Graphics.Sprite(new SFML.Graphics.Texture("Assets/Textures/LambOfDoom.png"));
            Life = 10;
        }
    }
}
