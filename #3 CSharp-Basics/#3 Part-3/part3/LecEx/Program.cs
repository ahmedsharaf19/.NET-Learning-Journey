using System.Diagnostics;
using System.Globalization;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;

namespace LecEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Fractions And Discard

            //float myFloat = 10.123456789F; // Float
            //Console.WriteLine(myFloat); //10.123457

            //double myDouble = 10.123456789;
            //Console.WriteLine(myDouble); //10.123456789

            //decimal myDecimal = 10.123456789123456789m;
            //Console.WriteLine(myDecimal);

            //long number = 10_000_000_000; // use underscore for readability
            //Console.WriteLine(number); // 10000000000

            //Console.WriteLine($"{number:C}");
            //CultureInfo culuture = new CultureInfo("ar-Ar");
            //Console.WriteLine(number.ToString("c", culuture)); // Saudi Riyals
            //                                                   // 10?000?000?0007000
            #endregion

            #region  Casting

            #region Implicit And Explicit Casting

            #region Example01
            //int X = 10000; // 4Bytes
            //long Y = X; // 8 Bytes - Implicit Casting (int To Long)
            //Console.WriteLine(Y);

            //long A = 10000; // 8Bytes
            //// int B = A; // InValid
            //int B = (int)A; // Explicit Casting Using Casting Operartor [(int)]
            //Console.WriteLine(B); // 10000

            //A = 100000000000;
            //B = (int)A;
            //Console.WriteLine(B); // 1215752192 -> OverFlow

            //checked
            //{
            //    B = (int)A;
            //    unchecked
            //    {
            //        Console.WriteLine(B);
            //    }
            //}

            ///// Prtective Code
            //long K = 1000000000000000;
            //if (K > int.MaxValue || K < int.MinValue)
            //{
            //    Console.WriteLine("Exception Will Be Thrown");
            //}
            //else
            //{
            //    int M = (int)K;
            //}

            //object number = 10000000000000;

            //int X = number.GetType() == typeof(int) ? (int)number : 0;

            //int result = X + 10;
            //Console.WriteLine(result);

            #endregion

            #region Example02

            //int X = 10; // 4bytes
            //float Y = X;
            //Console.WriteLine(Y);

            //decimal A = 10.1000M;
            //int B = (int)A; // Explicit Casting - Unsafe casting [may be cause loss fo data]
            //Console.WriteLine(B); // 10 


            #endregion

            #endregion

            #region Covert
            //Console.WriteLine("Hello, Please Enter Your Data");
            //Console.Write("Name : ");
            //// string name = Console.ReadLine(); // Warning - ReadLine Can Return Null !
            //string? name = Console.ReadLine(); // make it  nullable
            //// or
            //// string name = Console.ReadLine() ?? " ";

            //Console.Write("Age : ");
            //// ReadLine -> Return Nullable String
            //// int age = Console.ReadLine(); // Invalid - We Need Casting

            //int age = Convert.ToInt32(Console.ReadLine());

            //Console.Write("Salary : ");
            //decimal salary = Convert.ToDecimal(Console.ReadLine());


            //Console.Clear(); // Clear Console Buffer



            //Console.WriteLine("======================================");
            //Console.WriteLine("Employee Data ");
            //Console.WriteLine("======================================");
            //Console.WriteLine("Name Is " + name);
            //Console.WriteLine("Age Is " + age);
            //Console.WriteLine("Salary Is " + salary);

            #endregion

            #region Parse()
            //Console.WriteLine("Hello, Please Enter Your Data");
            //Console.Write("Name : ");
            //string? name = Console.ReadLine();
            //Console.Write("Age : ");
            //int age = int.Parse(Console.ReadLine() ?? "0"); // if return null make this is 0

            //Console.Write("Salary : ");
            //decimal salary = decimal.Parse(Console.ReadLine() ?? "0");


            //Console.Clear(); 



            //Console.WriteLine("======================================");
            //Console.WriteLine("Employee Data ");
            //Console.WriteLine("======================================");
            //Console.WriteLine("Name Is " + name);
            //Console.WriteLine("Age Is " + age);
            //Console.WriteLine("Salary Is " + salary);

            #endregion

            #region TryParse()

            //string number01 = "10";
            //int X01 = int.Parse(number01);
            //Console.WriteLine(X01);

            ////string number02 = "ahmed";
            ////int X02 = int.Parse(number02);
            ////Console.WriteLine(X02); // System.FormatException

            //string number03 = "ahmed";
            //bool isParsed = int.TryParse(number03, out X01);
            //// isParsed -> True, X01 -> Value
            //// isParsed -> False, X01 -> 0
            //Console.WriteLine(X01);
            //Console.WriteLine(isParsed);

            //string number04 = "100";
            //bool isParsed01 = int.TryParse(number04, out X01);
            //// isParsed -> True, X01 -> Value
            //// isParsed -> False, X01 -> 0
            //Console.WriteLine(X01);
            //Console.WriteLine(isParsed01);



            //Console.WriteLine("Hello, Please Enter Your Data");
            //Console.Write("Name : ");
            //string? name = Console.ReadLine();

            //Console.Write("Age : ");
            //int age;
            //int.TryParse(Console.ReadLine(), out age);

            //Console.Write("Salary : ");
            //decimal.TryParse(Console.ReadLine(), out decimal salary);


            //Console.Clear();



            //Console.WriteLine("======================================");
            //Console.WriteLine("Employee Data ");
            //Console.WriteLine("======================================");
            //Console.WriteLine("Name Is " + name);
            //Console.WriteLine("Age Is " + age);
            //Console.WriteLine("Salary Is " + salary);

            #endregion

            #endregion

            #region Opeartors

            #region Unary Operators[ ++, -- ]

            //int X = 10;
            //// 1. ++ 
            //// 1.1 PreFix [Increment And Then Print]
            //Console.WriteLine(++X); // 11
            //Console.WriteLine(X); // 11

            //X = 10;
            //// 1.2 PostFix [Print And Then Increment]
            //Console.WriteLine(X++); // 10  
            //Console.WriteLine(X); // 11

            //X = 10;
            //// 2. --
            //// 2.1 PreFix [Decrement And The Print]
            //Console.WriteLine(--X); // 9
            //Console.WriteLine(X); // 9

            //X = 10;
            //// 2.2 PostFix [Print and then Decrement]
            //Console.WriteLine(X--); // 10
            //Console.WriteLine(X);  // 9

            #endregion

            #region Binary | Arithmetic Operators [+, -, *, /, %]

            //int sumResult, subResult, mulResult, divResult, modResult;
            //int number01 = 6, number02 = 2;
            //sumResult = number01 + number02; // 8
            //subResult = number01 - number02; // 4
            //mulResult = number01 * number02; // 12
            //divResult = number01 / number02; // 3
            //modResult = number01 % number02; // 0

            //Console.WriteLine(sumResult);
            //Console.WriteLine(subResult);
            //Console.WriteLine(mulResult);
            //Console.WriteLine(divResult);
            //Console.WriteLine(modResult);


            #endregion

            #region Assignment Operators [=, +=, -=, *=, /=, %=]

            //int X;
            //X = 4;
            //X += 2; // X = X + 2
            //X -= 2; // X = X - 2
            //X *= 2; // X = X * 2
            //X /= 2; // X = X / 2
            //X %= 2; // X = X % 2


            #endregion

            #region Relational | Comparison Operators [==, !=, <, >, <=, >=]

            //int X = 10, Y = 10;

            //Console.WriteLine(X == Y); // True
            //Console.WriteLine(X != Y); // False
            //Console.WriteLine(X > Y); // False
            //Console.WriteLine(X < Y); // False
            //Console.WriteLine(X >= Y); // True
            //Console.WriteLine(X <= Y); // True

            #endregion

            #region Logical Operators [!, &&, ||]

            //// Short Circuit
            //Console.WriteLine(!true); // false
            //Console.WriteLine(false && true); // false
            //Console.WriteLine(false || true); // true


            //Console.WriteLine(4 < 5 && 7 < 9);
            //Console.WriteLine(4 < 5 && 7 > 9);
            //Console.WriteLine(4 > 5 || 7 < 9);

            //// Console.WriteLine(4 && 5); // In Vaild 

            #endregion

            #region BitWise Operator [&, |, ^, ~, <<, >>]

            //// Long Circuit
            //Console.WriteLine(false & true); // false
            //Console.WriteLine(true | false); // true
            //Console.WriteLine(false ^ true); // true

            //int X = 5, Y = 3; // X = 0101, Y = 0011
            //Console.WriteLine(X & Y); // 1 (0101 & 0011 = 0001)
            //Console.WriteLine(X | Y); // 7 (0101 | 0011 = 0111)
            //Console.WriteLine(X ^ Y); // 6 (0101 ^ 0011 = 0110)
            //Console.WriteLine(~X);    // -6 (complement of 0101 is 1010)
            //Console.WriteLine(X << 1);// 10 (1010)
            //Console.WriteLine(X >> 1); // 2 (0010)

            #endregion

            #region Ternary Operator [Conditional Operator][ ? : ]
            //int X = 10, Y = 5;
            //string Message = X > Y ? "X > Y" : "X < Y";
            //Console.WriteLine(Message);

            #endregion

            #region Operators Priority and Associativity

            //int a = 20, b = 15, c = 10, d = 5, Result;

            //Result = (a + b) * c / d;     // 35 * 10 / 5 => 350 / 5 =  70
            //Result = ((a + b) * c) / d;   // 350 / 5 => 70 (un nessecary praces)
            //Result = (a + b) * (c / d);    // 35 * 2 => 70
            //Result = a + (b * c) / d;     //  20 + 150 / 5 => 20 + 30 = 50


            //Result = a + b++; // 20 + 15 => 35 & 15+1 = 16
            //Console.WriteLine(Result);
            //Console.WriteLine(b);

            //b = 15;
            //Result = a + ++b; // b = 16 & 20 + 16 => 36
            //Console.WriteLine(Result);
            //Console.WriteLine(b);

            //b = 15;
            //Result = a + b++ + b;  // 20 + 15 + 16
            //Console.WriteLine(Result);

            #endregion

            #endregion

            #region String Formatting

            //// Equation : 10 + 5 = 15
            //int X = 10, Y = 5;
            //int Result = X + Y;
            //string message;

            //// 1. String Interpolation
            //// $ => called manipulation operator
            ////message = $"Equation : {X} + {Y} = {Result}";
            ////Console.WriteLine(message);

            //// 2. String.Fromat Method
            ////message = string.Format("Equation : {0} + {1} = {2}", X, Y, Result);  //replace 0=> X, 1 => Y, 2 => Result
            ////Console.WriteLine(message);

            //// 3. Composite Formatting
            ////Console.WriteLine("Equation : {0} + {1} = {2}", X, Y, Result);

            //// 4. String Concatentation [+]
            ////message = "Equation: " + X + " + " + Y + " = " + Result;
            ////// Equation:                   // New Location in Memory
            ////// Equation: 10                // New Location in Memory
            ////// Equation: 10 +              // New Location in Memory
            ////// Equation: 10 + 5            // New Location in Memory 
            ////// Equation: 10 + 5 =          // New Location in Memory
            ////// Equation: 10 + 5 = 15       // New Location in Memory
            ////Console.WriteLine(message);

            ////// string filepath = "D:\Ahmed\File"; // slash is reserved (escape sequence) invalid
            ////string filepath = "D:\\Ahmed\\File"; // to skip meaning using double slash
            ////Console.WriteLine(filepath);

            //// or
            ////string filepath = @"D:\Ahmed\File \n"; // any slash not meaning
            ////Console.WriteLine(filepath);

            //// Example Using  Scape Sequence
            //Console.WriteLine("Ahmed\tSharaf\nBackEnd\tDeveloper\n");
            //// \t => tap space
            //// \n => new line
            #endregion

            #region Control Statements

            #region Example 01 [Year Quarter] - [If, Switch with Numeric type using Cinstant Pattern]

            //Console.Write("Please Enter A Month Number Existed in 1st Quarter : ");
            //int.TryParse(Console.ReadLine(), out int monthNumber);

            #region if else

            //if (monthNumber == 1)
            //{
            //    Console.WriteLine("Hello January");
            //}
            //else if (monthNumber == 2)
            //{
            //    Console.WriteLine("Hello February");
            //}
            //else if (monthNumber == 3) {
            //    Console.WriteLine("Hello March");
            //}
            //else
            //{
            //    Console.WriteLine("The Entered Month Number Is Not Valid Month At First Quarter");
            //}

            #endregion

            #region Switch

            //switch (monthNumber)
            //{
            //    case 1:
            //        Console.WriteLine("Hello January");
            //        break;
            //    case 2:
            //        Console.WriteLine("Hello February");
            //        break;
            //    case 3:
            //        Console.WriteLine("Hello March");
            //        break;
            //    default:
            //        Console.WriteLine("The Entered Month Number Is Not Valid Month At First Quarter");
            //        break;
            //}

            #endregion

            #endregion

            #region Example 02 [Student Age] - [If, Switch With Numeric Type Using Relational Pattern]
            /// Age Is Greater Than 22 => Student Age Is Greater Than 22
            /// Age Is Less Than 22 => Student Age Is Less Than 22
            /// Age Is 22 => Student Age Is 22
            /// 
            //Console.Write("Please Enter Student Age : ");
            //int.TryParse(Console.ReadLine(), out int age);

            #region If Else
            //if (age > 22)
            //    Console.WriteLine("Student Age Is Greater Than 22");
            //else if (age < 22)
            //    Console.WriteLine("Student Age Is Less Than 22");
            //else
            //    Console.WriteLine("Student Age Is 22");

            #endregion

            #region Switch
            //switch (age)
            //{
            //    case > 22:
            //        Console.WriteLine("Student age is greater than 22");
            //        break;
            //    case < 22:
            //        Console.WriteLine("Student age is less than 22");
            //        break;
            //    default:
            //        Console.WriteLine("Student Age Is 22");
            //        break;
            //}
            #endregion

            #endregion

            #region Example03 [Student Name] - [If, Switch with string type]

            /// name = omar => hello omar
            /// name = may => hello may
            /// name = ahmed => hello ahmed
            /// 
            //Console.Write("Enter Student Name : ");
            //string name = Console.ReadLine() ?? "No Name";

            #region if else

            //if (name == "Omar" || name == "omar")
            //{
            //    Console.WriteLine("Hello, Omar");
            //}
            //else if (name == "May" || name == "may")
            //{
            //    Console.WriteLine("Hello, May");
            //}
            //else if (name == "Ahmed" || name == "ahmed")
            //{
            //    Console.WriteLine("Hello, Ahmed");
            //}

            #endregion

            #region Switch
            // No Jump Table Will Be Created
            // Compiler Will Generate Sequance of string comparison (convert to if else by compiler)
            //switch (name)
            //{
            //    case "Omar":
            //    case "omar":
            //        Console.WriteLine("Hello, Omar");
            //        break;
            //    case "May":
            //    case "may":
            //        Console.WriteLine("Hello, May");
            //        break;
            //    case "Ahmed":
            //    case "ahmed":
            //        Console.WriteLine("Hello, Ahmed");
            //        break;
            //}

            #endregion

            #endregion

            #region Example 04 [Budget] - [Switch With Goto]

            /// Budget is 1000 => option 01
            /// Budget is 2000 => option 01, option 02
            /// Budget is 3000 => option 01, option 02, option 03

            //Console.Write("Please Enter Your budget : ");
            //int.TryParse(Console.ReadLine(), out int budget);

            #region Switch
            //switch (budget)
            //{
            //    case 1000:
            //        Console.WriteLine("Option 01");
            //        break;
            //    case 2000:
            //        Console.WriteLine("Option 02");
            //        Console.WriteLine("Option 01");
            //        break;
            //    case 3000:
            //        Console.WriteLine("Option 03");
            //        Console.WriteLine("Option 02");
            //        Console.WriteLine("Option 01");
            //        break;
            //}
            #endregion

            #region Goto
            //switch (budget)
            //{
            //    case 1000:
            //        Console.WriteLine("Option 01");
            //        break;
            //    case 2000:
            //        Console.WriteLine("Option 02");
            //        goto case 1000;
            //    case 3000:
            //        Console.WriteLine("Option 03");
            //        goto case 2000;
            //}
            #endregion

            #endregion

            #region goto

            //Retry:
            //Console.WriteLine("Hello Hamada");


            //Console.WriteLine("Please Enter Your Name : ");
            //string name = Console.ReadLine();

            //if (name == "Hamada")
            //{
            //    goto Retry;
            //}
            //else
            //    Console.WriteLine($"Hello {name}");

            #endregion

            #endregion
        }
    }
}
