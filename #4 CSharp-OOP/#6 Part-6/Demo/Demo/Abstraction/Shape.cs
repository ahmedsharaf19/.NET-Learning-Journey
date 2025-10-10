using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Abstraction
{
    // Abstract Class : Is a Container For a common code for other classes
    // Common Code => [Fully Implemented Members - Abstracted Members]
    internal abstract class Shape

    {
        protected Shape(decimal dim01, decimal dim02)
        {
            Dim01 = dim01;
            Dim02 = dim02;
        }

        public decimal Dim01 { get; set; }
        public decimal Dim02 { get; set; }


        // Abstract Method
        public abstract decimal CalcArea();

        // Abstract Property
        public abstract decimal Perimeter { get;  }
    }

    abstract class RecBase : Shape
    {
        protected RecBase(decimal dim01, decimal dim02): base(dim01, dim02)
        {
             
        }
        public override decimal CalcArea()
        {
            return Dim01 * Dim02;
        }
    }

    // Concreate Class : Fully Implemented Class
    class Rectangle : RecBase
    {
        public Rectangle(decimal dim01, decimal dim02) : base(dim01, dim02)
        {
             
        }
        public override decimal Perimeter 
        {
            get { return Dim01 * Dim02 * 2; }
        }

    }

    // Concreate Class 
    class Square : RecBase, ITwoDDraw, IThreeDDraw
    {
        public Square(decimal side) : base(side, side)
        {
        }

        public override decimal Perimeter
        {
            get { return Dim01 * 4; }
        }

        void IThreeDDraw.Draw()
        {
            throw new NotImplementedException();
        }

        void ITwoDDraw.Draw()
        {
            throw new NotImplementedException();
        }
    }

    class Circle : Shape, ITwoDDraw
    {
        public Circle(decimal radius): base(radius, radius)
        {

        }
        public override decimal Perimeter
        {
            get { return 2 * Dim01 * (decimal)Math.PI; }
        }

        public override decimal CalcArea()
        {
            return (decimal)Math.PI * Dim01 * Dim02;
        }

        void ITwoDDraw.Draw()
        {
            throw new NotImplementedException();

        }
    }

    class Triangle : Shape
    {
        public decimal Dim03 { get; set; }

        public override decimal Perimeter => throw new NotImplementedException();

        public Triangle(decimal dim01, decimal dim02, decimal dim03) : base(dim01, dim02)
        {
            Dim03 = dim03;
        }

        public override decimal CalcArea()
        {
            throw new NotImplementedException();
        }
    }
    interface ITwoDDraw
    {
        void Draw()
        {

        }
    }

    interface IThreeDDraw
    {
        void Draw()
        {

        }
    }

        
}


