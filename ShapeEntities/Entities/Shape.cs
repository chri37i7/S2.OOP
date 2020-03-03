namespace ShapeEntities
{
    public abstract class Shape
    {
        protected int x;
        protected int y;

        protected Shape(int x, int y)
        {
            X = x;
            Y = y;
        }

        public virtual int X
        {
            get
            {
                return x;
            }
            set
            {
                if(x != value)
                {
                    x = value;
                }
            }
        }

        public virtual int Y
        {
            get
            {
                return y;
            }
            set
            {
                if(y != value)
                {
                    y = value;
                }
            }
        }

        public abstract double CalculateArea();
        public abstract double CalculateCircumference();

        public override string ToString()
        {
            return $"Position: ({x},{y})";
        }
    }
}