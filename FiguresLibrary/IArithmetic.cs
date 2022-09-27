namespace Figures.Library
{
    public interface IArithmetic<T> : IComparable<T> where T : struct
    {
        bool IsLessOrEqualsZero();
        void SetValueFromDouble(double value);

        T Add(T addend);
        T Substract(T subtrahend);
        T Multiply(T multiplier);
        T Divide(T divisor);

        T Sqrt();
        T Pow(double power);
    }
}
