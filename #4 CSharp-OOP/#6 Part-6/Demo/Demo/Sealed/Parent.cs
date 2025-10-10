using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Sealed
{
    internal class Parent
    {
        private int salary;

        public virtual int Salary
        {
            get { return salary; }
            set { salary = value + 1000; }
        }
        public virtual void MyFun()
        {
            Console.WriteLine("I am Parent");
        }
    }

    class Child : Parent
    {
        public sealed override int Salary 
        { 
            get { return base.Salary; }
            set { base.Salary = value + 2000; }
        }
        public sealed override void MyFun() // class inherit from child can not override on this function
        {
            Console.WriteLine("I am Child");
        }
    }

    sealed class GrandChild : Child
    {
        // can not be overriden because is a sealed method
        //public override void MyFun() // invalid
        //{
        //    Console.WriteLine("I am Grand Child");
        //}

        public new int Salary
        {
            get { return base.Salary; }
            set { base.Salary = value + 2000; }
        }
    }

    // Invalid
    //class Test : GrandChild
    //{ 
    //}
}
