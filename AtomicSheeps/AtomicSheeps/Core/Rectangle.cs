namespace AtomicSheeps.Core
{
    /// <summary>
    /// a class just for a logical Rectangle
    /// </summary>
    struct Rectangle
    {
        public Vec2f Position { get; set; }
        public Vec2f Size { get; set; }

        public Rectangle(Vec2f pos, Vec2f size)
        {
            Position = pos;
            Size = size;
        }

        public Rectangle(Vec2f pos, float sizeX, float sizeY) : this(pos, new Vec2f(sizeX, sizeY)) { }
        public Rectangle(float posX, float posY, Vec2f size) : this(new Vec2f(posX, posY), size) { }
        public Rectangle(float posX, float posY, float sizeX, float sizeY) : this(new Vec2f(posX, posY), new Vec2f(sizeX, sizeY)) { }
    }
}