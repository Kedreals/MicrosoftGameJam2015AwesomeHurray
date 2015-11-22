using AtomicSheeps.Core;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Classes.GameObjects.Enemies
{
    class Scissor : AbstractEnemy
    {
        public Scissor(MapFolder.Map m) : base(m)
        {

        }

        protected override void LoadStats()
        {
            TextureList = new List<Texture>();

            TextureList.Add(new Texture("Assets/Textures/Figur1_mirror.png"));
            TextureList.Add(new Texture("Assets/Textures/Figur2_mirror.png"));
            TextureList.Add(new Texture("Assets/Textures/Figur1.png"));
            TextureList.Add(new Texture("Assets/Textures/Figur2.png"));

            MovementSpeed = 0.1f;
            sprite = new Sprite(TextureList[0]);
            Life = 10;
        }
    }
}
