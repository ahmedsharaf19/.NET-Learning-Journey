using System.ComponentModel.Design.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text;

using System.Diagnostics.Tracing;
using System.Xml;
using System.Globalization;
namespace LecEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Evolution of switch in c#

            #region C#7.0 [Pattern Matching - Case Guards (when)]

            //object number = 5.6; // boxing
            #region Example 01 [Pattern matching on types]
            // no jump table will be created
            //switch (number)
            //{
            //    case int value:
            //        Console.WriteLine("Integer");
            //        break;
            //    case decimal value:
            //        Console.WriteLine("Decimal");
            //        break;
            //    case double value:
            //        Console.WriteLine("Double");
            //        break;
            //    default:
            //        Console.WriteLine("No Matching");
            //        break;
            //}

            #endregion

            #region Example 02 [Case Guards (When)]
            //switch (number)
            //{
            //    case int value when value < 10:
            //        Console.WriteLine("Integer Is Less Than 10");
            //        break;
            //    case int value when value > 10:
            //        Console.WriteLine("Integer Is greater Than 10");
            //        break;
            //    case decimal value:
            //        Console.WriteLine("Decimal");
            //        break;
            //    case double value when value > 5.5 && value < 10.10:
            //        Console.WriteLine("Double between 5.5 and 10.10");
            //        break;
            //    default:
            //        Console.WriteLine("No Matching");
            //        break;
            //}
            #endregion

            #region Example 03 [User-Defined Data Type]
            //object input = 50; //boxing
            //input = new Person() { Id = 1, Name = "Omar", Age = 25 };
            //switch (input)
            //{
            //    case int value when value > 10:
            //        Console.WriteLine("Int greater than 10");
            //        break;
            //    case string value:
            //        Console.WriteLine("String");
            //        break;
            //    case Person Value when Value.Id == 1 && Value.Name == "Omar": // Short Circuit
            //        Console.WriteLine("Person");
            //        break;
            //    default:
            //        Console.WriteLine("No Matching");
            //        break;
            //}
            #endregion

            #endregion

            #region C#8.0 [Pattern Matching Without alias name - switch Expression - Property pattern - Nullable Type]

            #region Example 01 - Pattern matching without alias name
            //object number = 5.6;
            //switch (number)
            //{
            //    case int:
            //        Console.WriteLine("Integer");
            //        break;
            //    case decimal:
            //        Console.WriteLine("Decimal");
            //        break;
            //    case double when (double)number > 5.5 && (double)number < 10.10:
            //        Console.WriteLine("Double");
            //        break;
            //}
            #endregion

            #region Switch Case Before Switch Expression

            //string option = Console.ReadLine() ?? "0";
            //string message;
            //switch (option)
            //{
            //    case "1":
            //        message = "Option 1";
            //        break;
            //    case "2":
            //        message = "Option 2";
            //        break;
            //    case "3":
            //        message = "Option 3";
            //        break;
            //    default:
            //        message = "Invalid Option";
            //        break;
            //}

            //Console.WriteLine(message);
            #endregion

            #region Example 02 Switch Expression [Constant Pattern - Discard Pattern]
            //Console.Write("Enter Your Number : ");
            //string option = Console.ReadLine() ?? "0";
            //string message;

            //message = option switch
            //{
            //    "1" => "Ussig Option 1",
            //    "2" => "Using Option 2",
            //    "3" => "Using Option 3",
            //    _ => "Usupported Option"
            //};
            //Console.WriteLine(message);
            #endregion

            #region Example 03 [Property Pattern]
            //Person person = new Person() { Id = 10, Name = "Omar", Age = 25};
            //string message = person switch
            //{
            //    { Name : "Ahmed", Age : 10} => "Hello Ahmed",
            //    { Name : "Omar"} => "Hello Omar",
            //    { Id : 50} => "Hello Person With Id = 50",
            //    _ => "Sorry We Don't Know You"
            //};
            //Console.WriteLine(message);
            #endregion

            #region Example 04 [Nullable Type - Relational Pattern (Partially)]
            //// number = null -> Nullable Type
            //// number = 10 -> Positive Number
            //// number = -10 -> Negative Number
            //// number = 0 -> Zero

            //int? number = null;  // nullable int
            //string result = number switch 
            //{
            //    null => "Nullable Type",
            //    int X when X > 0 => "Positive Number",
            //    int X  when X < 0 => "Negative Number",
            //    0 => "Zero",
            //};
            //Console.WriteLine(result);
            #endregion

            #endregion

            #region C#9.0 [Switch Expression With Relational Patterns - Logical Patterns - Enhanced Property Matching]

            #region Example 01 [Relational Patterns]
            //// Number Less Than 10
            //// Number Between 10 and 20
            //// Number Greater Than 20

            //int number = 20;
            //string Result = number switch
            //{ 
            //    < 10 => "Less Than 10",
            //    >= 10 and <= 20 => "Between 10 And 20",
            //    > 20 => "Greater Than 20"
            //};
            //Console.WriteLine(Result);
            #endregion

            #region Example 02 [Logical Patterns (and, or, not)]
            //// Number Between 1 and 9
            //// Number Between 10 and 20
            //// Number Is Zero
            //// Number Outside the range

            //int number = 10;
            //string result = number switch
            //{
            //    > 0 and < 10 => "Number is Between 1 and 9",
            //    >= 10 and <= 20 => "Number is Between 10 and 20",
            //    0 => "Number Is Zero",
            //    //  _ => "Number Outside the range",
            //    // or
            //    > 20 or < 0 => "Number Outside the range"
            //};
            //Console.WriteLine(result);

            #endregion

            #region Example 03 [Enhanced Property Matching]
            //// Person is samy and His Age is greater than 10
            //// Person is omar and His Age is Between 20 and 24
            //// Person's Age is between 50 and 60
            //// Any One Else [Sorry But We Don't Know You]

            //Person person = new Person() { Id = 10, Name = "Omar", Age = 21};
            //string result = person switch
            //{
            //    { Name: "Samy", Age: > 10 } => "Hello Samy",
            //    { Name: "Omar", Age : >=20 and <= 24} => "Hello Omar",
            //    { Age : > 50 and < 60} => "Hello Old Man",
            //    _ => "Sorry We Don't Know You"
            //};
            //Console.WriteLine(result);


            #endregion

            #endregion

            #endregion

            #region Looping | Iteration Statements

            //Console.WriteLine(1);
            //Console.WriteLine(2);
            //Console.WriteLine(3);
            //Console.WriteLine(4);
            //Console.WriteLine(5);
            //Console.WriteLine(6);
            //Console.WriteLine(7);
            //Console.WriteLine(8);
            //Console.WriteLine(9);
            //Console.WriteLine(10);
            //// 10 steps
            //Console.WriteLine("###############################");
            //for (int i = 1; i <= 10; i++)
            //{
            //    Console.WriteLine(i);
            //}
            //// 32 steps

            #region for - foreach
            //int[] numbers = { 1, 2, 3, 4, 5 };
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    Console.WriteLine(numbers[i]);
            //}

            //Console.WriteLine("############################## For Each #####################");
            //foreach (int number in numbers)  // number -> for each iterator variable
            //{
            //    Console.WriteLine($"{number} is an even number");
            //}
            #endregion

            #region while - do while

            #region do-while
            //// let user enter an even number
            //// if value is as odd number -> enter value again
            //// if it's not a number -> enter vakue again
            //// if value is an even number -> print number
            //bool isParsed;
            //int number;
            //do
            //{
            //    Console.Write("Enter  An Even Number : ");
            //    isParsed = int.TryParse(Console.ReadLine(), out number);
            //} while (!isParsed || number % 2 != 0);
            //Console.WriteLine(number);
            #endregion

            #region while
            // Take a number from user and print
            // a sequence of number from entered number to 10
            //Console.Write("Enter Number : ");
            //bool isParsed = int.TryParse(Console.ReadLine(), out int number);
            ////while (isParsed && number <= 10)
            ////{
            ////    Console.WriteLine(number);
            ////    number++;
            ////}
            //// perfect
            //if (isParsed)
            //{
            //    while (number <= 10)
            //    {
            //        Console.WriteLine(number);
            //        number++;
            //    }
            //}
            #endregion

            #endregion

            #endregion

            #region string

            #region Example 01
            //string name;
            ////// Declare for reference from type string
            ////// reference 'name' is referning to default value of reference type [null]
            ////// CLR Will Allocated 4 Bytes At Stack From Reference 'name'
            ////// 0 Bytes Allocated at Heap


            ////char X = default; // default of character is '\0' space
            ////Console.WriteLine(X);
            ////Console.WriteLine((int)X); // space number is 0 ASCII

            //name = new string("Ahmed");
            //// Allocated Required bytes at heap [10 bytes]
            //// initialize allocated bytes 
            //// cal user defined constructor
            //// Assign Reference 'name' with Address of allocated object
            //Console.WriteLine($"Name {name}");
            //Console.WriteLine($"HashCode Name {name.GetHashCode()}");

            //string name02 = "Ahmed"; // Syntax Swagger (String Literal)
            //// CLR will Checks  if the string "Ahmed" IS Alreadt Exists in string bool
            //// if is not exists => add new string in Pool
            //// if it is exists => Reuse Same Memory Location
            //Console.WriteLine($"Name {name02}");
            //Console.WriteLine($"HashCode Name {name02.GetHashCode()}");

            #endregion

            #region Example 02

            //string name01 = "Amr";
            //string name02 = "May";

            //Console.WriteLine($"name01 : {name01}");
            //Console.WriteLine($"HashCode of name01 : {name01.GetHashCode()}");
            //Console.WriteLine($"name02 : {name02}");
            //Console.WriteLine($"HashCode of name02 : {name02.GetHashCode()}");
            //Console.WriteLine("############################### After Assign name02 = name01 ###############################");
            //name02 = name01; // now may become unreachable object
            //Console.WriteLine($"name01 : {name01}");
            //Console.WriteLine($"HashCode of name01 : {name01.GetHashCode()}");
            //Console.WriteLine($"name02 : {name02}");
            //Console.WriteLine($"HashCode of name02 : {name02.GetHashCode()}");
            //Console.WriteLine("############################### After Changing name01 value ###############################");
            //name01 = "Omar";
            //Console.WriteLine($"name01 : {name01}");
            //Console.WriteLine($"HashCode of name01 : {name01.GetHashCode()}");
            //Console.WriteLine($"name02 : {name02}");
            //Console.WriteLine($"HashCode of name02 : {name02.GetHashCode()}");

            #endregion

            #region Example 03
            //string message = "Hello";
            //Console.WriteLine(message); // Hello
            //Console.WriteLine(message.GetHashCode()); // 2126015494

            //message += " Ahmed";
            //Console.WriteLine("########### After Changing Message ##########");
            //Console.WriteLine(message); //Hello Ahmed
            //Console.WriteLine(message.GetHashCode()); // 1667276298

            #endregion
            #endregion

            #region string methods
            //string message = "        Hello Ahmed        ";
            //Console.WriteLine(message.Length); // 27
            //Console.WriteLine(message.ToUpper()); // HELLO AHMED
            //Console.WriteLine(message.ToLower()); // hello ahmed
            //Console.WriteLine(message.Trim()); // remove all white spaces in string
            //Console.WriteLine(message.TrimStart()); // remove white space from start
            //Console.WriteLine(message.TrimEnd()); // remove white space from end 
            //Console.WriteLine(message.Substring(0, 5)); // from index 0 get 5 char
            //Console.WriteLine(message.Replace('e', 'm')); // replace any e to m
            //Console.WriteLine(message.Contains('e')); // string contain this char or not
            #endregion

            #region stringbuilder
            //StringBuilder message;
            //// Declare Reference from type StringBuilder 'message'
            //// reference 'message' is refereing to NULL
            //// CLR Allocate 4 bytes at stack for reference 'message'
            //// 0 bytes allocated at heap

            ////message = "Ahmed" // invalid
            //message = new StringBuilder("Hello");
            //Console.WriteLine($"Message = {message}");
            //Console.WriteLine($"Hashcode = {message.GetHashCode()}");

            //message.Clear(); // Remove all character 
            //message.Append("Ahmed");
            //Console.WriteLine("After Changing Message");
            //Console.WriteLine($"Message = {message}");
            //Console.WriteLine($"Hashcode = {message.GetHashCode()}");

            //message.Append(" Sharaf");
            //Console.WriteLine($"Message = {message}");
            //Console.WriteLine($"Hashcode = {message.GetHashCode()}");

            #endregion

            #region Stringbuilder methods
            //StringBuilder message = new StringBuilder("Hello");
            //message.Append(" Ahmed"); // Hello Ahmed
            //message.AppendLine("Welcome"); // append and new line
            //message.Append("New Student");
            //message.Replace("New Student", "Amr");
            //message.Remove(0, 5); // remove from index 0 remove 5 char
            //message.Insert(0, "Hi"); // insert in index 0 append Hi
            //Console.WriteLine(message);

            //StringBuilder message = new StringBuilder("Hello");
            //message.AppendLine("Amr");
            //int age = 23;
            //message.AppendFormat(" You Age Is : {0}", age);
            //Console.WriteLine(message);

            //message.AppendJoin("_", "Ahmed", "Ali"); // (separator, ....)
            //Console.WriteLine(message);
            #endregion

            #region Arrays

            #region 1D Array

            #region Example 01
            //int[] numbers; // array of int
            ///// Declare for reference from type arry 'numbers'
            ///// reference 'numbers' refereing to NULL
            ///// reference 'numbers' can refer to an object from type array of int
            ///// CLR will allocate 4 bytes at stack for reference 'numbers'
            ///// 0 bytes allocated at heap

            //// Console.WriteLine(numbers[0]); // invalid
            //numbers = new int[3]; // must assign size of array
            //                      // Allocate required bytes at heap [3 * 4 = 12 bytes]
            //                      // Initialize Allocated Bytes With Default Value of int (0)

            //Console.WriteLine(numbers[0]); // 0
            //Console.WriteLine(numbers[1]); // 0
            //Console.WriteLine(numbers[2]); // 0

            //numbers[0] = 1;
            //numbers[1] = 2;
            //numbers[2] = 3;

            //Console.WriteLine(numbers[0]); // 1
            //Console.WriteLine(numbers[1]); // 2
            //Console.WriteLine(numbers[2]); // 3
            //Console.WriteLine("######################################");
            //Console.WriteLine($"Size Array {numbers.Length}"); // 3
            //Console.WriteLine($"D Of Array {numbers.Rank}"); // 1
            //Console.WriteLine("######################################");

            //// Traversal Array
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    Console.WriteLine(numbers[i]);
            //}
            //Console.WriteLine("######################################");

            //foreach (int number in numbers) {
            //    Console.WriteLine(number);
            //}
            #endregion

            #region Array Creation Ways

            //int[] numbers01 = new int[3]; // Initialized With 0
            //int[] numbers02 = new int[3] {1, 2, 3 };
            //int[] numbers03 = new int[] {1, 2, 3}; // compiler know size equal 3
            //int[] numbers04 = { 1, 2, 3 };




            #endregion

            #endregion

            #region 2D Array [Rectangular]

            ////int[,] marks = new int[2, 5]; // row = 2, col = 5, 10 element
            ////// CLR Will Allocate requirements Bytes [2 * 5 * 4 = 40 bytes] initialized with default value (Zero)

            //////marks[0, 0] = 100;
            //////marks[0, 1] = 55;
            //////marks[0, 2] = 60;
            //////marks[0, 3] = 70;
            //////marks[0, 4] = 30;

            ////Console.WriteLine($"Size = {marks.Length}, Dim = {marks.Rank}");

            //// int[,] marks = new int[2, 5] {{100, 90, 30, 50, 40 }, {20 ,30, 50 ,60 ,70 }} 

            //// get data from user
            //int[,] marks = new int[2, 5];

            //for (int i = 0; i < marks.GetLength(0); i++) // marks.GetLength(0) number of row
            //{
            //    Console.WriteLine($"Grades Of Student Number {i+1}"); // marks.GetLength(1) number of col
            //    for (int j = 0; j < marks.GetLength(1); /*j++*/)
            //    {
            //        Console.Write($"Subect Number {j+1} : ");
            //        bool isParsed = int.TryParse(Console.ReadLine(), out marks[i, j]);
            //        if (isParsed) {
            //            ++j;
            //        }
            //    }
            //}
            //Console.WriteLine("################################");
            //for (int i = 0; i < marks.GetLength(0); i++)
            //{
            //    Console.WriteLine($"Grades Of Student Number {i + 1}"); // marks.GetLength(1) number of col

            //    for (int j = 0;j < marks.GetLength(1); j++)
            //    {
            //        Console.WriteLine(marks[i, j]);
            //    }
            //}




            #endregion

            #region Jagged Array

            //int[][] jaggedArray = new int[3][]; // must know number of row 
            //jaggedArray[0] = new int[3] {1, 2, 3};
            //jaggedArray[1] = new int[2] { 4, 5 };
            //jaggedArray[2] = new int[] { 6 };


            #endregion

            #endregion
        }
    }
}
