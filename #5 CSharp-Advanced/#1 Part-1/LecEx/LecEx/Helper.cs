using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecEx
{
    internal static class Helper<T> where T : IEquatable<T>, IComparable<T>
    {

        public static void BubbleSort(T[] array) 
        {
            if (array is null) return;

            for(int i = 0; i < array.Length; i++) 
            {
                for (int j = 0; j < array.Length - 1 - i; j++) 
                {
                    // Operator '>' is not existed in all data types
                    if (array[j].CompareTo(array[j + 1]) > 0) 
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }






        public static void BubbleSort(T[] array, IComparer<T> comparer)
        {
            if (array is null) return;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (comparer.Compare(array[j], array[j+1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }
















        #region Swap
        //public static void Swap(ref int x, ref int y)
        //{
        //    int temp = x; 
        //    x = y;
        //    y = temp;
        //}

        //public static void Swap (ref decimal m , ref decimal n) 
        //{
        //    decimal temp = m;
        //    m = n;
        //    n = temp;
        //}

        //public static void Swap(ref Point x, ref Point y)
        //{
        //    Point temp = x;
        //    x = y;
        //    y = temp;
        //}

        // Generic Method
        // As Generic Type '<T>' is defiend on method level
        // Compiler Can Auotmatically Detect Type of T Based on Type of Passed Parameters

        public static void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }
        #endregion

        // Generic Method
        //public static int LinearSearch(T[] arr, T value)
        //{
        //    //if (arr is not null && arr.Length > 0 && value is not null)
        //    if (arr?.Length > 0 && value is not null)

        //    {
        //        for (int i = 0; i < arr.Length; i++)
        //        {
        //            // Operator '==' cannot be applied to operand of type 'T' and 'T'
        //            // not all types contains '==' operator such as user defined struct
        //            //if (arr[i] == value) 
        //            //if (arr[i]?.Equals(value) ?? false)
        //            if (value.Equals(arr[i]))
        //                return i;
        //        }
        //    }   
        //    return -1;
        //}

        public static int LinearSearch(T[] arr, T value, IEqualityComparer<T> equalityComparer)
        {
            if (arr?.Length > 0 && value is not null)

            {
                for (int i = 0; i < arr.Length; i++)
                { 
                    if (equalityComparer.Equals(value, arr[i]))
                        return i;
                }
            }
            return -1;
        }
    }
}
