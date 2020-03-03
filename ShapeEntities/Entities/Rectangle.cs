namespace ShapeEntities
{
    class Rectangle : Shape
    {
        protected double length;
        protected double width;

        public Rectangle(int x, int y, double length, double width) : base(x, y)
        {
            Length = length;
            Width = width;
        }

        protected Rectangle(int x, int y, double length) : base(x, y)
        {
            Length = length;
        }

        public virtual double Length
        {
            get
            {
                return length;
            }
            set
            {
                if(length != value)
                {
                    length = value;
                }
            }
        }

        public virtual double Width
        {
            get
            {
                return width;
            }
            set
            {
                if(width != value)
                {
                    width = value;
                }
            }
        }

        public override double CalculateArea()
        {
            return length * width;
        }

        public override double CalculateCircumference()
        {
            return (length * 2) + (width * 2);
        }

        public override string ToString()
        {
            return $"Position: ({x}, {y}), Length: {length}, Width: {width}";
        }
    }
}