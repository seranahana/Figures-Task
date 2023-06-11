namespace Figures.Library
{
    public struct ArithmeticDouble : IArithmetic<ArithmeticDouble>
    {
        public double Value { get; set; }

        public static ArithmeticDouble MaxValue 
        { 
            get 
            {
                return new ArithmeticDouble(double.MaxValue);
            }
        }

        public ArithmeticDouble(double value) : this()
        {
            Value = value;
        }

        public bool IsLessOrEqualsZero()
        {
            return Value <= 0;
        }

        public void SetValueFromDouble(double value)
        {
            Value = value;
        }

        public ArithmeticDouble Add(ArithmeticDouble addend)
        {
            double s = Value + addend.Value;
            if (double.IsInfinity(s) || double.IsNaN(s))
            {
                throw new OverflowException();
            }
            return new ArithmeticDouble(s);
        }

        public ArithmeticDouble Divide(ArithmeticDouble divisor)
        {
            double s = Value / divisor.Value;
            if (double.IsInfinity(s) || double.IsNaN(s))
            {
                throw new OverflowException();
            }
            return new ArithmeticDouble(s);
        }

        public ArithmeticDouble Multiply(ArithmeticDouble multiplier)
        {
            double s = Value * multiplier.Value;
            if (double.IsInfinity(s) || double.IsNaN(s))
            {
                throw new OverflowException();
            }
            return new ArithmeticDouble(s);
        }

        public ArithmeticDouble Substract(ArithmeticDouble subtrahend)
        {
            double s = Value - subtrahend.Value;
            if (double.IsInfinity(s) || double.IsNaN(s))
            {
                throw new OverflowException();
            }
            return new ArithmeticDouble(s);
        }

        public ArithmeticDouble Sqrt()
        {
            double s = Math.Sqrt(Value);
            if (double.IsInfinity(s) || double.IsNaN(s))
            {
                throw new OverflowException();
            }
            return new ArithmeticDouble(s);
        }

        public ArithmeticDouble Pow(double power)
        {
            double s = Math.Pow(Value, power);
            if (double.IsInfinity(s) || double.IsNaN(s))
            {
                throw new OverflowException();
            }
            return new ArithmeticDouble(s);
        }

        public int CompareTo(ArithmeticDouble value)
        {
            if (Value < value.Value) return -1;
            if (Value > value.Value) return 1;
            if (Value == value.Value) return 0;

            // At least one of the values is NaN.
            if (double.IsNaN(Value))
                return (double.IsNaN(value.Value) ? 0 : -1);
            else
                return 1;
        }
    }
}
