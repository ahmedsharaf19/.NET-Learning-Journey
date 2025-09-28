using System.Globalization;
using System.Linq.Expressions;

namespace LecEx
{
    internal class Program
    {

        //public static void Swap(int x, int y) 
        //{
        //    int temp = x;
        //    x = y;
        //    y = temp;
        //}

        public static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        //public static int SumArray(int[] arr) 
        //{
        //    int sum = 0;
        //    foreach (int element in arr) 
        //        sum += element;

        //    return sum; 
        //}

        //public static int SumArray(int[] arr)
        //{
        //    int sum = 0;
        //    if (arr is not null)
        //    {
        //        foreach (int element in arr)
        //            sum += element;
        //    }
        //    return sum;
        //}

        //public static int SumArray(ref int[] arr)
        //{
        //    int sum = 0;
        //    if (arr is not null)
        //    {
        //        arr[0] = 100;
        //        foreach (int element in arr)
        //            sum += element;
        //    }
        //    return sum;
        //}

        //public static int SumArray( int[] arr)
        //{
        //    int sum = 0;
        //    if (arr is not null)
        //    {
        //        arr = new int[] { 10, 20, 30, 40 };
        //        foreach (int element in arr)
        //            sum += element;
        //    }
        //    return sum;
        //}

        //public static int SumArray(ref int[] arr)
        //{
        //    int sum = 0;
        //    if (arr is not null)
        //    {
        //        arr = new int[] { 10, 20, 30, 40 };
        //        foreach (int element in arr)
        //            sum += element;
        //    }
        //    return sum;
        //}



        public static int SumArray(params int[] arr)
        {
            int sum = 0;
            if (arr is not null)
                foreach (int element in arr)
                    sum += element;
            return sum;
        }


        public static void Concat<T>(params ReadOnlySpan<T> items)
        {
            for(int i = 0; i < items.Length; i++)
            {
                Console.Write($"{items[i]} ");
            }
        }

        public static void SumSub(int x, int y, out int sum, out int sub)
        {
            sum = x + y;
            sub = x - y;
            // return sum, sub; // invalid
            //return sum;
            //return sub; // invalid [unreachable code]
            // solution 1 [return array] 
            // return new int[] {sum, sub }; // return array
            // return [sum, sub]; // return array (short hand)
            // solution 2 - create user defined data type
            //return new DataToReturn() { sum = sum, sub = sub };
            // solution 3 - using anonymous type
            //return new { sum, sub }; //return object from  anonymous type (compiler will generate class in run time
            // solution 4 - using out

        }
        static void Main(string[] args)
        {
            #region Array Methods

            #region Class Memeber Methods 
            //int[] numbers = { 5, 6, 4, 3, 2, 1, 4, 5 };
            // Array.Sort(numbers); // sort array asc using IComparable (built in interface)
            // 1, 2, 3, 4, 4, 5, 5, 6
            // Array.Reverse(numbers); // Reverse sequence - reverse arrangement
            // Array.Clear(numbers); // clear all elements in array (all content = zero) default value
            // Array.Clear(numbers, 1, 4); // set default value for each element in array start from index 1 and 4 element
            //int indexOf4 = Array.IndexOf(numbers, 4); // search in array and return first occurence of number 4, if not found return -1
            //Console.WriteLine(Array.LastIndexOf(numbers, 4)); // return last occurenee of 4
            //Array.CreateInstance(typeof(int), 5); // create instance from 1D Array with type and length
            //// equal to 
            //int[] num = new int[5];
            // Array.Resize(ref numbers, 10); // create new array and copy element from old array to new array
            //Array.BinarySearch(numbers, 5);// Sort Array First and then return index of elemeny
            //int[] Arr01 = { 1, 2, 3, 4, 5 };
            //int[] Arr02 = new int[5];
            // Array.Copy(Arr01, Arr02, 3); //start from 0 index copy 3 element from arr01 to arr02
            //Array.ConstrainedCopy(Arr01, 1, Arr02, 2, 3); //Copey From Arr01 Start from index 1 to index 2 in Arr02 get 3 element 
            #endregion

            #region object Member Method
            //int[] numbers = { 5, 6, 4, 3, 2, 1, 4, 5 };

            // numbers.GetLength(0); // Return Length for 0 dim
            //int Element = (int)numbers.GetValue(0); // return object 
            // or
            //int Element = numbers[0];

            //numbers.SetValue(10, 4); // set 10 in index 4
            //// or
            //numbers[4] = 10;



            #endregion

            #endregion

            #region Array 2D [ Rectangular ]

            // to loop on 2d array we need 2 for loop
            // to loop in 2d array using 1 loopint
            //int[,] marks = new int[2, 4];
            //for (int i = 0; i < marks.Length;)
            //{
            //    bool isParsed = int.TryParse(Console.ReadLine(), out int mark);
            //    if (isParsed)
            //    {
            //        marks[i / marks.GetLength(1), i % marks.GetLength(1)] = mark;
            //        i++;
            //    }
            //}

            //Console.Clear();

            //for (int i = 0; i < marks.Length; i++)
            //{
            //    Console.WriteLine(marks[i / marks.GetLength(1), i % marks.GetLength(1)]);
            //}


            #endregion

            #region Function

            #region Function Prototype

            //PrintShape("*", 5); // passing parameters by order
            //PrintShape(count: 10, pattern: "*"); // passing parameters by name
            //PrintShape(); // Invalid Because Parameters is required

            //PrintShape(); // using default value
            //PrintShape("$", 8);
            //PrintShape(count: 4); // use pattern with default value


            //PrintShape("/*\", 10); // invalid because [Escape Sequence] -> \
            //PrintShape(@"/*\", 4);

            //Console.WriteLine("welcom ahmed\r hello said");

            #endregion

            #region Function Parameter [Value Type]

            #region Passing By Value
            //int A = 10, B = 5;
            //Console.WriteLine($"A = {A}");
            //Console.WriteLine($"B = {B}");
            //Swap(A, B); // passing parameter by value
            //Console.WriteLine("After Swapping");
            //Console.WriteLine($"A = {A}");
            //Console.WriteLine($"B = {B}");
            #endregion

            #region Passing By Reference

            //int A = 10, B = 5;
            //Console.WriteLine($"A = {A}");
            //Console.WriteLine($"B = {B}");
            //Swap(ref A, ref B); // passing parameter by reference
            //Console.WriteLine("After Swapping");
            //Console.WriteLine($"A = {A}");
            //Console.WriteLine($"B = {B}");

            #endregion

            #endregion

            #region Function Parameter [Reference Type]
            #region Example 01
            #region Passing By Value
            //int[] numbers = { 1, 2, 3, 4, 5};
            //int result = SumArray(numbers);
            //Console.WriteLine(result);

            //int[] numbers = null;
            //int result = SumArray(numbers); // Exception Because Array is null
            //Console.WriteLine(result);

            //int[] numbers = null;
            //int result = SumArray(numbers); // passing by value
            //Console.WriteLine(result);

            //int[] numbers = { 1, 2, 3, 4, 5 };
            //int result = SumArray(numbers); // passing by value [address]
            //Console.WriteLine(result);
            #endregion

            #region Passing y Reference

            //int[] numbers = { 1, 2, 3, 4, 5 };
            //int result = SumArray(ref numbers);
            //Console.WriteLine(numbers[0]);
            //Console.WriteLine(result);

            #endregion

            #endregion

            #region Example 02
            #region Passing By Value
            //int[] numbers = { 1, 2, 3 };
            //Console.WriteLine(numbers[0]);
            //int result = SumArray(numbers); 
            //Console.WriteLine(numbers[0]);
            //Console.WriteLine($"Result = {result}");
            #endregion

            #region Passing By Ref

            //int[] numbers = { 1, 2, 3 };
            //Console.WriteLine(numbers[0]);
            //int result = SumArray(ref numbers);
            //Console.WriteLine(numbers[0]);
            //Console.WriteLine($"Result = {result}");

            #endregion

            #endregion

            #endregion

            #region Function Parameters [Passing bu out]

            //int A = 10, B = 5;
            //int sumResult, subResult;
            //SumSub(A, B, out sumResult, out subResult);
            //Console.WriteLine(sumResult);
            //Console.WriteLine(subResult);

            #endregion

            #region Function Parameters [Params]

            //int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 , 10};
            //SumArray(1, 2, 3, 4, 5, 6, 7, 8, 9, 10); 
            //// C# Will Convert it to an arary internally

            //Concat<object>("Hello Ahmed", "Welcom", "You Numbers is", 123456, "Date is", DateTime.Now);

            //int number = 123456;
            //string name = "Ahmed";
            //string message = string.Format("Hello {0}, Your Age is {1}, Your Number is {2}", name, DateTime.Now, number); // this function use params


            #endregion

            #endregion

            #region Boxing , Unboxing

            #region Boxing [Value Type => Reference Type] Safe
            //int X = 100;
            //object obj = X; // Boxing - Implicity
            //// Take Copy From Value and Wrapping the value in an object


            //obj = 123.3; // casting from value type [Double] => To Reference Type [Object] ----> Boxing
            //obj = 'A'; // // casting from value type [Char] => To Reference Type [Object] ----> Boxing
            //obj = 12.12f; // // casting from value type [float] => To Reference Type [Object] ----> Boxing
            //Console.WriteLine(obj);


            //// Explicity
            //obj = (object)'B'; // Not Required - never requiered 

            #endregion

            #region Unboxing [Reference Type -> Value Type] Un Safe

            //object obj = "Ahmed";
            //int X = (int)obj; // in run time throw exception
            //// unboxing - Unsafe - Explicity

            //obj = 10;
            //X = (int)obj; // valid

            #endregion

            #endregion

            #region Nullable Value Types

            #region Example 01
            ////int x = 10;
            ////x = null; // invalid

            //Nullable<int> y = 10;
            //y = null; // valid
            //// y can hold any int value + null
            //// or using syntax swagger
            //int? z = 100;
            //z = null;
            #endregion

            #region Example 02
            // int x = 10;
            // int? y = x; // valid - Implicitly casting

            // // x can hold int values
            // // y can hold int values + null

            // int? A = 10;
            // int B = (int)A; // valid - explicitly - unsafe


            // int? A = 10;
            // int B;
            // // protected code
            // if (A is not null)
            //     B = (int)A;
            // else
            //     B = 0;

            // another
            // if (A.HasValue)
            //     B = A.Value;
            // else
            //     B = 0;
            // another
            //B = A.HasValue ? A.Value : 0;
            // // another
            // B = A ?? 0;
            // another
            //B = A.GetValueOrDefault();
            // if has value return value if not return default


            #endregion

            #endregion

            #region Nullable Reference Type

            //string name01 = "Ahmed";
            //name01 = null; // valid

            //string? name02 = null;
            //Console.WriteLine(name02);

            //string name01 = null!;

            #endregion

            #region Null-Conditional | Propagation Operator

            //int[] numbers = { 1, 2, 3, 4, 5 };

            ////protective code
            //for (int i = 0; i < numbers?.Length; i++)
            //{
            //    Console.WriteLine(numbers[i]);
            //}

            //// numbers?.Length
            //// numbers is null => null
            //// numbers value => numbers .Length

            //int[] numbers = null;
            //int arrayLength = numbers?.Length ?? 0;
            //Console.WriteLine(arrayLength);

             #endregion

        }


        // reference -> number of calling to this Function
        //public static void PrintShape(string pattern, int count)
        //{
        //    for (int i = 0; i <= count; i++)
        //    {
        //        Console.Write($"{pattern} ");
        //    }
        //}

        // Default Value
        public static void PrintShape(string pattern = "*", int count = 5)
        {
            for (int i = 0; i <= count; i++)
            {
                Console.Write($"{pattern} ");
            }
         }

        }
}
