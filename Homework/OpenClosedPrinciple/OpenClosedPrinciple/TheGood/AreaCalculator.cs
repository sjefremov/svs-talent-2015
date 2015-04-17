using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple.TheGood
{
    /// <summary>
    /// Represents a calculator for operations with areas.
    /// </summary>
    public class AreaCalculator
    {
        /// <summary>
        /// Calculates and returns the sum of shape areas.
        /// </summary>
        /// <param name="shapes"></param>
        /// <returns></returns>
        public double Area(IShape[] shapes)
        {
            double area = 0;

            foreach (var shape in shapes)
            {
                area += shape.Area();
            }

            return area;
        }
    }
}
