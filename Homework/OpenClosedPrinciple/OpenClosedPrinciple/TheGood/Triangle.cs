using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple.TheGood
{
    /// <summary>
    /// Represents Triangle with its values.
    /// </summary>
    public class Triangle : IShape
    {
        /// <summary>
        /// Represents the length for one of this triangle sides.
        /// </summary>
        public double FirstSide { get { return _firstSide; } }
        /// <summary>
        /// Represents the length for one of this triangle sides.
        /// </summary>
        public double SecondSide { get { return _secondSide; } }
        /// <summary>
        /// Represents the length for one of this triangle sides.
        /// </summary>
        public double ThirdSide { get { return _thirdSide; } }

        private double _firstSide;
        private double _secondSide;
        private double _thirdSide;
        /// <summary>
        /// Creates new instance of this class setting the lengths for its sides.
        /// </summary>
        /// <param name="FirstSide"></param>
        /// <param name="SecondSide"></param>
        /// <param name="ThirdSide"></param>
        public Triangle(double FirstSide, double SecondSide, double ThirdSide)
        {
            _firstSide = FirstSide;
            _secondSide = SecondSide;
            _thirdSide = ThirdSide;
        }
        /// <summary>
        ///  Calculates and returns the area of this object.
        /// </summary>
        /// <returns></returns>
        public double Area()
        {
            double TotalHalf = (_firstSide + _secondSide + _thirdSide) / 2;
            return Math.Sqrt(TotalHalf * (TotalHalf - _firstSide) * (TotalHalf - _secondSide) * (TotalHalf - _thirdSide));
        }
    }
}
