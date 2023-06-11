using Figures.Library.Figures;

namespace Figures.Library.Factories
{
    public static class TriangleFactory
    {
        public static IFigure<T> Create<T>(T firstSide, T secondSide, T thirdSide) where T : struct, IArithmetic<T>
        {
            return new Triangle<T>(firstSide, secondSide, thirdSide);
        }
    }
}
