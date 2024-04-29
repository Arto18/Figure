namespace Figure.Models
{
    public class Triangle : Figure
    {
        public Triangle(double a, double b, double c) : this(new double[] { a, b, c })
        {
            
        }

        public Triangle(double[] sides)
        {
            
            Update(sides);
            FigureType = FigureTypeEnum.Triangle;
        }

        public override bool IsRectangular()
        {
            var a = Sides[0];
            var b = Sides[1];
            var c = Sides[2];
            return (a * a + b * b == c * c) ||
                (a * a + c * c == b * b) ||
                (c * c + b * b == a * a);
        }

        public override void Update(double[] sides)
        {
            if (sides.Length != 3)
            {
                throw new ArgumentException("You need to specify the lengths of the three sides to create a triangle");
            }
                
            Sides = sides;
            var halfMeter = Sides.Sum() / 2;
            Area = Math.Sqrt(halfMeter * (halfMeter - Sides[0]) * (halfMeter - Sides[1]) * (halfMeter - Sides[2]));
        }

        public override void Update(double a, double b, double c)
        {
            Update(new double[]{a, b, c});
        }

        public override void Update(double radius)
        {
            throw new ArgumentException("You need to specify the lengths of the three sides to create a triangle");
        }
    }
}
