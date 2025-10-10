using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Interface
{
    internal interface IType
    {
        // 1. Signature For Property
        public int MyProperty { get; set; }

        // 2. Signature For Method
        public void MyMethod();

        // 3. Default Implemented Method [C#8.0]
        public void Print()
        {
            Console.WriteLine("Hello From Default Implemented Method");
        }
    }
}
