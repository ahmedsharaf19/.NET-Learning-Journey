using System.Numerics;
using Demo.Overloading;
using Complex = Demo.Overloading.Complex;
using Demo.Overriding;
using Demo.Binding;

namespace Demo
{
    internal class Program
    {
        #region Method Overloading
        static int SumTwoNumbers(int x, int y)
        {
            return x + y;
        }

        static double SumTwoNumbers(int x, double y)
        {
            return x + y;
        }

        //// Not Meaning I can Use previos function do to same thing by passing parameters by name 
        //static double SumTwoNumbers(double x, int y)
        //{
        //    return x + y;
        //}

        //static int SumTwoNumbers(int y, int x)
        ////  Can not overload a method just by changing the name of parameters
        //{
        //    return x + y;
        //}


        //static double SumTwoNumbers(int x, int y)
        //    // Can not overload a method just by changing the return type
        //{
        //    return x + y;
        //}

        static double SumTwoNumbers(double x, double y)
        {
            return x + y;
        }

        static int SumTwoNumbers(int x, int y, int z)
        {
            return x + y + z;
        } 
        #endregion


        //public static void ProcessEmployee(FullTimeEmployee employee) // FullTimeEmployee employee = Object From FullTimeEmployee
        //{
        //    if (employee is not null)
        //    {
        //        employee.GetEmployeeType(); 
        //        employee.GetEmployeeData(); 
        //    }
        //}

        //public static void ProcessEmployee(PartTimeEmployee employee) // PartTimeEmployee employee = Object From PartTimeEmployee
        //{
        //    if (employee is not null)
        //    {
        //        employee.GetEmployeeType();// Static Polymorphism [Resolve Function Compilation Time [Reference Type]]
        //        employee.GetEmployeeData();// Dynamic Polymorphism [Resolve Function RunTime [Based on object type]]
        //    }
        //}

        // This is not an overloading -> دا عك


        // Right Way
        public static void ProcessEmployee(Employee employee) // its binding - Employee employee = Object From Child [FullTimeEmployee - PartTimeEmployee]
        {
            if (employee is not null)
            {
                // GetEmployeeType -> Called From Reference Type [Employee]
                employee.GetEmployeeType();// Static Polymorphism [Resolve Function Compilation Time [Reference Type]]

                // GetEmployeeData -> Called From Object Type [FullTimeEmployee - PartTimeEmployee]
                employee.GetEmployeeData();// Dynamic Polymorphism [Resolve Function RunTime [Based on object type]]
            }
        }

        static void Main(string[] args)
        {
            #region Overloading

            #region Method Overloading 
            //int a = 10, b = 20;
            //Console.WriteLine(SumTwoNumbers(a, b));
            //Console.WriteLine(SumTwoNumbers(10, 20, 30));
            //Console.WriteLine(SumTwoNumbers(10.2, 12.5)); 
            #endregion

            #region Operator Overloading 

            #region Binary Operators
            //Complex C1 = new Complex()
            //{
            //    Real = 10,
            //    Img = 5
            //};
            //Console.WriteLine($"C1 = {C1}");

            //Complex C2 = new Complex()
            //{
            //    Real = 6,
            //    Img = 2
            //};
            //Console.WriteLine($"C2 = {C2}");


            //Complex? C3 = default; // Null
            ////C3 = C1 + C2; // Invalid - Must Make Operator Override In Complex Class
            //C3 = C1 + C2; // valid - after Operator overloading
            //Console.WriteLine("----------------------------------");
            //Console.WriteLine($"C3 = {C3}");


            //C2 = null;
            ////C3 = C1 + C2; // Throw Exception Because Code is not protected
            //// After Protective code
            //C3 = C1 + C2;
            //Console.WriteLine("----------------------------------");
            //Console.WriteLine($"C3 = {C3}");


            //C3 += C1 + C2; // C3 = C1 + C2


            //C2 = new Complex()
            //{
            //    Real = 6,
            //    Img = 2
            //};
            //C3 = C1 - C2;
            //Console.WriteLine("----------------------------------");
            //Console.WriteLine($"C3 = {C3}");  
            #endregion

            #region Unary Operators
            //Complex C1 = new Complex()
            //{
            //    Real = 10,
            //    Img = 5
            //};

            //Complex C2;
            ////C2 = ++C1;
            ////Console.WriteLine(C1);
            ////Console.WriteLine(C2);

            //C2 = C1++;
            //Console.WriteLine(C1);
            //Console.WriteLine(C2);


            #endregion

            #region Relational Operators [Comparison]
            //Complex C1 = new Complex()
            //{
            //    Real = 10,
            //    Img = 5
            //};
            //Console.WriteLine($"C1 = {C1}");

            //Complex C2 = new Complex()
            //{
            //    Real = 6,
            //    Img = 2
            //};
            //Console.WriteLine($"C2 = {C2}");

            //if (C1 > C2)
            //{
            //    Console.WriteLine("C1 > C2");
            //}
            //else if (C1 < C2) 
            //{
            //    Console.WriteLine("C1 < C2");
            //}
            //else
            //{
            //    Console.WriteLine("C1 == C2");
            //}

            //string message = C1 > C2 ? "C1 > C2" : "C1 < C2";
            //Console.WriteLine(message);
            #endregion

            #region Casting Operator Overloading

            //Complex C1 = new Complex() { Real = 10, Img = 5 };

            ////int X = C1; // invalid 
            ////int X = (int )C1;// invalid 
            ////// must create casting operator overloading 
            //// After Casting Explicit Operator
            ////int X = (int)C1;// valid 
            ////Console.WriteLine(X);

            //string m = C1;
            //Console.WriteLine(m);

            #endregion

            #region User Defined Data Type Casting Operatot
            //User userObj = new User()
            //{
            //    Id = 10,
            //    FullName = "Ahmed Tarek",
            //    Email = "ahmedtarek@gmail.com",
            //    Password = "P@ssw0rd",
            //    SecurityStamp = Guid.NewGuid()
            //};

            //UserViewModel userViewModel = (UserViewModel) userObj;
            //// (UserViewModel) =? Casting Operator
            //// in Entity Framework [Manual Mapping] [User => UserViewModel]
            //// if i need reverse [ViewModel => User] auto mapper
            #endregion

            #endregion

            #endregion

            #region Override

            //TypeA typeAObj = new TypeA(1);
            //typeAObj.A = 10;
            //typeAObj.MyFun01();
            //typeAObj.MyFun02();

            //TypeB typeBObj = new TypeB(1, 2);
            //typeBObj.A = 10;
            //typeBObj.B = 20;
            //typeBObj.MyFun01(); // Static Polymorphism [Compile-Time] -> Calling Function Based on Regerence Type
            //typeBObj.MyFun02(); // Dynamic Polymorphism [Run-Time] -> Calling Function Based On Object Type

            #endregion

            #region Binding

            #region Example 01
            //// Reference From Base Refere To An Object From Child
            //TypeA refBase;
            //// Reference Can refer to an object From Type A Or From Any Type Inherit From TypeA 
            //refBase = new TypeB(1, 2);
            //refBase.A = 10;
            ////refBase.B = 20; // InValid
            //refBase.MyFun01(); // Static Polymorphism - Static Binding - Early Binding
            //                   // Compilation Time
            //                   // This is MyFun From Base => I am Base
            //                   // MyFun() Mehod non virtual, override using "new"
            //                   // Resolve At Compile Time Based on reference time


            //refBase.MyFun02(); // Dynamic Polymorphisn - Dynamic Binding - Late Binding
            //                   // Run Time
            //                   // This is MyFun02 TypeB : A = 10, B = 2
            //                   // MyFun02() Method Virtual Overrided Using "Override"
            //                   // Resolve at Runtime Based on object type
            #endregion

            #region Example 02

            //FullTimeEmployee fullTimeEmployeeObj = new FullTimeEmployee(10, "Omar", 25, 20000);
            //ProcessEmployee(fullTimeEmployeeObj);

            //PartTimeEmployee partTimeEmployeeObj = new PartTimeEmployee(20, "Mona", 30, 100, 250);
            //ProcessEmployee(partTimeEmployeeObj);



            #endregion

            #endregion
        }
    }
}
