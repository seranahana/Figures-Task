namespace Figures.Library.Figures
{
    internal sealed class Circle<T> : IFigure<T> where T : struct, IArithmetic<T>
    {
        private T _radius;
        private T pi;

        public Circle(T radius)
        {
            if (radius.IsLessOrEqualsZero())
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius cannot be less than or equal zero");
            _radius = radius;
            pi.SetValueFromDouble(Math.PI);
        }

        public T ComputeSquare()
        {
            return pi.Multiply(_radius.Multiply(_radius));
        }
    }
}
