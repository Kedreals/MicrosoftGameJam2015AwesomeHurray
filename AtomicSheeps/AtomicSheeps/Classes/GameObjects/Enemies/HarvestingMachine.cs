using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Classes.GameObjects.Enemies
{
    class HarvestingMachine : AbstractEnemy
    {
        public HarvestingMachine(MapFolder.Map m) : base(m) { }

        protected override void LoadStats()
        {
            TextureList = new List<Texture>();

            TextureList.Add(new Texture("Assets/Textures/HarvestingMachine.png"));
            TextureList.Add(new Texture("Assets/Textures/HarvestingMachine_mirror.png"));
            TextureList.Add(new Texture("Assets/Textures/HarvestingMachineHinten.png"));
            TextureList.Add(new Texture("Assets/Textures/HarvestingMachine.png"));

            MovementSpeed = 0.02f;
            sprite = new Sprite(TextureList[0]);
            Life = 199;
            Money = 200;
        }
    }
}
