using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecEx
{
    internal class SortingTypes
    {
        //public static bool CompareGreater(int x, int y)
        //    { return x > y; }

        //public static bool CompareLess(int x, int y)
        //{ return x < y; }

        public static bool SortAsc(int x, int y)
        { return x > y; }

        public static bool SortDesc(int x, int y)
        { return x < y; }
        public static bool SortAsc(string x, string y)
        { return x?.Length > y?.Length; }

        public static bool SortDesc(string x, string y)
        { return x?.Length < y?.Length; }
    }
}
