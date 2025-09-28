using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecEx
{

    class MyClass : Object // Inheritance
    {
        public void Print<T>(T item) // Gerneric (T stand For Template)
        {
            Console.WriteLine(item);
        }

        public void TestPrint()
        {
            Print<int>(100);
            Print<string>("Ahmed");
            Print<char>('A');
            Print<bool>(true);
        }

        public void PrintWithObject(object item)
        {
            Console.WriteLine(item);
        }
        public void TestPrintWithObject()
        {
            PrintWithObject(100);
            PrintWithObject("Ahmed");
            PrintWithObject('A');
            PrintWithObject(true);
        } 

    }

    //enum MyEnum
    //{

    //}

    //struct MyStruct
    //{

    //}

    //interface MyInterface
    //{

    //}
}
