using Common;
using Demo.Inheritance;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Class
            #region Example 01
            //Car c1;
            //// Declare For Special Variable | Reference From Type "Car"
            //// c1 is Reference Refereing to default value of reference type => null
            //// this reference "c1" can refer to an instance from type car or any type inherit from car
            //// CLR willallocate 4 byte at stack for reference "c1"

            //c1 = new Car(10, "BMW", 290);
            ////c1 = new(10, "BMW", 290); // Syntax Swagger - not recomended
            //// create object | instance from class car
            //// Allocate Required Bytes At Heap For Object
            //// Initialize Allocated Bytes With Default Value of its type
            //// Call User Defined Constructor [if exists] if not call default parameterless constructor
            //// Assin address of Allocated Object To Reference "c1"

            //Console.WriteLine(c1); 
            #endregion

            #region Example 02
            //Car c1 = new Car(10);
            //Console.WriteLine(c1);

            //Car c2 = new Car(20, "BYD");
            //Console.WriteLine(c2);

            //Car c3 = new Car(30, "BMW", 250);
            //Console.WriteLine(c3);
            #endregion

            #endregion


            #region Inheritance
            //Parent parentObj = new Parent(1, 2);
            //parentObj.X = 10;
            //parentObj.Y = 20;
            //Console.WriteLine(parentObj); // X = 10, Y = 20
            //Console.WriteLine(parentObj.Product()); // 200
            //parentObj.MyFun(); // I Am Parent

            //Child childObj = new Child(1, 2, 3);
            //childObj.X = 10;
            //childObj.Y = 20;
            //childObj.Z = 30;
            //Console.WriteLine(childObj); 
            //Console.WriteLine(childObj.Product());
            //childObj.MyFun();

            #endregion

            #region Access Modifiers 

            #region Protected Without Inheritance
            //TypeA typeAObj  = new TypeA();
            //typeAObj.A = 1; // invalid [private] within class only
            //typeAObj.B = 2; // valid [internal] within calss and same project only
            //typeAObj.C = 3; // valid [public] within class, project and outside project

            //typeAObj.X = 10; // invalid [private protected]  within class only
            //typeAObj.Y = 20; // invalid [protected] within class only
            //typeAObj.Z = 30; // vali [internal protected] within class and same project

            #endregion

            #region With Inheritance
            //TypeB typeBObj = new TypeB();
            //typeBObj.B = 1; // Invalid - [Internal]
            //typeBObj.C = 2; // Valid - [Public]

            //typeBObj.X = 10; // Invalid - [Private]
            //typeBObj.Y = 20; // Invalid - [Private]
            //typeBObj.Z = 30; // Invalid - [Internal]

            //TypeB typeBObj = new TypeB();
            //typeBObj.C = 3; // Valid 
            //typeBObj.Y = 20; // Invalid [Private]
            //typeBObj.Z = 30; // Invalid [Private]

            #endregion

            #endregion


        }
    }
}
