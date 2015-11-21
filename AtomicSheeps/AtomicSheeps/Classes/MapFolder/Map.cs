using AtomicSheeps.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtomicSheeps.Classes.MapFolder
{
    class Map
    {
        Tile[,] Tiles;
        float TileSize = 32;

        static Color white = Color.FromArgb(255, 255, 255);
        static Color black = Color.FromArgb(0, 0, 0);

        public Map(Bitmap bMap)
        {
            Tiles = new Tile[bMap.Width, bMap.Height];
            for(int i = 0; i < Tiles.GetLength(0); ++i)
                for(int j = 0; j<Tiles.GetLength(1); ++j)
                {
                    if (bMap.GetPixel(i, j).Equals(white))
                        Tiles[i, j] = new Tile(false, new Vec2f(i, j) * TileSize);
                    else
                    {
                        if (bMap.GetPixel(i, j).Equals(black))
                        {
                            
                        }
                    }
                }
        }
    }
}
