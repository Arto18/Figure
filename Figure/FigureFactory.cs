using Figure.Interfaces;
using Figure.Models;

namespace Figure
{
    public class FigureFactory : IFigureFactory
    {
        public IFigure CreateFigure(double radius)
        {
            return CreateFigure(new double[] {radius});
        }

        public IFigure CreateFigure(double a, double b, double c)
        {
            return CreateFigure(new double[] { a, b, c});
        }

        public IFigure CreateFigure(double[] sides)
        {
            if (sides == null)
            {
                throw new ArgumentException("You need to pass an initialized array to create a figure");
            }

            foreach (var side in sides)
            {
                if (side <= 0)
                    throw new ArgumentException("Every parameter must be greater than zero");
            }

            switch (sides.Length)
            {
                case 0:
                    throw new ArgumentException("You need to pass a non-empty array to create a figure");
                case 1:
                    return new Circle(sides);
                case 3:
                    if (sides[0] + sides[1] <= sides[2] ||
                    sides[0] + sides[2] <= sides[1] ||
                    sides[2] + sides[1] <= sides[0])
                    {
                        throw new ArgumentException("It is impossible to create a triangle with such sides");
                    }
                    return new Triangle(sides);
                default:
                    throw new ArgumentException("It was not possible to create a figure for a given number of array elements");
            }
        }
    }
}
