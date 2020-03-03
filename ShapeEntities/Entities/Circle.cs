namespace ShapeEntities
{
    public class Circle : Shape
    {
        protected double radius;

        public Circle(int x, int y, double radius) : base(x, y)
        {
            Radius = radius;
        }

        public virtual double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if(radius != value)
                {
                    radius = value;
                }
            }
        }

        public override double CalculateArea()
        {
            return ((radius * radius) * 3.1415926535897931);
        }

        public override double CalculateCircumference()
        {
            return ((radius * 2) * 3.1415926535897931);
        }

        public override string ToString()
        {
            return $"Position: ({x},{y}), Radius: {radius}";
        }
    }
}