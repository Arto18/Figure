namespace Figure.Interfaces
{
    public interface IFigureFactory
    {
        IFigure CreateFigure(double radius);
        IFigure CreateFigure(double[] sides);
        IFigure CreateFigure(double a, double b, double c);
    }
}
