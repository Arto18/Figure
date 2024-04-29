using Figure.Interfaces;

namespace Figure.Models
{
    public abstract class Figure : IFigure
    {
        public FigureTypeEnum FigureType { get; protected set; }
        public double Area { get; protected set; }
        public double[] Sides { get; protected set; }
        public abstract void Update(double[] sides);
        public abstract void Update(double a, double b, double c);
        public abstract void Update(double radius);
        public abstract bool IsRectangular();
    }
}
