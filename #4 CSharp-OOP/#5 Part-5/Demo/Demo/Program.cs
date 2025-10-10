using Demo.Binding;
using Demo.Interface;
using Type = Demo.Interface.Type; // Alias Name
using TypeA = Demo.Interface_Example_01.TypeA;
using Demo.Interface_Example_01;
using TypeB = Demo.Interface_Example_01.TypeB;
using TypeC = Demo.Interface_Example_01.TypeC;
using Demo.Interface_Example_02;
using System.Text;
using Demo.Built_In_Interfaces;

namespace Demo
{
    internal class Program
    {
        static void PrintFiveNumberFromSeries(ISeries series)
        {
            if (series is not null)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(series.Current);
                    series.GetNext();
                }
                series.Reset();
            }
            else
            {
                return;
            }
        }
        static void Main(string[] args)
        {
            #region Binding
            //TypeA typeARef = new TypeB(1, 2);
            //typeARef.A = 10;
            ////typeARef.B = 20; // Invalid
            //typeARef.MyFun01(); // Static Binding - Called Based On Reference Type
            //typeARef.MyFun02(); // Dynamic Binding - Called Based On Object Type

            //TypeA typeARef = new TypeC(1, 2, 3);
            //typeARef.A = 10;
            ////typeARef.B = 20; // Invalid
            ////typeARef.C = 30; // Invalid

            //typeARef.MyFun01(); // Static Binding
            //typeARef.MyFun02(); // Dynamic Binding

            //TypeB typeBRef = new TypeC(1, 2, 3); // Direct Base 
            //typeBRef.A = 10;
            //typeBRef.B = 20;
            ////typeBRef.C = 30; // Invalid

            //typeBRef.MyFun01(); // Static Binding
            //typeBRef.MyFun02(); // Dynaimc Binding

            //TypeA typeARef = new TypeD(1, 2, 3, 4);
            //typeARef.MyFun01(); // Static Binding - TypeA
            //typeARef.MyFun02(); // Dynamic Binding - TypeC

            //TypeB typeBRef = new TypeD(1, 2, 3, 4);
            //typeBRef.MyFun01(); // Static Binding - TypeB
            //typeBRef.MyFun02(); // Dynamic Binding - Typec

            //TypeC typeCRef = new TypeD(1, 2, 3, 4);
            //typeCRef.MyFun01(); // Static Binding - TypeC
            //typeCRef.MyFun02(); // Dynamic Bindig - TypeC


            //TypeA typeARef = new TypeE(1, 2, 3, 4, 5); // indirect parent
            //TypeB typeBRef = new TypeE(1, 2, 3, 4, 5); // indirect parent
            //TypeC typeCRef = new TypeE(1, 2, 3, 4, 5); // indirect parent
            //TypeD typeDRef = new TypeE(1, 2, 3, 4, 5); // direct parent

            //typeARef.MyFun02(); // TypeC
            //typeBRef.MyFun02(); // TypeC
            //typeCRef.MyFun02(); // TypeC
            //typeDRef.MyFun02(); // TypeE 
            #endregion

            #region Interface

            //IType refType;
            //// Declare For Reference From Type "IType"
            //// This Reference Can Refer To An Object From Any Type Implemenet Interface "IType"
            //// CLR wil allocate 4 bytes at stack for reference 

            ////refType = new IType(); // Invalid

            //refType = new Type();
            //refType.MyProperty = 10;
            //refType.MyMethod();
            //refType.Print();

            //Type typeObj = new Type();
            //typeObj.MyProperty = 10;
            //typeObj.MyMethod();
            ////typeObj.Print(); // Invalid

            #endregion

            #region Example 01
            //TypeA typeAObj = new TypeA();
            //PrintFiveNumberFromSeries(typeAObj);
            //Console.WriteLine("-----------------------------");
            //TypeB typeBObj = new TypeB();
            //PrintFiveNumberFromSeries(typeBObj);

            ////TypeC typeCObj = new TypeC();
            ////PrintFiveNumberFromSeries(typeCObj); // Invalid - Because it not implemented ISeries

            #endregion

            #region Example 02
            //Car carObj = new Car();
            //carObj.Speed = 100;
            //carObj.Forward();
            //carObj.Backward();
            //carObj.Left();
            //carObj.Right();

            //AirPlane airplaneObj = new AirPlane();
            //airplaneObj.Speed = 200;
            //airplaneObj.Forward(); // Valid [Implemented Implicitly]
            ////airplaneObj.Backward(); // Invalid [Implemented Explicitly]

            //IMoveOnGround moveAirplaneOnGround = new AirPlane();
            //moveAirplaneOnGround.Forward();
            //moveAirplaneOnGround.Backward();
            //moveAirplaneOnGround.Left();
            //moveAirplaneOnGround.Right();


            //IMoveOnAir moveAirplaneOnAir = new AirPlane();
            ////moveAirplaneOnAir.Speed = 100; // Invalid
            //moveAirplaneOnAir.Forward();
            //moveAirplaneOnAir.Backward();
            //moveAirplaneOnAir.Left();
            //moveAirplaneOnAir.Right();


            #endregion

            #region Shallow Copy And Deep Copy

            #region Array Of Value Type
            //int[] Arr01 = { 1, 2, 3 };
            //int[] Arr02 = new int[3]; // {0, 0, 0}

            //Console.WriteLine($"HashCode of Arr01 = {Arr01.GetHashCode()}");
            //Console.WriteLine($"HashCode of Arr02 = {Arr02.GetHashCode()}");

            #region Shallow Copy
            //Arr02 = Arr01; // Shallow Copy 
            //// Copy Value Of Arr01 To Arr02
            //// Copy Addresses - Happended In Stack
            //// [Arr01, Arr02] Have Same Value
            //// [Arr01, Arr02] => Refere Same Object
            //Console.WriteLine("After Shallow Copy");
            //Console.WriteLine($"HashCode of Arr01 = {Arr01.GetHashCode()}");
            //Console.WriteLine($"HashCode of Arr02 = {Arr02.GetHashCode()}");
            //Console.WriteLine("---------------------");
            //Console.WriteLine($"Arr01[0] = {Arr01[0]}");
            //Console.WriteLine($"Arr02[0] = {Arr02[0]}");
            //Arr01[0] = 100;
            //Console.WriteLine("---------------------");
            //Console.WriteLine($"Arr01[0] = {Arr01[0]}");
            //Console.WriteLine($"Arr02[0] = {Arr02[0]}"); 
            #endregion

            #region Deep Copy

            //Arr02 = (int[])Arr01.Clone(); // Deep Copy
            //// Happended In Heap
            //// Create new Object with Different And New Identity then return the new address
            //// the new object will have the same object state of caller 
            //Console.WriteLine("After Deep Copy");
            //Console.WriteLine($"HashCode of Arr01 = {Arr01.GetHashCode()}");
            //Console.WriteLine($"HashCode of Arr02 = {Arr02.GetHashCode()}");
            //Console.WriteLine("---------------------");
            //Console.WriteLine($"Arr01[0] = {Arr01[0]}");
            //Console.WriteLine($"Arr02[0] = {Arr02[0]}");
            //Arr01[0] = 100;
            //Console.WriteLine("---------------------");
            //Console.WriteLine($"Arr01[0] = {Arr01[0]}");
            //Console.WriteLine($"Arr02[0] = {Arr02[0]}");

            #endregion

            #endregion

            #region Array Of Reference Type

            #region Array Of Immutable Type [String]
            //string[] names01 = { "Omar", "Amr" }; // {RefString01, RefString02}
            //string[] names02 = new string[2]; // {null, null}

            //Console.WriteLine($"HashCode Of Name01 = {names01.GetHashCode()}");
            //Console.WriteLine($"HashCode Of Name02 = {names02.GetHashCode()}");

            #region Shallow Copy

            //names02 = names01; // shallow copy
            //// copy value names01 => names02
            //// [names01, names02] => Have Same Value
            //// [names01, names02] => Refere To Same Object 
            //Console.WriteLine("After Shallow Copy");
            //Console.WriteLine($"HashCode Of Name01 = {names01.GetHashCode()}");
            //Console.WriteLine($"HashCode Of Name02 = {names02.GetHashCode()}");

            //Console.WriteLine($"names01[0] = {names01[0]}");
            //Console.WriteLine($"names02[0] = {names02[0]}");

            //names01[0] = "Soma";
            //Console.WriteLine("After Changing");
            //Console.WriteLine($"names01[0] = {names01[0]}");
            //Console.WriteLine($"names02[0] = {names02[0]}");

            #endregion


            #region Deep Copy
            //names02 = (string[])names01.Clone(); // Deep copy
            //// Create New Instance With Different And New Identity
            //// Copy from object state [Data] of caller [names01]
            //// then return new Identity

            //Console.WriteLine("After Deep Copy");
            //Console.WriteLine($"HashCode Of Name01 = {names01.GetHashCode()}");
            //Console.WriteLine($"HashCode Of Name02 = {names02.GetHashCode()}");

            //Console.WriteLine($"names01[0] = {names01[0]}");
            //Console.WriteLine($"names02[0] = {names02[0]}");

            //names01[0] = "Soma";
            //Console.WriteLine("After Changing");
            //Console.WriteLine($"names01[0] = {names01[0]}");
            //Console.WriteLine($"names02[0] = {names02[0]}");
            #endregion

            #endregion

            #region Array Of Mutable Type [Stringbuilder]

            //StringBuilder[] names01 = new StringBuilder[1];
            ////names01[0] = "Omar"; // Invalid
            //// names01[0].Append("Omar"); // NullReferenceException
            //names01[0] = new StringBuilder();
            //names01[0].Append("Omar");
            // Syntax Swagger (Collection Expression - C#12 Features)
            //StringBuilder[] names01 = [new StringBuilder("Omar")];
            //StringBuilder[] names02 = new StringBuilder[1];

            //Console.WriteLine($"HashCode Of names01 = {names01.GetHashCode()}");
            //Console.WriteLine($"HashCode Of names02 = {names02.GetHashCode()}");


            #region Shallow Copy

            //names02 = names01; // shallow copy
            //Console.WriteLine("After Shallow Copy");
            //Console.WriteLine($"HashCode Of names01 = {names01.GetHashCode()}");
            //Console.WriteLine($"HashCode Of names02 = {names02.GetHashCode()}");

            //Console.WriteLine("-----------------------------------");
            //Console.WriteLine($"names01[0] = {names01[0]}");
            //Console.WriteLine($"names02[0] = {names02[0]}");


            //names01[0].Append(" Said");
            //Console.WriteLine("After Chaing");
            //Console.WriteLine($"names01[0] = {names01[0]}");
            //Console.WriteLine($"names02[0] = {names02[0]}");
            #endregion

            #region Deep Copy
            //names02 = (StringBuilder[])names01.Clone(); // Deep copy
            //Console.WriteLine("After Shallow Copy");
            //Console.WriteLine($"HashCode Of names01 = {names01.GetHashCode()}");
            //Console.WriteLine($"HashCode Of names02 = {names02.GetHashCode()}");

            //Console.WriteLine("-----------------------------------");
            //Console.WriteLine($"names01[0] = {names01[0]}");
            //Console.WriteLine($"names02[0] = {names02[0]}");


            //names01[0].Append(" Said");
            //Console.WriteLine("After Chaing");
            //Console.WriteLine($"names01[0] = {names01[0]}");
            //Console.WriteLine($"names02[0] = {names02[0]}");
            #endregion

            #endregion

            #endregion

            #endregion

            #region IClonable
            //Employee employee01 = new Employee() { Id = 10, Name = "Omar", Salary = 5000 };
            //Employee employee02 = new Employee() { Id = 20, Name = "Mona", Salary = 8000 };
            //Console.WriteLine(employee01);
            //Console.WriteLine($"employee01 => {employee01.GetHashCode()}");
            //Console.WriteLine(employee02);
            //Console.WriteLine($"employee02 => {employee02.GetHashCode()}");
            //employee02 = (Employee)employee01.Clone();
            //// Clone Method : Generate New Object With Same Object State But With Different Identity
            //Console.WriteLine("After Deep Copy");
            //Console.WriteLine(employee01);
            //Console.WriteLine($"employee01 => {employee01.GetHashCode()}");
            //Console.WriteLine(employee02);
            //Console.WriteLine($"employee02 => {employee02.GetHashCode()}");

            //// 2nd Way To Do Deep Copy [Copy Constructor]
            //employee02 = new Employee(employee01); 
            #endregion

            #region IComparable
            ////int[] numbers = { 4, 5, 6, 9, 1, 2, 3, 4 };
            ////Array.Sort(numbers);
            ////foreach (int item in numbers)
            ////    Console.WriteLine(item);

            //Employee[] employees = {
            //    new Employee() {Id = 10, Name = "Omar", Salary = 6000},
            //    new Employee() {Id = 20, Name = "Ahmed", Salary = 10000 },
            //    new Employee() {Id = 30, Name = "Sama", Salary = 4000 },
            //    new Employee() {Id = 40, Name = "May", Salary = 5000}
            //};

            //Array.Sort(employees); // Sorting Employees Based In Salary In Ascending Order
            //Array.Reverse(employees); // To Apply Desc
            //foreach(Employee employee in employees)
            //    Console.WriteLine(employee);


            #endregion

            #region IComparer
            
            //Employee[] employees = {
            //    new Employee() {Id = 10, Name = "Omar", Salary = 6000},
            //    new Employee() {Id = 20, Name = "Ahmed", Salary = 10000 },
            //    new Employee() {Id = 30, Name = "Sama", Salary = 4000 },
            //    new Employee() {Id = 40, Name = "May", Salary = 5000}
            //};
            //// To Control Sort Based On What
            //Array.Sort(employees, new EmployeeNameComparer());
            //foreach(Employee employee in employees) Console.WriteLine(employee);
            

            #endregion
        }
    }
}
