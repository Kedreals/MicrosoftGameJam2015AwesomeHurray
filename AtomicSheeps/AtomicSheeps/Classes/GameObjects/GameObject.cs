using AtomicSheeps.Classes.GameStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Classes.GameObjects
{
    abstract class GameObject
    {
        public GameObject()
        {
            InGame.ExistingGameObjects++;
        }

        ~GameObject()
        {
            InGame.ExistingGameObjects--;
        }
    }
}
