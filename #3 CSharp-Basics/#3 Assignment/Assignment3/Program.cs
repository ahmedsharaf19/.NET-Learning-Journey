namespace Assignment3
{
    internal class Program
    {
        #region Q1
        //1-Explain the difference between passing (Value type parameters) by value and by reference then write a suitable c# example.
        #region 1-Passing By Value
        public static void swap01(int x, int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
        #endregion
        #region 2- Passing By Ref
        public static void swap02(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
        #endregion

        #endregion

        #region Q2
        //2-Explain the difference between passing (Reference type parameters) by value and by reference then write a suitable c# example.
        #region by value
        static void fun01(int[] arr)
        {
            if (arr == null) {
                return;
            }
            arr = new int[] { 4, 5, 6, 7 };
        }
        #endregion

        #region by ref
        static void fun02(ref int[] arr)
        {
            if (arr == null) return;
            arr = new int[] { 4, 5, 6, 7 };
        }
        #endregion
        #endregion

        #region Q3
        //3-Write a c# Function that accept 4 parameters from user and return result of summation and subtracting of two numbers
        static void SumSub(int num01, int num02, out int sum, out int sub)
        {
            sum = num01 + num02;
            sub = num01 - num02;
        }
        #endregion

        #region Q4
        //4-Write a program in C# Sharp to create a function to calculate the sum of the individual digits of a given number.
        //Output should be like
        //Enter a number: 25                                                                                            
        //The sum of the digits of the number 25 is: 7
        // 25

        static int SumOfDigit(int num)
        {
            int sum = 0;
            while (num != 0)
            {
                int digit = num % 10;
                sum += digit;
                num /= 10;
            }
            return sum;
        }
        #endregion

        #region Q5
        //5-Create a function named "IsPrime", which receives an integer number and retuns true if it is prime, or false if it is not:
        static bool isPrime(int num)
        {
            if (num < 2) return false;

            for (int i = 2; i < num; i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }
        #endregion

        #region Q6
        //6-Create a function named MinMaxArray, to return the minimum and maximum values stored in an array, using reference parameters
        static void MinMaxArray(ref int[] arr, out int min, out int max)
        {
            max = arr[0];
            min = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (max < arr[i]) max = arr[i];
                else if (min > arr[i]) min = arr[i];
            }
        }
        #endregion

        #region Q7
        //7-Create an iterative (non-recursive) function to calculate the factorial of the number specified as parameter
        //5 => 1*2*3*4*5 =>120

        static long fact(int num)
        {
            int res = 1;
            for (int i = 1; i <= num; i++)
                res *= i;
            return res;
        }
        #endregion

        #region Q8
        //8-Create a function named "ChangeChar" to modify a letter in a certain position (0 based) of a string, replacing it with a different letter
        static string ChangeChar(string text, int index, char a)
        {
            text = text.Remove(index, 1);
            text = text.Insert(index, a.ToString());
            return text;
        }
        #endregion
        static void Main(string[] args)
        {
            #region Q1
            //int x = 4, y = 5;
            //swap01(x, y);
            //Console.WriteLine(x);
            //Console.WriteLine(y);
            //Console.WriteLine("############");
            //swap02(ref x, ref y);
            //Console.WriteLine(x);
            //Console.WriteLine(y);

            #endregion

            #region Q2
            //int[] a = { 1, 2, 3 };
            //fun01(a);
            //foreach (int x in a) 
            //    Console.WriteLine(x);
            //Console.WriteLine("#################");
            //fun02(ref a);
            //foreach (int x in a)
            //    Console.WriteLine(x);
            #endregion

            #region Q3
            //int sum, sub;
            //SumSub(4, 5, out sum, out sub);
            //Console.WriteLine(sum);
            //Console.WriteLine(sub);
            #endregion

            #region Q4
            //Console.WriteLine(SumOfDigit(36));
            #endregion

            #region Q5
            //Console.WriteLine(isPrime(5));
            #endregion

            #region Q6
            //int[] arr = { 1, 2, 3, 4 };
            //int min, max;
            //MinMaxArray(ref arr, out min, out max);
            //Console.WriteLine(min);
            //Console.WriteLine(max);
            #endregion

            #region Q7
            //Console.WriteLine(fact(5));
            #endregion

            #region Q8
            string text = "abcd";
            Console.WriteLine(ChangeChar(text, 1, 'z'));
            #endregion
        }
    }
}
