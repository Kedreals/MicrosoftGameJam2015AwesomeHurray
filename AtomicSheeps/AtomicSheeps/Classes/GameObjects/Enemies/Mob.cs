using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Classes.GameObjects.Enemies
{
    class Mob : AbstractEnemy
    {
        public Mob(MapFolder.Map m) : base(m) { }

        protected override void LoadStats()
        {
            TextureList = new List<Texture>();

            TextureList.Add(new Texture("Assets/Textures/Mob1.png"));
            TextureList.Add(new Texture("Assets/Textures/Mob2.png"));
            TextureList.Add(new Texture("Assets/Textures/Mob1_mirror.png"));
            TextureList.Add(new Texture("Assets/Textures/Mob2_mirror.png"));
            TextureList.Add(new Texture("Assets/Textures/MobHinten1.png"));
            TextureList.Add(new Texture("Assets/Textures/MobHinten2.png"));
            TextureList.Add(new Texture("Assets/Textures/Mob1.png"));
            TextureList.Add(new Texture("Assets/Textures/Mob2.png"));

            MovementSpeed = 0.05f;
            sprite = new Sprite(TextureList[0]);
            Life = 100;
            Money = 25;
        }
    }
}
