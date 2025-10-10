using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Overriding
{
    internal class TypeA
    {
        #region Properties
        public int A { get; set; }
        #endregion

        #region Constructors
        public TypeA(int a)
        {
            A = a;
        }
        #endregion

        #region Methods
        // Non Virtual Method
        public void MyFun01()
        {
            Console.WriteLine("This Is MyFun01 From Base And I Am Base");
        }

        // Virtual Method
        public virtual void MyFun02() 
        {
            Console.WriteLine($"This is MyFun02 From Base And TypeA : A = {A}");
        }
        #endregion
    }
}
