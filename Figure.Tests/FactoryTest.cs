using Figure.Interfaces;
using Figure.Models;
using NUnit.Framework;

namespace Figure.Tests
{
    public class FactoryTest
    {
        private IFigure _positiveDouble;
        private IFigure _negativeDouble;
        private IFigure _zeroDouble;
        private IFigure _onePositiveElementDoubleArray;
        private IFigure _oneNegativeElementDoubleArray;
        private IFigure _manyPositiveElementsDoubleArray;
        private IFigure _manyElementsDoubleArrayForRectangularTriangle;
        private IFigure _imposibleToCreateTriangleArray;
        private IFigure _undefinedLengthOfArray;
        private IFigure _emptyArray;
        private IFigure _arrayIsNull;
        private IFigureFactory _factory;

        [SetUp]
        public void Setup()
        {
            _factory = new FigureFactory();

            _positiveDouble = _factory.CreateFigure(3);
            //_negativeDouble = _factory.CreateFigure(-5);
            //_zeroDouble = _factory.CreateFigure(0);
            _onePositiveElementDoubleArray = _factory.CreateFigure(new double[] { 5 });

            //_imposibleToCreateTriangleArray = _factory.CreateFigure(new double[] { 6, 3, 3 });
            _manyPositiveElementsDoubleArray = _factory.CreateFigure(new double[] { 5, 5, 8 });
            //_oneNegativeElementDoubleArray = _factory.CreateFigure(new double[] { 5, -4, 3 });
            _manyElementsDoubleArrayForRectangularTriangle = _factory.CreateFigure(new double[] { 5, 4, 3 });


            //_undefinedLengthOfArray = _factory.CreateFigure(new double[int.MaxValue]);

            //_emptyArray = _factory.CreateFigure(3);
            //_arrayIsNull = _factory.CreateFigure(3);
        }

        [Test]
        public void CircleTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_positiveDouble.FigureType, Is.EqualTo(FigureTypeEnum.Circle));
                Assert.That(_positiveDouble.Area, Is.EqualTo(Math.PI * 3 * 3));

                Assert.Throws<ArgumentException>(() => _negativeDouble = _factory.CreateFigure(-5),
                    "Every parameter must be greater than zero");

                Assert.Throws<ArgumentException>(() => _zeroDouble = _factory.CreateFigure(0),
                    "Every parameter must be greater than zero");

                Assert.That(_onePositiveElementDoubleArray.Area, Is.EqualTo(Math.PI * 5 * 5));
                Assert.That(_onePositiveElementDoubleArray.FigureType, Is.EqualTo(FigureTypeEnum.Circle));
            });
        }

        [Test]
        public void TriangleTest()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_manyPositiveElementsDoubleArray.FigureType, Is.EqualTo(FigureTypeEnum.Triangle));
                Assert.That(_manyPositiveElementsDoubleArray.Area, Is.EqualTo(12));
                Assert.That(_manyPositiveElementsDoubleArray.IsRectangular(), Is.False);

                Assert.Throws<ArgumentException>(() => _imposibleToCreateTriangleArray = _factory.CreateFigure(new double[] { 6, 3, 3 }),
                    "It is impossible to create a triangle with such sides");

                Assert.Throws<ArgumentException>(() => _oneNegativeElementDoubleArray = _factory.CreateFigure(new double[] { 5, -4, 3 }),
                    "Every parameter must be greater than zero");

                Assert.That(_manyElementsDoubleArrayForRectangularTriangle.FigureType, Is.EqualTo(FigureTypeEnum.Triangle));
                Assert.That(_manyElementsDoubleArrayForRectangularTriangle.Area, Is.EqualTo(6));
                Assert.That(_manyElementsDoubleArrayForRectangularTriangle.IsRectangular(), Is.True);
            }); 
        }

        [Test]
        public void BadArrayTest()
        {
            Assert.Multiple(() =>
            {
                Assert.Throws<ArgumentException>(() => _undefinedLengthOfArray = _factory.CreateFigure(new double[100]),
                    "It was not possible to create a figure for a given number of array elements");

                Assert.Throws<ArgumentException>(() => _emptyArray = _factory.CreateFigure(new double[] { }),
                    "It was not possible to create a figure for a given number of array elements");

                Assert.Throws<ArgumentException>(() => _arrayIsNull = _factory.CreateFigure(null),
                    "You need to pass an initialized array to create a figure");
            });
        }
    }
}
