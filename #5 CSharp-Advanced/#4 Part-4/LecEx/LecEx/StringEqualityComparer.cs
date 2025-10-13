using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecEx
{
    internal class StringEqualityComparer : IEqualityComparer<string>

    {
        //public new bool Equals(object? x, object? y)
        //{
        //    string? X = x as string;
        //    string? Y = y as string;
        //    return X?.ToLower().Equals(Y?.ToLower()) ?? false;
        //}

        //public int GetHashCode(object obj)
        //{
        //    string? value = obj as string;
        //    return value?.ToLower().GetHashCode() ?? throw new ArgumentException("Obj is not string");
        //}
        public bool Equals(string? x, string? y)
        {
            return y?.ToLower().Equals(x?.ToLower()) ?? false;
        }

        public int GetHashCode([DisallowNull] string value)
        {
            return value.ToLower().GetHashCode();
        }
    }
}
