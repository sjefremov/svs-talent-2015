using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrinciple.TheBad
{
    /// <summary>
    /// Represents a Rectangle with its values.
    /// </summary>
    public class Rectangle
    {
        /// <summary>
        /// Sets or gets length for one of this Rectangle sides.
        /// </summary>
        public virtual int Width { get; set; }
        /// <summary>
        /// Sets or gets the length for one of this Rectangle sides.
        /// </summary>
        public virtual int Height { get; set; }
    }  
}
