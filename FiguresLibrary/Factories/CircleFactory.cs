using Figures.Library.Figures;

namespace Figures.Library.Factories
{
    public static class CircleFactory
    {
        public static IFigure<T> Create<T>(T radius) where T : struct, IArithmetic<T>
        {
            return new Circle<T>(radius);
        }
    }
}
