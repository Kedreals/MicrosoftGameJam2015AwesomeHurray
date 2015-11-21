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
        public static float TileSize { get { return 64; } }
        public Vec2f SpawnPosition { get; private set; }

        static Color white = Color.FromArgb(255, 255, 255);
        static Color black = Color.FromArgb(0, 0, 0);
        static Color red = Color.FromArgb(255, 0, 0);
        Random r = new Random();

        public Map(Bitmap bMap)
        {
            Tiles = new Tile[bMap.Width, bMap.Height];
            for(int i = 0; i < Tiles.GetLength(0); ++i)
                for(int j = 0; j<Tiles.GetLength(1); ++j)
                {
                    if (bMap.GetPixel(i, j).Equals(white))
                    {
                        if (r.Next(10) > 7)
                            Tiles[i, j] = new Tile(false, new Vec2f(i, j) * TileSize, "Assets/Textures/tree.png");
                        else
                            Tiles[i, j] = new Tile(false, new Vec2f(i, j) * TileSize);
                    }
                    else
                    {
                        if (bMap.GetPixel(i, j).Equals(black))
                        {
                            string Path = "";

                            bool left;

                            if (i - 1 < 0)
                                left = false;
                            else
                                left = bMap.GetPixel(i - 1, j).Equals(white);

                            bool right;

                            if (i + 1 >= Tiles.GetLength(0))
                                right = false;
                            else
                                right = bMap.GetPixel(i + 1, j).Equals(white);

                            bool up;

                            if (j - 1 < 0)
                                up = false;
                            else
                                up = bMap.GetPixel(i, j - 1).Equals(white);

                            bool down;

                            if (j + 1 >= Tiles.GetLength(1))
                                down = false;
                            else
                                down = bMap.GetPixel(i, j + 1).Equals(white);

                            if (!left && !right && !up && !down)
                                Path = "Assets/Textures/ground_without_grass.png";

                            if (!left && !right && up && down)
                                Path = "Assets/Textures/ground_straight.png";

                            if (left && right && !up && !down)
                                Path = "Assets/Textures/ground_straight_2.png";

                            if (left && !right && up && !down)
                                Path = "Assets/Textures/ground_corner_left_up.png";

                            if (left && !right && !up && down)
                                Path = "Assets/Textures/ground_corner_left_down.png";

                            if (!left && right && up && !down)
                                Path = "Assets/Textures/ground_corner_right_up.png";

                            if (!left && right && !up && down)
                                Path = "Assets/Textures/ground_corner_right_down.png";

                            if (Path != "")
                                Tiles[i, j] = new Tile(true, new Vec2f(i, j) * TileSize, Path);
                        }

                        if (bMap.GetPixel(i, j).Equals(red))
                        {
                            Vec2f pos = new Vec2f(i, j) * TileSize;

                            Tiles[i, j] = new Tile(true, pos, "Assets/Textures/house_humans.png");

                            SpawnPosition = pos + new Vec2f(TileSize / 2, TileSize / 2);
                        }
                    }
                }
        }

        public void Draw(SFML.Graphics.RenderWindow win)
        {
            foreach(Tile t in Tiles)
            {
                if (t != null)
                    t.Draw(win);
            }
        }
    }
}
