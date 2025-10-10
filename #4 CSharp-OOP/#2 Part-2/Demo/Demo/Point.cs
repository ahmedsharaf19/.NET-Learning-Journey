using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    internal struct Point
    {
        #region Attributes
        public int X;
        public int Y;
        #endregion

        #region Constructor
        // Special Function
        // Always Name With Class | Struct Name
        // No Return Type

        #region Default Constructor
        // Default Constructor Created By Complier Automatically
        //public Point()
        //{
        //    X = default;
        //    Y = default;
        //}
        #endregion

        #region UserDefinedConstructor

        #region Constructor Overloading
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point(int number)
        {
            X = Y = number;
        }
        #endregion

        #endregion

        #endregion

        #region Methods
        #region Override ToString()
        public override string ToString()
        {
            return $"({X},{Y})";
        }
        #endregion
        #endregion
    }
}
