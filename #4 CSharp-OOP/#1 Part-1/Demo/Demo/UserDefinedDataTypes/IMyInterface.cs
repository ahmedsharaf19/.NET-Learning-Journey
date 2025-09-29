using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.UserDefinedDataTypes
{
    internal interface IMyInterface
    {
        // What We Can Write Inside Interface ?
        // 1. Signiature For Prpoerty => c#7
        public int MyProperty { get; set; }

        // 2. Signature For Method => C#7
        public void MyFunction();
        // can not use private as access modifier

        // 3. Default Implemented Method => C#8
        private void MyFunction2()
        {
            Console.WriteLine(MyProperty);
        }
        
    }
}
