using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecEx
{
    internal static class FiltersOfList
    {
        public static bool CheckOdd(int number)
        {
            return (number % 2 != 0);
        }

        public static bool CheckEven(int number)
        {
            return (number % 2 == 0);
        }

        public static bool DivisbleBy7(int number)
        {
            return (number % 7 == 0);
        }

        public static bool DivisbleBy10(int number)
        {
            return (number % 10 == 0);
        }

        public static bool CheckLength(string s)
        {
            return s?.Length > 4;
        }

        public static bool CheckLengthLessThan4(string s)
        {
            return s?.Length < 4;
        }
    }
}
