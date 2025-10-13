using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecEx
{
    internal static class TestBuitInDelegates
    {
        public static bool CheckPositive(int number) {return number > 0;}
        public static string Casting(int number) { return number.ToString(); }
        public static void Print() { Console.WriteLine("Hello");  }
        public static void PrintName(string name) { Console.WriteLine($"Hello {name}") ; }


    }
}
