using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple.TheBad
{
    /// <summary>
    /// Represents a calculator for operations with areas.
    /// </summary>
    public class AreaCalculator
    {
        
        /* The AreaCalculator violates the open closed principle because, a new requirement for this code will always consist 
        * of a change in calculation of a certain existing shape or a new shape is introduced.
        * In both cases the AreaCalculator has to be changed and therefore not closed for modification.
        * It is also not open for extension because we can not extend the functionality of the AreaCalulator without modifying it.
        */
        /// <summary>
        /// Calculates the sum of all shape areas.
        /// </summary>
        /// <param name="shapes"></param>
        /// <returns></returns>
        public double Area(object[] shapes)
        {
            double area = 0;

            foreach (var shape in shapes)
            {

                if (shape is Square)
                {
                    Square square = (Square)shape;
                    area += Math.Sqrt(square.Height);
                }

                if (shape is Triangle)
                {
                    Triangle triangle = (Triangle)shape;
                    double TotalHalf = (triangle.FirstSide + triangle.SecondSide + triangle.ThirdSide) / 2;
                    area += Math.Sqrt(TotalHalf * (TotalHalf - triangle.FirstSide) *
                    (TotalHalf - triangle.SecondSide) * (TotalHalf - triangle.ThirdSide));
                }

                if (shape is Circle)
                {
                    Circle circle = (Circle)shape;
                    area += circle.Radius * circle.Radius * Math.PI;
                }

            }
            return area;
        }
    }
}
