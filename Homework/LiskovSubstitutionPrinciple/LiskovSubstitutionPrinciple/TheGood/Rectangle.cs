using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrinciple.TheGood
{
    /// <summary>
    /// Represents a Rectangle with its values.
    /// </summary>
    public class Rectangle:Shape
    {
        /// <summary>
        /// Sets or gets length for one of this Rectangle sides.
        /// </summary>
        public override int Width { get; set; }
        /// <summary>
        /// Sets or gets the length for one of this Rectangle sides.
        /// </summary>
        public override int Height { get; set; }
    }  
}
