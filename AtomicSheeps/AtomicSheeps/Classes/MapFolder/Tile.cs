using AtomicSheeps.Core;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Classes.MapFolder
{
    class Tile
    {
        Sprite S;
        public bool IsPath { get; private set; }

        public Tile(bool isPath, Vec2f WorldPosition, string texturePath = "Assets/Textures/grass.png")
        {
            S = new Sprite(new Texture(texturePath));
            S.Position = WorldPosition;
            S.Scale = new Vec2f(Map.TileSize, Map.TileSize) / new Vec2f(S.Texture.Size.X, S.Texture.Size.Y);
            IsPath = isPath;
        }

        public void Draw(RenderWindow win)
        {
            win.Draw(S);
        }
    }
}
