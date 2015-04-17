using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrinciple.TheBad
{
    /// <summary>
    /// Represents a Square with its values that derives from Rectangle class.
    /// </summary>
    public class Square : Rectangle  
    {
        /// <summary>
        /// Sets or gets the value for Square side.
        /// </summary>
        public override int Height
        {
            get { return base.Height; }
            set { SetWidthAndHeight(value); }
        }
        /// <summary>
        /// Sets or gets the value for Square side.
        /// </summary>
        public override int Width
        {
            get { return base.Width; }
            set { SetWidthAndHeight(value); }
        }

        /// <summary>
        /// Set both sides of a square to be equal.
        /// </summary>
        /// <param name="value"></param>
 
        private void SetWidthAndHeight(int value)
        {
            base.Height = value;
            base.Width = value;
        }
    }
}
