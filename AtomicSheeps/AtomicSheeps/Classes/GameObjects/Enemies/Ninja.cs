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
            TextureList.Add(new Texture("Assets/Textures/NinjaHinten1.png"));
            TextureList.Add(new Texture("Assets/Textures/NinjaHinten2.png"));
            TextureList.Add(new Texture("Assets/Textures/NinjaHinten3.png"));
            TextureList.Add(new Texture("Assets/Textures/NinjaHinten4.png"));
            TextureList.Add(new Texture("Assets/Textures/NinjaVorne1.png"));
            TextureList.Add(new Texture("Assets/Textures/NinjaVorne2.png"));
            TextureList.Add(new Texture("Assets/Textures/NinjaVorne3.png"));
            TextureList.Add(new Texture("Assets/Textures/NinjaVorne4.png"));

            MovementSpeed = 0.25f;
            sprite = new Sprite(TextureList[0]);
            Life = 15;
            Money = 10;
        }
    }
}
