using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple.TheGood
{
    /// <summary>
    /// Represents a Circle with its values.
    /// </summary>
    public class Circle : IShape
    {
        /// <summary>
        /// Represents the length of the Radius element of this circle.
        /// </summary>
        public double Radius { get { return _radius; } }

        private double _radius;
        /// <summary>
        /// Creates new instance of this class setting the value of Radius member.
        /// </summary>
        /// <param name="radius"></param>
        public Circle(double radius)
        {
            _radius = radius;
        }
        /// <summary>
        /// Calculates and returns the area of this object.
        /// </summary>
        /// <returns></returns>
        public double Area()
        {
            return _radius * _radius * Math.PI;
        }
    }
}
