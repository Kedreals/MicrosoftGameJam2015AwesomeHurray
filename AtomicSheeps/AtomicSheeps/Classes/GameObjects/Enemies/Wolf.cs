using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Classes.GameObjects.Enemies
{
    class Wolf : AbstractEnemy
    {
        public Wolf(MapFolder.Map m) : base(m) { }

        protected override void LoadStats()
        {
            TextureList = new List<Texture>();

            TextureList.Add(new Texture("Assets/Textures/Wölfe1.Mirror.png"));
            TextureList.Add(new Texture("Assets/Textures/Wölfe2.Mirror.png"));
            TextureList.Add(new Texture("Assets/Textures/Wölfe3.Mirror.png"));
            TextureList.Add(new Texture("Assets/Textures/Wölfe1.png"));
            TextureList.Add(new Texture("Assets/Textures/Wölfe2.png"));
            TextureList.Add(new Texture("Assets/Textures/Wölfe3.png"));
            TextureList.Add(new Texture("Assets/Textures/wolfhinten.png"));
            TextureList.Add(new Texture("Assets/Textures/wolfhinten2.png"));
            TextureList.Add(new Texture("Assets/Textures/wolfhinten.png"));
            TextureList.Add(new Texture("Assets/Textures/wolf.png"));
            TextureList.Add(new Texture("Assets/Textures/wolf2.png"));
            TextureList.Add(new Texture("Assets/Textures/wolf.png"));

            MovementSpeed = 0.125f;
            sprite = new Sprite(TextureList[0]);
            Life = 30;
            Money = 20;
        }
    }
}
