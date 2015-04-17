using System;
namespace LiskovSubstitutionPrinciple.TheGood
{
    /// <summary>
    /// Represents a shape with values for two members.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Sets or gets length for one of this Shape sides.
        /// </summary>
        public abstract int Height { get; set; }
        /// <summary>
        /// Sets or gets length for one of this Shape sides.
        /// </summary>
        public abstract int Width { get; set; }
    }
}
