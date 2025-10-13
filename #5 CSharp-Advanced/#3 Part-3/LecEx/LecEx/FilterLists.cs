using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecEx
{
    public delegate bool FilterFuncDelegate<T>(T a);
    internal static class FilterLists
    {
        //public static List<int> FindOddNumbers(List<int> numbers)
        //{
        //    List<int> Result = new List<int> ();
        //    if(numbers?.Count > 0)
        //        for(int i = 0; i < numbers.Count; i++) 
        //            if (numbers[i] % 2 != 0)
        //                Result.Add (numbers[i]);

        //    return Result;
        //}

        //public static List<int> FindEvenNumbers(List<int> numbers)
        //{
        //    List<int> Result = new List<int>();
        //    if (numbers?.Count > 0)
        //        for (int i = 0; i < numbers.Count; i++)
        //            if (numbers[i] % 2 == 0)
        //                Result.Add(numbers[i]);

        //    return Result;
        //}

        public static List<T> FindElements<T>(List<T> elements, FilterFuncDelegate<T> filter)
        {
            List<T> Result = new List<T>();
            if (elements?.Count > 0 && filter is not null)
                for (int i = 0; i < elements.Count; i++)
                    if (filter.Invoke(elements[i]))
                        Result.Add(elements[i]);

            return Result;
        }
    }
}
