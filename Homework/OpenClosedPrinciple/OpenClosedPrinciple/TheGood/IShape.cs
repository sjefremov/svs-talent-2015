using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple.TheGood
{
    /// <summary>
    /// Represents abstraction of shapes.
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Calculates and returns the area of the appropriate shape.
        /// </summary>
        /// <returns></returns>
        double Area();
    }
}
