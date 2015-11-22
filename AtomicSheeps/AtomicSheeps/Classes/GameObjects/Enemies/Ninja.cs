using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Classes.GameObjects.Enemies
{
    class Ninja : AbstractEnemy
    {
        public Ninja(MapFolder.Map m) : base(m) { }

        protected override void LoadStats()
        {
            TextureList = new List<Texture>();

            TextureList.Add(new Texture("Assets/Textures/Ninja1.png"));
            TextureList.Add(new Texture("Assets/Textures/Ninja2.png"));
            TextureList.Add(new Texture("Assets/Textures/Ninja3.png"));
            TextureList.Add(new Texture("Assets/Textures/Ninja4.png"));
            TextureList.Add(new Texture("Assets/Textures/Ninja1_mirror.png"));
            TextureList.Add(new Texture("Assets/Textures/Ninja2_mirror.png"));
            TextureList.Add(new Texture("Assets/Textures/Ninja3_mirror.png"));
            TextureList.Add(new Texture("Assets/Textures/Ninja4_mirror.png"));

            MovementSpeed = 0.25f;
            sprite = new Sprite(TextureList[0]);
            Life = 15;
            Money = 10;
        }
    }
}
