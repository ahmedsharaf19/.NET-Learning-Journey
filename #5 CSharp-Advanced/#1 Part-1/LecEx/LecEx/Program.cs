namespace LecEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Swap Example
            #region Non-Generic
            //int a = 10, b = 20;
            //Console.WriteLine($"A = {a}");
            //Console.WriteLine($"B = {b}");
            //Helper.Swap(ref a, ref b);
            //Console.WriteLine("After Swapping");
            //Console.WriteLine($"A = {a}");
            //Console.WriteLine($"B = {b}");

            //decimal M = 10.1M, L = 20.20M;
            //Console.WriteLine($"M = {M}");
            //Console.WriteLine($"L = {L}");
            //Helper.Swap(ref M, ref L);
            //Console.WriteLine("after swapping");
            //Console.WriteLine($"M = {M}");
            //Console.WriteLine($"L = {L}");

            //Point p1 = new Point(10, 20);
            //Point p2 = new Point(100, 200);
            //Console.WriteLine($"Point 01 = {p1}");
            //Console.WriteLine($"Point 02 = {p2}");
            //Helper.Swap(ref p1, ref p2);
            //Console.WriteLine("After Swapping");
            //Console.WriteLine($"Point 01 = {p1}");
            //Console.WriteLine($"Point 02 = {p2}"); 
            #endregion

            #region Generic
            //int a = 10, b = 20;
            //Console.WriteLine($"A = {a}");
            //Console.WriteLine($"B = {b}");
            //Helper.Swap<int>(ref a, ref b);
            //Console.WriteLine("After Swapping");
            //Console.WriteLine($"A = {a}");
            //Console.WriteLine($"B = {b}");

            //decimal M = 10.1M, L = 20.20M;
            //Console.WriteLine($"M = {M}");
            //Console.WriteLine($"L = {L}");
            //Helper.Swap(ref M, ref L);
            //Console.WriteLine("after swapping");
            //Console.WriteLine($"M = {M}");
            //Console.WriteLine($"L = {L}");

            //Point p1 = new Point(10, 20);
            //Point p2 = new Point(100, 200);
            //Console.WriteLine($"Point 01 = {p1}");
            //Console.WriteLine($"Point 02 = {p2}");
            //Helper.Swap<Point>(ref p1, ref p2);
            //Console.WriteLine("After Swapping");
            //Console.WriteLine($"Point 01 = {p1}");
            //Console.WriteLine($"Point 02 = {p2}");
            #endregion
            #endregion

            #region Linear Search


            //int[] numbers = { 9, 5, 8, 7, 5, 6, 8, 3, 1, 2 };
            //int Result = Helper.LinearSearch(numbers, 6);
            //Console.WriteLine(Result);

            //Point[] points =
            //{
            //    new Point(1, 2),
            //    new Point(10, 20),
            //    new Point(100, 200),
            //    new Point(1000, 2000)
            //};

            //Employee employee01 = new Employee(10, "Mona", 9000);
            //Employee employee02 = new Employee(20, "Amr", 4000);

            //Console.WriteLine($"Hash Code of employee 01 = {employee01.GetHashCode()}");
            //Console.WriteLine($"Hash Code of employee 02 = {employee02.GetHashCode()}");

            //if (employee01 == employee02) // if (employee01.Equals(employee02)) 
            //    Console.WriteLine("Equals");
            //else
            //    Console.WriteLine("Not Equals");

            //Employee[] employees =
            //{
            //    new Employee(10, "Omar", 4000),
            //    new Employee(20, "Mai", 10000),
            //    new Employee(30, "Amr", 7000),
            //    new Employee(40, "Samar", 9000),
            //    new Employee(50, "Mohamed", 2000),
            //};

            //Employee employee01 = new Employee(30, "Amr", 7000);
            //int result = Helper<Employee>.LinearSearch(employees, employee01);
            //Console.WriteLine($"Index = {result}");

            #endregion

            #region Equals - GetHashCode()
            //Employee employee01 = new Employee(10, "Omar", 1000);
            //Employee employee02 = new Employee(10, "Omar", 1000);

            ////if (employee01 == employee02) // By Default Compare references
            //if (employee01.Equals(employee02)) // By Default Compare references
            //// overridden to compare object state
            //{
            //    Console.WriteLine("Equals");
            //}
            //else Console.WriteLine("Not Equals");

            //// By Default Generate To HashCode Based on Address
            //Console.WriteLine($"Hash Code Of employee01 = {employee01.GetHashCode()}");
            //Console.WriteLine($"Hash Code Of employee02 = {employee02.GetHashCode()}");

            #endregion

            #region Is - As Operator
            //Employee empployee01 = new Employee(10, "Mona", 5000);
            ////Employee empployee02 = new Employee(10, "Mona", 5000);
            //Employee empployee02 = null;
            //Console.WriteLine(empployee01?.Equals(empployee02));

            #endregion

            #region IEquatable
            //Employee[] employees =
            //{
            //    new Employee(10, "Mona", 4000),
            //    new Employee(20, "Amr", 7000),
            //    new Employee(30, "Samy", 9000),
            //    new Employee(40, "Rawan", 2000)
            //};
            //Employee employee01 = new Employee(30, "Samy", 9000);
            //int Result = Helper<Employee>.LinearSearch(employees, employee01);
            //Console.WriteLine($"Index = {Result}"); 
            #endregion

            #region IEqualityComparer
            //Employee[] employees =
            //{
            //    new Employee(10, "Mona", 4000),
            //    new Employee(20, "Amr", 7000),
            //    new Employee(30, "Samy", 9000),
            //    new Employee(40, "Rawan", 2000)
            //};
            ////Employee employee01 = new Employee(30, "Samy", 9000);
            ////int Result = Helper<Employee>.LinearSearch(employees, employee01, new EmployeeNameEqaulityComparer());
            ////Console.WriteLine($"Index = {Result}");

            //Employee employee01 = new Employee(30, "", 0);
            //int Result = Helper<Employee>.LinearSearch(employees, employee01, new EmployeeIdEqualityComparer());
            //Console.WriteLine($"Index = {Result}"); 
            #endregion

            #region BubbleSort
            //int[] numbers = { 8, 4, 9, 7, 6, 10, 5, 3, 1, 2 };

            //Helper<int>.BubbleSort(numbers);
            //foreach(int number in numbers) 
            //    Console.Write(number + " ");


            //Employee[] employees =
            //{
            //    new Employee(10, "Mona", 4000),
            //    new Employee(20, "Amr", 7000),
            //    new Employee(30, "Samy", 9000),
            //    new Employee(40, "Rawan", 2000)
            //};

            ////Helper<Employee>.BubbleSort(employees);
            ////foreach (Employee employee in employees)
            ////    Console.WriteLine(employee);

            //Helper<Employee>.BubbleSort(employees, new EmployeeNameComparer());
            //foreach (Employee employee in employees)
            //    Console.WriteLine(employee); 

            #endregion


        }
    }
}
