using Demo.Abstraction;
using Demo.Partial;
using Demo.Sealed;
using Demo.Static;
using System.ComponentModel.Design;
using System.Drawing;
using Rectangle = Demo.Abstraction.Rectangle;

namespace Demo
{
    internal class Program
    {
        static void ProcessShape(Shape shape)
        {
            if (shape is not null)
            {
                Console.WriteLine($"Area Of Shape = {shape.CalcArea()}");
                Console.WriteLine($"Perimeter Of Shape = {shape.Perimeter}");

            }
        }

        static void Draw2dShape(ITwoDDraw shape)
        {
            shape.Draw();
        }

        static void Draw3dShape(IThreeDDraw shape)
        {
            shape.Draw();
        }

        static void Main(string[] args)
        {
            #region Abstraction
            ////Shape shape = new Shape(); // Invalid
            ////// You Can Not Create An Instance From Abstract Class
            ////// But we can create Reference From Abstract Class Refer To An object
            ////// From class that inherit and implement abstract class
            ////Shape shapeRef = new Rectangle();

            //Rectangle rectangle = new Rectangle(10, 20);
            ////Console.WriteLine($"Area Of Rectangle = {rectangle.CalcArea()}");
            ////Console.WriteLine($"Perimeter Of Rectangle = {rectangle.Perimeter}");
            //ProcessShape(rectangle);

            //Square square = new Square(10);
            ////Console.WriteLine($"Area Of Square = {square.CalcArea()}");
            ////Console.WriteLine($"Perimeter Of Squre = {square.Perimeter}");
            //ProcessShape(square);   

            //Circle circle = new Circle(10);
            ////Console.WriteLine($"Area Of Circle = {circle.CalcArea()}");
            ////Console.WriteLine($"Perimeter Of Circle = {circle.Perimeter}");
            //ProcessShape(circle); 
            #endregion

            #region Static [Methods - Attributes - Property]
            ////Utility u01 = new Utility(1, 2);
            ////Console.WriteLine($"Convert From Meter To CM = {u01.MeterToCm(1.2)}");
            ////u01.X = 10;
            ////u01.Y = 20;
            ////Console.WriteLine("After Chame Value Of x, y");
            ////Console.WriteLine($"Convert From Meter To CM = {u01.MeterToCm(1.2)}");
            ////// the result of calling method [MeterToCm] does not change by changing object state [x, y]

            ////Utility u02 = new Utility(100, 200);
            ////Console.WriteLine("Different Object");
            ////Console.WriteLine($"Convert From Meter To CM = {u02.MeterToCm(1.2)}");
            ////// the result of calling method [MeterToCm] Will not differ when you call it from different object

            ////Console.WriteLine($"Convert From Meter To CM = {Utility.MeterToCm(1.2)}");
            ////Console.WriteLine($"Area Of Circle = {Utility.CalculateCircleArea(10)}");

            ////Utility u = new Utility(1, 2);
            ////Console.WriteLine(u.Pi);

            //Console.WriteLine(Utility.Pi); 
            #endregion

            #region Static Constructor
            ////Console.WriteLine(Utility.MeterToCm(1.2));
            ////Utility u = new Utility(1, 2);
            //Test test = new Test(1, 2);

            //Utility u = new Utility(1, 2); // Call Static Constructor
            //Console.WriteLine(Utility.MeterToCm(1.2)); // Not Call Static Constructor [Because Called Once]

            #endregion

            #region Sealed [Class - Method]

            //Parent parent = new Parent();
            //parent.Salary = 10_000;
            //Console.WriteLine(parent.Salary);
            //parent.MyFun();

            //Child child = new Child();
            //child.Salary = 10_000;
            //Console.WriteLine(child.Salary);
            //child.MyFun();

            //GrandChild grandChild = new GrandChild();
            //grandChild.Salary = 10_000;
            //Console.WriteLine(grandChild.Salary);
            //grandChild.MyFun();

            //Parent parentRef = new GrandChild();
            //parentRef.Salary = 10_000;
            //Console.WriteLine(parentRef.Salary);
            //parentRef.MyFun();
            #endregion

            #region Partial [Class - Method]
            Employee employee = new Employee();
            //employee.Id = 10;
            //employee.Name = "Mona";
            //employee.Age = 30;
            //employee.Print(); // Hello From Employee

            employee.DoSomeThind();

            #endregion
        }
    }
}
