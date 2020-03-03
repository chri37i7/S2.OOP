namespace ShapeEntities
{
    class Square : Rectangle
    {
        public Square(int x, int y, double length) : base(x, y, length)
        {
            X = x;
            Y = y;
            Length = length;
        }

        public override string ToString()
        {
            return $"Position: ({x}, {y}), Length: {length}";
        }
    }
}