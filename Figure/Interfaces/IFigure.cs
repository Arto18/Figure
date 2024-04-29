namespace Figure.Interfaces
{
    public interface IFigure
    {
        public FigureTypeEnum FigureType { get; }
        public double Area { get; }
        public double[] Sides { get; }
        public void Update(double[] sides);
        public void Update(double a, double b, double c);
        public void Update(double radius);
        public bool IsRectangular();
    }
}
