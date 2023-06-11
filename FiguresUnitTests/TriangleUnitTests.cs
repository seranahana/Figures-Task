using Figures.Library.Factories;
using Figures.Library.Figures;
using System;
using Xunit;

namespace Figures.Library.UnitTests
{
    public class TriangleUnitTests
    {
        [Fact]
        public void TestOverflowingValue()
        {
            Assert.Throws<OverflowException>(() => TriangleFactory.Create(ArithmeticDouble.MaxValue, ArithmeticDouble.MaxValue, ArithmeticDouble.MaxValue));
        }

        [Theory]
        [InlineData(1 ,4 ,6)]
        [InlineData(7 ,4 ,2)]
        [InlineData(5 ,10 ,4)]
        [InlineData(100, 1 , 1)]
        [InlineData(4, 4, 8)]
        public void TestImcomposibleTriangles(double firstSideDouble, double secondSideDouble, double thirdSideDouble)
        {
            ArithmeticDouble firstSide = new(firstSideDouble);
            ArithmeticDouble secondSide = new(secondSideDouble);
            ArithmeticDouble thirdSide = new(thirdSideDouble);

            Assert.Throws<ArgumentException>(() => TriangleFactory.Create(firstSide, secondSide, thirdSide));
        }

        [Theory]
        [InlineData(9, 0 , 5)]
        [InlineData(10, 8 , -1)]
        public void TestZeroOrLessThanZeroValues(double firstSideDouble, double secondSideDouble, double thirdSideDouble)
        {
            ArithmeticDouble firstSide = new(firstSideDouble);
            ArithmeticDouble secondSide = new(secondSideDouble);
            ArithmeticDouble thirdSide = new(thirdSideDouble);

            Assert.Throws<ArgumentOutOfRangeException>(() => TriangleFactory.Create(firstSide, secondSide, thirdSide));
        }

        [Theory]
        [InlineData(3, 5, 4, 6)]
        [InlineData(25, 24, 7, 84)]
        [InlineData(29, 20, 21, 210)]
        [InlineData(28, 45, 53, 630)]
        [InlineData(11, 60, 61, 330)]
        [InlineData(55, 73, 48, 1320)]
        public void TestRightAngledTriangles(double firstSideDouble, double secondSideDouble, double thirdSideDouble, double square)
        {
            IFigure<ArithmeticDouble> triangle = TriangleFactory.Create<ArithmeticDouble>(new(firstSideDouble), new(secondSideDouble), new(thirdSideDouble));

            ArithmeticDouble expected = new(square);

            ArithmeticDouble actual = triangle.ComputeSquare();

            Assert.Equal(expected.Value, actual.Value, 0.000001);   
        }

        [Theory]
        [InlineData(5, 8, 5, 12)]
        [InlineData(7, 15, 20, 42)]
        [InlineData(13, 11, 20, 66)]
        [InlineData(15, 13, 14, 84)]
        [InlineData(21, 17, 10, 84)]
        [InlineData(4, 53, 51, 90)]
        [InlineData(17, 17, 30, 120)]
        [InlineData(20, 37, 19, 114)]
        public void TestNonRightAngledTriangles(double firstSideDouble, double secondSideDouble, double thirdSideDouble, double square)
        {
            IFigure<ArithmeticDouble> triangle = TriangleFactory.Create<ArithmeticDouble>(new(firstSideDouble), new(secondSideDouble), new(thirdSideDouble));

            ArithmeticDouble expected = new(square);

            ArithmeticDouble actual = triangle.ComputeSquare();

            Assert.Equal(expected.Value, actual.Value, 0.000001);
        }
    }
}
