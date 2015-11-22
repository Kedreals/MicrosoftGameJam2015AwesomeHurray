using AtomicSheeps.Classes.GameObjects.Tower;
using AtomicSheeps.Core;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace AtomicSheeps.Classes.MapFolder
{
    class Map
    {
        Tile[,] Tiles;
        public static float TileSize { get { return 64; } }
        Vec2i SpawnPosition;
        Vec2i EndPosition;
        public List<Vec2f> Verticies { get; private set; }

        static Color white = Color.FromArgb(255, 255, 255);
        static Color black = Color.FromArgb(0, 0, 0);
        static Color red = Color.FromArgb(255, 0, 0);
        static Color yellow = Color.FromArgb(255, 255, 0);

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

                            SpawnPosition = new Vec2i(i, j);
                        }

                        if(bMap.GetPixel(i, j).Equals(yellow))
                        {
                            Vec2f pos = new Vec2f(i, j) * TileSize;
                            Tiles[i, j] = new Tile(true, pos, "Assets/Textures/house.png");
                            EndPosition = new Vec2i(i, j);
                        }
                    }
                }

            Verticies = new List<Vec2f>();

            SetMovementVeticies();
        }

        void SetMovementVeticies()
        {
            Verticies.Add((Vec2f)SpawnPosition * TileSize);

            Vec2i d = new Vec2i(1, 0);
            Vec2i pos = SpawnPosition;

            while(pos != EndPosition)
            {
                for (; pos != EndPosition && Tiles[(pos + d).X, (pos + d).Y].IsPath ;pos += d);

                if (pos == EndPosition)
                    break;

                Verticies.Add((Vec2f)pos * TileSize);
                Vec2i t = -d;

                if (Tiles[pos.X + 0, pos.Y + 1].IsPath && -d != new Vec2i(0, 1))
                    d = new Vec2i(0, 1);
                else if (Tiles[pos.X + 1, pos.Y + 0].IsPath && -d != new Vec2i(1, 0))
                    d = new Vec2i(1, 0);
                else if (Tiles[pos.X - 1, pos.Y - 0].IsPath && -d != new Vec2i(-1, 0))
                    d = new Vec2i(-1, 0);
                else if (Tiles[pos.X - 0, pos.Y - 1].IsPath && -d != new Vec2i(0, -1))
                    d = new Vec2i(0, -1);
            }

            Verticies.Add((Vec2f)EndPosition * TileSize);
        }

        public Vec2f GetValidPosition(Vec2f pos)
        {
            Vec2i tilePos = (pos / TileSize);

            try
            {
                if (Tiles[tilePos.X, tilePos.Y].IsPath)
                    throw new PathException();

                foreach(AbstractTower t in TowerHandler.Towers)
                {
                    if (((Vec2f)tilePos * TileSize) == t.Position)
                        throw new PathException();
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw new PathException();
            }

            return (Vec2f)tilePos * TileSize;
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
