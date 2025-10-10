using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Overriding
{
    internal class TypeB : TypeA
    {
        #region Properties
        public int B { get; set; }
        #endregion

        #region Constructors
        public TypeB(int a, int b) : base(a)
        {
            B = b;
        }
        #endregion

        #region Methods
        // Using "New" To Hiding Inherited Member TypeA.MyFun01() [New Version - Masking]
        public new void MyFun01()
        {
            Console.WriteLine("This is MyFun01 From Derived [Child]");
        }

        // Using Keyword "Override" To Override Inherited Member TypeA.MyFun02()
        // TypeA.MyFun02() Must Be Marked As Virtual Method and Non-Private in its first apperance
        // Dynamic Polymorphism [Run-Time]
        public override void MyFun02()
        {
            Console.WriteLine($"This is MyFun02 From Derived TypeB : A = {A} , B = {B}");
        }
        #endregion
    }
}
