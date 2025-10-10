using Demo.Encapsulation;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Struct
            #region Example 01
            //Point P1;
            //// Declare For Variable | Object From Type "Point"
            //// CLR Will Allocate 8 Unintialized Bytes At Stack
            ////Console.WriteLine(P1.X); // Invalid 
            //P1 = new Point();
            //// new => is just for constructor selection that will used to initialize P1 Attribute
            //Console.WriteLine($"P1.X : {P1.X}"); // 0
            //Console.WriteLine($"P1.Y : {P1.Y}"); // 1

            //P1 = new Point(10, 20);
            ////P1 = new(10, 20); // equal new point(10, 20) syntax swagger

            //Console.WriteLine($"P1.X : {P1.X}"); // 10
            //Console.WriteLine($"P1.Y : {P1.Y}"); // 20

            //P1 = new Point(100);
            //Console.WriteLine($"P1.X : {P1.X}"); // 100
            //Console.WriteLine($"P1.Y : {P1.Y}"); // 100

            //Console.WriteLine(P1); // call P1.ToString()  
            #endregion

            #region Example 02

            //Point P1 = new Point(1, 2);
            //Console.WriteLine($"P1 = {P1}");
            //Point P2 = new Point(100, 200);
            //Console.WriteLine($"P2 = {P2}");

            //P2 = P1;
            //Console.WriteLine("After Assign P2 = P1");
            //Console.WriteLine($"P1 = {P1}");
            //Console.WriteLine($"P2 = {P2}");

            //P1.X = 500;
            //P1.Y = 500;
            //Console.WriteLine("After Change P1.X = 500");
            //Console.WriteLine($"P1 = {P1}");
            //Console.WriteLine($"P2 = {P2}");

            #endregion

            #endregion

            #region Encapsulation

            //////Employee emp1 = new Employee(10, "Omar", 1000);
            //Employee emp1 = new Employee(name: "Omar", salary: 1000, id: 10);
            ////Console.WriteLine(emp1);

            ////emp1.Id = 20; // set Id Directly Through Attribute
            ////Console.WriteLine(emp1.Id); // get Id Directly Through Attribute

            ////emp1.SetName("Ahmed Mohammed"); // set name using setter method
            ////Console.WriteLine(emp1.GetName()); // get name using getter method

            //emp1.Salary = 5000; // set salary using property as a setter 
            //Console.WriteLine(emp1.Salary); // get salary using property as a getter


            #endregion

            #region Phonebook
            ////PhoneNotebook notebook = new PhoneNotebook(3);
            //////Console.WriteLine(notebook.Size);
            ////notebook.AddNewPerson(0, "Ali", 123);
            ////notebook.AddNewPerson(1, "Samy", 456);
            ////notebook.AddNewPerson(2, "Mona", 789);
            ////notebook.AddNewPerson(3, "Ahmed", 1010);

            ////int samysNumber = notebook.GetNumber("Samy");
            ////Console.WriteLine(samysNumber);
            ////notebook.SetNumber("Samy", 999);

            ////notebook["Samy"] = 101010; // set using indexer as a setter
            ////Console.WriteLine(notebook["Mona"]); // get using indexer as a getter

            ////string name = "Ahmed";
            ////Console.WriteLine(name[0]);
            //////name[0] = 'L'; // Invalid - Because indexer of string is read only  
            

            //PhoneNotebook notebook = new PhoneNotebook(3);
            //notebook.AddNewPerson(0, "Ali", 123);
            //notebook.AddNewPerson(1, "Samy", 456);
            //notebook.AddNewPerson(2, "Mona", 789);

            ////for(int i = 0; i < notebook.Size; i++)
            ////    Console.WriteLine(notebook[i]);

            ////foreach(var person in notebook) // need function GetElimenator()
            ////{
            ////    Console.WriteLine(person);
            ////}
            #endregion
        }
    }
}
