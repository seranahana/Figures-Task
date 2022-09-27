using Figures.Library.Factories;
using Figures.Library.Figures;
using System;
using Xunit;

namespace Figures.Library.UnitTests
{
    public class CircleUnitTests
    {
        [Fact]
        public void TestOverflowingValue()
        {
            IFigure<ArithmeticDouble> circle = CircleFactory.Create(ArithmeticDouble.MaxValue);

            Assert.Throws<OverflowException>(() => circle.ComputeSquare());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void TestZeroOrLessThanZeroValues(double radiusDouble)
        {
            ArithmeticDouble radius = new(radiusDouble);

            Assert.Throws<ArgumentOutOfRangeException>(() => CircleFactory.Create(radius));
        }

        [Theory]
        [InlineData(10, 314.1592653589793)]
        [InlineData(77, 18626.502843133883)]
        [InlineData(37, 4300.840342764427)]
        [InlineData(14, 615.7521601035994)]
        [InlineData(41, 5281.017250684442)]
        [InlineData(64, 12867.963509103793)]
        [InlineData(55, 9503.317777109125)]
        public void TestRandomValuesInRangeFromOneToHundred(double radiusDouble, double square)
        {
            IFigure<ArithmeticDouble> circle = CircleFactory.Create<ArithmeticDouble>(new(radiusDouble));

            ArithmeticDouble expected = new(square);

            ArithmeticDouble actual = circle.ComputeSquare();

            Assert.Equal(expected.Value, actual.Value, 0.000001);
        }
    }
}
