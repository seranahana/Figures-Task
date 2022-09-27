namespace Figures.Library.Figures
{
    internal sealed class Triangle<T> : IFigure<T> where T : struct, IArithmetic<T>
    {
        private T _firstSide;
        private T _secondSide;
        private T _thirdSide;

        private T multiplier;

        public Triangle(T firstSide, T secondSide, T thirdSide)
        {
            if (firstSide.IsLessOrEqualsZero())
                throw new ArgumentOutOfRangeException(nameof(firstSide), "Length cannot be less than or equal zero");
            if (secondSide.IsLessOrEqualsZero())
                throw new ArgumentOutOfRangeException(nameof(secondSide), "Length cannot be less than or equal zero");
            if (thirdSide.IsLessOrEqualsZero())
                throw new ArgumentOutOfRangeException(nameof(thirdSide), "Length cannot be less than or equal zero");
            _firstSide = firstSide;
            _secondSide = secondSide;
            _thirdSide = thirdSide;
            if (!IsComposible())
            {
                throw new ArgumentException("Triangle cannot be composed");
            }
        }

        public T ComputeSquare()
        {
            if (IsRightAngled())
            {
                multiplier.SetValueFromDouble(0.5);
                return _secondSide.Multiply(_thirdSide.Multiply(multiplier));
            }
            else
            {
                multiplier.SetValueFromDouble(2);
                T halfPerimeter = _firstSide.Add(_secondSide.Add(_thirdSide)).Divide(multiplier);
                T halfPerimeterSqrt = halfPerimeter.Sqrt();
                T halfPerimeterSubstrFirstSideSqrt = halfPerimeter.Substract(_firstSide).Sqrt();
                T halfPerimeterSubstrSecondSideSqrt = halfPerimeter.Substract(_secondSide).Sqrt();
                T halfPerimeterSubstrThirdSideSqrt = halfPerimeter.Substract(_thirdSide).Sqrt();
                return halfPerimeterSqrt.Multiply(
                    halfPerimeterSubstrFirstSideSqrt.Multiply(
                        halfPerimeterSubstrSecondSideSqrt.Multiply(
                            halfPerimeterSubstrThirdSideSqrt)));
            }
        }

        private bool IsComposible()
        {
            if (_firstSide.Add(_secondSide).CompareTo(_thirdSide) != 1
                || _firstSide.Add(_thirdSide).CompareTo(_secondSide) != 1
                || _secondSide.Add(_thirdSide).CompareTo(_firstSide) != 1)
            {
                return false;
            }
            return true;
        }

        private bool IsRightAngled()
        {
            SortSidesDescending();
            if (_firstSide.Pow(2).CompareTo(_secondSide.Pow(2).Add(_thirdSide.Pow(2))) == 0)
            {
                return true;
            }
            return false;
        }

        private void SortSidesDescending()
        {
            if (_firstSide.CompareTo(_secondSide) == -1)
                (_secondSide, _firstSide) = (_firstSide, _secondSide);
            if (_firstSide.CompareTo(_thirdSide) == - 1)
                (_thirdSide, _firstSide) = (_firstSide, _thirdSide);
            if (_secondSide.CompareTo(_thirdSide) == -1)
                (_thirdSide, _secondSide) = (_secondSide, _thirdSide);
        }
    }
}
