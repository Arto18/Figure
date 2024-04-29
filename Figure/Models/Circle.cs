namespace Figure.Models
{
    public class Circle : Figure
    {
        public Circle(double radius)
        {
            Area = Math.PI * radius * radius;
            Sides = new double[] { radius };
            FigureType = FigureTypeEnum.Circle;
        }

        public Circle(double[] radius) : this(radius[0])
        {
            
        }

        public override bool IsRectangular()
        {
            return false;
        }

        public override void Update(double[] sides)
        {
            Update(sides[0]);
        }

        public override void Update(double radius)
        {
            Area = Math.PI * radius * radius;
            Sides = new double[] { radius };
        }

        public override void Update(double a, double b, double c)
        {
            throw new NotImplementedException();
        }
    }
}
