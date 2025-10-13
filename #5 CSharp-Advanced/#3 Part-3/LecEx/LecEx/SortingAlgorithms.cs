using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecEx
{
    // Non-Generic Delegate
    //public delegate bool SortingTypesFuncDelegate(int a, int b);
    
    // Generic Delegate
    //public delegate bool SortingTypesFuncDelegate<T>(T a, T b);
    //public delegate bool SortingTypesFuncDelegate<T1, T2>(T1 a, T2 b);
    public delegate TOut SortingTypesFuncDelegate<in T1, in T2, out TOut>(T1 a, T2 b);


    internal static class SortingAlgorithms<T>
    {
        //public static void BubbleSortAsc(int[] Arr) 
        //{
        //    if(Arr?.Length > 0)            
        //        for (int i = 0; i < Arr.Length; i++) 
        //            for (int j = 0; j < Arr.Length - i - 1; j++)
        //                if (Arr[j] > Arr[j + 1])
        //                    SWAP(ref Arr[j], ref Arr[j + 1]);
           
        //}

        //public static void BubbleSortDesc(int[] Arr)
        //{
        //    if (Arr?.Length > 0)
        //        for (int i = 0; i < Arr.Length; i++)
        //            for (int j = 0; j < Arr.Length - i - 1; j++)
        //                if (Arr[j] < Arr[j + 1])
        //                    SWAP(ref Arr[j], ref Arr[j + 1]);

        //}

        public static void BubbleSort(T[] Arr, SortingTypesFuncDelegate<T, T, bool> sortingType)
        {
            if (Arr?.Length > 0 && sortingType is not null)
                for (int i = 0; i < Arr.Length; i++)
                    for (int j = 0; j < Arr.Length - i - 1; j++)
                        if (sortingType.Invoke(Arr[j], Arr[j + 1]))
                            SWAP(ref Arr[j], ref Arr[j + 1]);
        }

        private static void SWAP(ref T v1, ref T v2)
        {
            T temp = v1;
            v1 = v2;
            v2 = temp;
        }
    }
}
