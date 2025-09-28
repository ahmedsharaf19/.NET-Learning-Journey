using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace LecEx
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Variable Declaration
            //// declare variable int with name 'number'
            //int number;  // declaratioe
            //number = 10; // assignment

            //System.Console.WriteLine(number); // Display number

            //string name = "Ahmed"; // Declare + initalize
            //System.Console.WriteLine(name);

            //string userName = "Ahmed Sharaf"; // Naming Convention Variable is camelCase
            //System.Console.Write(userName);


            //// string class = "Phd"; // Invalid
            //// string void = "ali"; // invalid
            //// int 3x = 4; // invalid
            //#endregion

            //#region Data Types
            //int x = 5; // stored at stack
            //string p = "hello"; // stack - heap
            //                       // variable:  value
            //                       // name => 12345
            //                       // 12345 => "hello"
            #endregion

            #region Valur Type Data Types
            //int n;   // Declare Variable From Type int 'x'
            //// CLR Will Allocate 4 un initialized bytes At Stack
            //n = 10; // assign value to variable 'x'

            //Console.WriteLine(n); // 10

            //Int32 y = 20;
            //// Declare Varianle from type int32 'y'
            //// CLR Allocate 4 Bytes initialized with value [20]

            //Console.WriteLine(y);

            //y = n;
            //Console.WriteLine("After Assignments");
            //Console.WriteLine(n);
            //Console.WriteLine(y);

            //n++;
            //Console.WriteLine("After n++");
            //Console.WriteLine(n);
            //Console.WriteLine(y);
            #endregion

            #region Reference Type Data Types
            //Point P1; // Declare For Reference From Type Point 'P1' Refrncing To Null (Default Value Of Reference Type)
            //// P1 Reference can refer to an instance from type point or from type inherit from point
            //// CLR will allocate 4 bytes at stack for reference "P1"
            //// 0 Bytes allocated at heap

            //P1 = new Point();
            //// 1. Allocate Required Bytes At Heap [8 bytes]
            //// 2. initialize allocated bytes with default values [x = 0, y = 0]
            //// 3. call user defined constructor if exist
            //// 4. Assign Reference "P1" To Allocated Object

            //Console.WriteLine($"P1.x = {P1.x}");
            //Console.WriteLine($"P1.y = {P1.y}");

            //Point P2 = new Point() { x = 10, y = 20};  // {} object initializer
            //// Declare For Reference From Type Point "P2"
            //// CLR Will Allocate 4 Bytes At Stack For Reference "P2"
            //// Allocate Required Bytes At Heap [8 Bytes]
            //// Initialize Allocated Bytes With Default Value [X = 10, Y= 20]
            //// Assign Reference "P2" To Allocated Object

            //Console.WriteLine($"P2.x = {P2.x}");
            //Console.WriteLine($"P2.y = {P2.y}");

            //P2 = P1; // 2 References Refer Same Object

            //// First Object -> 2 References [P1, P2]
            //// Second Object -> Un Reachable Object
            //Console.WriteLine("After Assignment");
            //Console.WriteLine($"P1.x = {P1.x}");
            //Console.WriteLine($"P1.y = {P1.y}");
            //Console.WriteLine($"P2.x = {P2.x}");
            //Console.WriteLine($"P2.y = {P2.y}");

            //P1.x = 100;
            //P1.y = 200;
            //Console.WriteLine("After Change P1");
            //Console.WriteLine($"P1.x = {P1.x}");
            //Console.WriteLine($"P1.y = {P1.y}");
            //Console.WriteLine($"P2.x = {P2.x}");
            //Console.WriteLine($"P2.y = {P2.y}");

            #endregion

            #region Objects

            #region ToString()
            //Point P1 = new Point() { x = 1, y = 2 };
            //Console.WriteLine(P1.ToString()); //LecEx.Point


            //int X = 50;
            //Console.WriteLine(X.ToString()); // "5"

            //object number = 123;
            //Console.WriteLine(number.ToString()); 
            //// call ToString Of Object call back ToString() int

            //object name = "Ahmed";
            //Console.WriteLine(name.ToString());
            //// call ToString Of Object call back ToString() string


            #endregion

            #region Equals()

            //Point P1 = new Point() { x = 1, y = 2 };
            //Point P2 = new Point() { x = 1, y = 2 };
            //Console.WriteLine(P1.Equals(P2));
            //P2 = P1;
            //Console.WriteLine(P1.Equals(P2));

            //int x = 50;
            //int y = 50;
            //Console.WriteLine(x.Equals(y));

            //object number1 = 123;
            //object number2 = 123;
            //Console.WriteLine(number1.Equals(number2));
            //// Call Equals() of object
            //// call back Equals() of int

            //object name1 = "Ahmed";
            //object name2 = "Ahmed";
            //Console.WriteLine(name1.Equals(name2));
            //// Call Equals() of object
            //// call back Equals() of string

            #endregion

            #region GetHasCode()

            //Point P1 = new Point() { x = 1, y = 2};
            //Console.WriteLine($"HashCode Of P1 = {P1.GetHashCode()}");
            //Point P2 = new Point() { x = 1,y = 2};
            //Console.WriteLine($"HashCode Of P2 = {P2.GetHashCode()}");


            //P2 = P1;
            //Console.WriteLine($"HashCode Of P1 = {P1.GetHashCode()}");
            //Console.WriteLine($"HashCode Of P2 = {P2.GetHashCode()}");
            //// equal hashcode because two refer to sam location


            //int x = 50;
            //Console.WriteLine(x.GetHashCode()); // hashcode = valu (50)


            //object number = 123; //boxing
            //Console.WriteLine(number.GetHashCode());
            //// call GetHashCode() Of Object
            //// CallBack GetHashCode() of int

            //object name1 = "Ahmed"; 
            //Console.WriteLine(name1.GetHashCode());

            //object name2  = "Ahmed";
            //Console.WriteLine(name2.GetHashCode());
            // // same hashcode of name1




            #endregion

            #region GetType()

            //Point P1 = new Point() {  x = 1, y = 2 };
            //Console.WriteLine(P1.GetType());

            //int x = 50;
            //Console.WriteLine(x.GetType());

            //object number = 123;
            //Console.WriteLine(number.GetType());

            //object name = "Ahmed";
            //Console.WriteLine(name.GetType());

            #endregion

            #region Example

            //object obj;
            //// Declare For Variable/Refernce Of Type Object "obj" Referencing To Null
            //// This Reference Can Refer To An Instance From Object
            //// Or From Any DataType That Inherit From Object [All Data Type]
            //// CLR will allocate 4 bytes at stack for refernce 'obj'
            //// 0 bytes Allocated at Heap

            //obj = new object();
            //obj = new string("Ahmed"); // Syntax Swager
            //obj = "Ahmed";
            //obj = 100; // boxing 
            ////obj = 'A'; //boxing
            ////obj = 2.2; //boxing
            ////obj = true; //boxing
            ////obj = new DateTime(); //boxing
            ////obj = new DateOnly(); //boxing


            //// int Number = obj; // syntax error 
            //int Number = (int)obj; // must cast object

            #endregion

            #endregion

        }
        #region Comments

        //// Single Line Comment
        //// This is single line comments


        //// Multiline Comments
        ///* This is multiline comment
        // * second line
        // * third line
        // */

        //// XML Comments
        ///// <summary>
        ///// This is function to sum two numbers
        ///// </summary>
        ///// <param name="x">first number</param>
        ///// <param name="y">second number</param>
        ///// <returns>Return the summition of two numbers</returns>
        //static int Add(int x, int y)
        //{
        //    return x + y;
        //}
        #endregion
    }
}