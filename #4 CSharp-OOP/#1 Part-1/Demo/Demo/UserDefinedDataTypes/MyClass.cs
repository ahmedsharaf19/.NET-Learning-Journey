using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.UserDefinedDataTypes
{
    internal class MyClass
    {
        // What You Can Write Inside Class ?
        // 1. Attributes 
        int myAttributes; // Attribute With Private Access Modifier [Default]

        // 2. Functions
        internal void MyFunction()
        {
            Console.WriteLine(myAttributes);
        }

        // 3. Properties 
        public int MyProperty {  get; set; } // Property with public access modifier

        // 4. Events
    }
}
