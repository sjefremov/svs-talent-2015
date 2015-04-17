using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple.TheGood
{
    /// <summary>
    /// Represents a Square with its values.
    /// </summary>
    public class Square : IShape
    {
        /// <summary>
        /// Represents the length for one of this square sides.
        /// </summary>
        public double Height { get { return _height; } }
        private double _height;
        /// <summary>
        /// Creates new instance of this class setting the value of Height member.
        /// </summary>
        /// <param name="height"></param>
        public Square(double height)
        {
            _height = height;
        }
        /// <summary>
        ///  Calculates and returns the area of this object.
        /// </summary>
        /// <returns></returns>
        public double Area()
        {
            return _height * _height;
        }
    }
}
