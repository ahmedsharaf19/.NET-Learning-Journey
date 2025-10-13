using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecEx
{
    internal class StringComparer : IComparer<string>
    {
        public int Compare(string? x, string? y) => y?.CompareTo(x) ?? -1;
        


    }
}
