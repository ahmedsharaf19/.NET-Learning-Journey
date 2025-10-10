using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Static
{
    internal class Utility
    {
        public int X { get; set; }
        public int Y { get; set; }

        static Utility()
        {
            // Used To Initialized Static Fields
            Console.WriteLine("Static Constructor");
            pi = 3.14; // valid [static readonly attribute]
        }

        public Utility(int x, int y)
        {
            X = x;
            Y = y;
        }

        //// Object Member Method - Non Static Member Method
        //public double MeterToCm(double value)
        //{
        //    return value * 100;
        //}

        // Class Member Attribute - Static Attribute
        //static readonly private double pi = 3.14;
        static readonly private double pi;
        //// Assigned By CLR At Runtime
        //// CLR Will Initialize Every And Each Static Attribute With Default Value of is its
        //// Before First Use of class
        //// Uses Of class
        //// 1. Create Object From Class
        //// 2. Create Object From Class Inherit From My Class
        //// 3. Before Any Static Member Accessed

        //private const double pi = 3.14; // Must Initialize At This Point [Declaration]
        // can not be assigned a value in a constructor [static - non static]
        // Class Member Property - Static Property
        public static double Pi // readonly property
        {
            get { return pi; }
            //set { pi = value; }
        }

        // Class Member Method - Static Member Method
        static public double MeterToCm(double value)
        {
            return value * 100;
        }


        static public double CalculateCircleArea(double Radius)
        {
            return Math.Pow(Radius, 2) * pi;
            
        }
    }
}
