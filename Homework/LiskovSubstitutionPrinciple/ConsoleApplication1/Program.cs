using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theBad = LiskovSubstitutionPrinciple.TheBad;
using theGood = LiskovSubstitutionPrinciple.TheGood;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * The Liskov Substitution Principle is broken here, 
             * because the behavior of the Width and Height properties changed in the descendant class. 
             * Substitution of the Square with a Rectangle gives some unexpected results.
             * The Width of the substituted ‘Rectangle’ is 2 and not the given 3. 
             * Since the behavior setting the Square property is different from the Rectangle, 
             * we can’t substitute the Square for a Rectangle.
             */
            Console.WriteLine("TheBadExample:");
            theBad.Rectangle badRectangle = new theBad.Square();
            badRectangle.Width = 3;
            badRectangle.Height = 2;

            Console.WriteLine("{0} x {1}",
                              badRectangle.Width,
                              badRectangle.Height);
            Console.WriteLine("________________________________________________________________");

            //Substitution of the Square or Rectangle with the Shape class gives the expected result.
            Console.WriteLine("TheGoodExample:");
            theGood.Shape goodRectangle = new theGood.Rectangle();
            goodRectangle.Width = 3;
            goodRectangle.Height = 2;
 
            theGood.Shape square = new theGood.Square();
            square.Width = 3;
            square.Height = 2;
            
            Console.WriteLine("Rectangle {0} x {1}",
                              goodRectangle.Width,
                              goodRectangle.Height);
 
            Console.WriteLine("Square {0} x {1}",
                              square.Width,
                              square.Height);
 
            Console.ReadLine();
            Console.ReadLine();
        }
    }
}
