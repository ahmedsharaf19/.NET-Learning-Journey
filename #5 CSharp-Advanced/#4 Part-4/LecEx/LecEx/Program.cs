using System.Collections;

namespace LecEx
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region HashTable
            //Hashtable PhoneNote = new Hashtable();
            //PhoneNote.Add("Mona", 111);
            ////PhoneNote.Add(null, 222); // invalid in run-time
            ////PhoneNote.Add("Ahmed", null); // valid
            ////PhoneNote.Add("Mona", 111); // Invalid - Duplicated Key
            //PhoneNote.Add("Salma", 222);
            //PhoneNote.Add("Amr", 333);
            //Hashtable PhoneNote = new Hashtable
            //{
            //    //{"Mona", 111},
            //    //{"Salma", 222 },
            //    //{"Amr", 333 }
            //    //// Using Indexer
            //    ["Mona"] = 111,
            //    ["Amr"] = 222,
            //    ["Salma"] = 333
            //};

            ////Hashtable PhoneNote = new Hashtable(new StringEqualityComparer())
            ////{
            ////    ["Mona"] = 111,
            ////    ["Amr"] = 222,
            ////    ["Salma"] = 333
            ////};

            #region Iteration On HashTable
            //foreach (DictionaryEntry i in PhoneNote)
            //    //Console.WriteLine($"{i} ");
            //    Console.WriteLine($"Person Name = {i.Key}, Number = {i.Value}");

            //foreach(string name in PhoneNote.Keys)
            //        Console.WriteLine(name);
            //Console.WriteLine();
            //foreach (int num in PhoneNote.Values)
            //    Console.WriteLine(num); 
            #endregion

            #region Indexer

            ////// Using Indexer To Get Value
            ////Console.WriteLine(PhoneNote["Amr"]);

            ////// Using Indexer To Set Value
            ////PhoneNote["Salma"] = 1000;
            ////Console.WriteLine(PhoneNote["Salma"]);

            //// Using Indexer To Add Element 
            //// If Existed Key => Update Value
            //PhoneNote["Mariam"] = 1000;


            #endregion

            #region Add New Element

            ////PhoneNote.Add("Mona", 500); // Exception - Key Existed
            //if (!PhoneNote.ContainsKey("Mona"))
            //    PhoneNote.Add("Mona", 500); // Safe Code

            //PhoneNote.Add("mona", 500); // Valid mona != Mona
            //// If We Need Change Default Compaere We Create Custom Comparer

            //PhoneNote.Add("mona", 500);

            #endregion
            #endregion

            #region Dictionary<Tkey, TValue>

            //Dictionary<string, int> PhoneNote = new Dictionary<string, int>()
            //{
            //    {"Mona", 111 },
            //    {"Ali", 222 },
            //    {"Salma", 333 },
            //};


            #region Iteration on Dictionary

            //foreach (KeyValuePair<string, int> item in PhoneNote)
            //    Console.WriteLine(item.Key, item.Value);

            //foreach (string key in PhoneNote.Keys)
            //    Console.WriteLine(key);

            //foreach (int value in PhoneNote.Values)
            //    Console.WriteLine(value);

            #endregion

            #region Indexer

            //// Using Indexer As Getter
            //Console.WriteLine(PhoneNote["Mona"]);

            //// Using Indexer As Setter
            //PhoneNote["Mona"] = 1000;
            //Console.WriteLine(PhoneNote["Mona"]);

            //// Using Indexer To Add - if not found
            //PhoneNote["Sama"] = 1000;


            // Safe Getter
            //bool result = PhoneNote.TryGetValue("Sama", out int number);
            //Console.WriteLine(result);
            //Console.WriteLine(number);

            // Using Indexer As Getter
            //if (PhoneNote.ContainsKey("Sama"))
            //    Console.WriteLine(PhoneNote["Mona"]);

            #endregion

            #region Constructors

            // Constructor Take Any Thing Implemenet IEnumrable
            //KeyValuePair<string, int>[] array =
            //{
            //    new KeyValuePair<string, int>("Mona", 123),
            //    new KeyValuePair<string, int>("Ahmed", 987)
            //};

            //Dictionary<string, int> PhoneNote = new Dictionary<string, int>(array);
            //PhoneNote.Add("mona", 456);
            //foreach(var item  in PhoneNote)
            //    Console.WriteLine(item);

            // Constructor Take Custom Comparer
            //Dictionary<string, int> PhoneNote = new Dictionary<string, int>(array, new StringEqualityComparer());




            #endregion

            #region User-Defined Data Type

            //Employee employee01 = new Employee(10, "Omar", 10000);
            //Employee employee02 = new Employee(20, "Salma", 5000);
            //Employee employee03 = new Employee(30, "Ali", 8000);

            //Dictionary<Employee, string> employees = new()
            //{
            //    [employee01] = "1st",
            //    [employee02] = "2nd",
            //    [employee03] = "3rd"
            //};

            //Employee employee04 = new Employee(30, "Ali", 8000);
            //employees.Add(employee04, "4th"); // valid - using comparer defualt

            //foreach (var item in employees)
            //    Console.WriteLine(item);

            //// use default implementation of Employee
            //Employee employee04 = new Employee(30, "Ali", 8000);
            //employees.Add(employee04, "4th"); // Object Is Existed in Dictionary
            //foreach (var item in employees)
            //    Console.WriteLine(item);


            // Custom Comparer
            //Dictionary<Employee, string> employees = new(new EmployeeIdEqulityComparer())
            //{
            //    [employee01] = "1st",
            //    [employee02] = "2nd",
            //    [employee03] = "3rd"
            //};
            //Employee employee04 = new Employee(30, "Amr", 5000);
            //employees.Add(employee04, "4th"); // Id is existed
            //foreach (var item in employees)
            //    Console.WriteLine(item);

            #endregion

            #endregion

            #region SortedDictionary<Tkey, TValue>

            //SortedDictionary<string, int> PhoneNote = new SortedDictionary<string, int>()
            //{
            //    ["Salma"] = 111,
            //    ["Omar"] = 222,
            //    ["Rawan"] = 333,
            //    ["Yasmin"] = 444,
            //    ["Ali"] = 555
            //};

            //foreach(var item in PhoneNote)
            //    Console.WriteLine(item);

            #region Buiot-In DataType
            //SortedDictionary<string, int> PhoneNote = new SortedDictionary<string, int>(new StringComparer())
            //{
            //    ["Salma"] = 111,
            //    ["Omar"] = 222,
            //    ["Rawan"] = 333,
            //    ["Yasmin"] = 444,
            //    ["Ali"] = 555
            //};

            //foreach (var item in PhoneNote)
            //    Console.WriteLine(item);
            #endregion

            #region User-Defined Datatype
            // Must Implement IComparable
            //Employee employee01 = new Employee(10, "Omar", 10000);
            //Employee employee02 = new Employee(20, "Salma", 5000);
            //Employee employee03 = new Employee(30, "Ali", 8000);

            //SortedDictionary<Employee, string> SortedEmployees = new ()
            //{
            //    [employee03] = "1st",
            //    [employee01] = "2nd",
            //    [employee02] = "3rd",
            //};

            //foreach (var item in SortedEmployees)
            //    Console.WriteLine(item);

            #endregion

            #region Custom Comparer

            //Employee employee01 = new Employee(10, "Omar", 10000);
            //Employee employee02 = new Employee(20, "Salma", 5000);
            //Employee employee03 = new Employee(30, "Ali", 8000);

            //SortedDictionary<Employee, string> SortedEmployees = new(new EmployeeNameComparer())
            //{
            //    [employee03] = "1st",
            //    [employee01] = "2nd",
            //    [employee02] = "3rd",
            //};

            //foreach (var item in SortedEmployees)
            //    Console.WriteLine(item);

            #endregion

            #endregion

            #region SortedList<TKey, TValue>

            //SortedList<string, int> PhoneNote = new SortedList<string, int>()
            //{
            //    ["Salma"] = 111,
            //    ["Omar"] = 222,
            //    ["Rawan"] = 333,
            //    ["Yasmin"] = 444,
            //    ["Ali"] = 555
            //};
            ////foreach (var item in PhoneNote)
            ////    Console.WriteLine(item);

            //// Get Value At Index
            //int number = PhoneNote.GetValueAtIndex(1);

            //// Get Key At Index
            //string Name = PhoneNote.GetKeyAtIndex(1);

            //Console.WriteLine(Name);
            //Console.WriteLine(number);


            #endregion

            #region HashSet<T>

            #region Built-In DataType
            ////HashSet<string> names = new HashSet<string>();
            ////names.Add("Ahmed");
            ////names.Add("Omar");
            ////names.Add("Yasmin");
            ////names.Add("ahmed");
            ////names.Add("Yasmin");

            ////foreach(string name in names)
            ////    Console.WriteLine(name);

            //HashSet<string> names = new HashSet<string>(new StringEqualityComparer());
            //names.Add("Ahmed");
            //names.Add("Omar");
            //names.Add("Yasmin");
            //names.Add("ahmed");
            //names.Add("Yasmin");

            //foreach (string name in names)
            //    Console.WriteLine(name); 
            #endregion

            #region User Defined DataType

            #region Example 01
            //HashSet<Employee> employees = new HashSet<Employee>()
            //{
            //    new Employee(10, "Omar", 10000),
            //    new Employee(20, "Mona", 5000),
            //    new Employee(10, "Omar", 10000),
            //    new Employee(30, "Amr", 6000),
            //    new Employee(10, "Omar", 10000),
            //    new Employee(20, "Mona", 5000),


            //};
            //foreach(Employee emp in employees)
            //    Console.WriteLine(emp); 
            #endregion

            #region Example 02

            //HashSet<Car> cars = new HashSet<Car>();
            //cars.Add(new Car(10, "BMW", 290));
            //cars.Add(new Car(20, "Audi", 190));
            //cars.Add(new Car(30, "BYD", 200));
            //cars.Add(new Car(10, "BMW", 290));
            //cars.Add(new Car(30, "BYD", 200));
            //cars.Add(new Car(10, "BMW", 290));
            //cars.Add(new Car(20, "Audi", 190));

            //Car[] cars01 =
            //{
            //    new Car(10, "BMW", 290),
            //    new Car(20, "Audi", 190),
            //    new Car(30, "BYD", 200),
            //    new Car(10, "BMW", 290),
            //    new Car(30, "BYD", 200),
            //    new Car(10, "BMW", 290),
            //    new Car(20, "Audi", 190)
            //};
            //cars = new HashSet<Car>(cars01);


            //foreach(Car car in cars)
            //    Console.WriteLine(car);



            #endregion



            #endregion

            #region Custom Comparer

            //HashSet<Car> cars = new HashSet<Car>(new CarEqualityComparer());
            //cars.Add(new Car(10, "BMW", 290));
            //cars.Add(new Car(20, "Audi", 190));
            //cars.Add(new Car(30, "BYD", 200));
            //cars.Add(new Car(10, "BMW", 290));
            //cars.Add(new Car(30, "BYD", 200));
            //cars.Add(new Car(10, "BMW", 200));
            //cars.Add(new Car(20, "Audi", 190));

            //foreach(Car car in cars)
            //    Console.WriteLine(car);

            #endregion

            #region Set Operations

            //HashSet<int> number01 = new HashSet<int>() { 1, 2, 3, 4, 5 };
            //HashSet<int> number02 = new HashSet<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //number01.Add(100);
            //number01.UnionWith(number02);
            //number01.IntersectWith(number02);
            //number01.ExceptWith(number02);
            //number01.SymmetricExceptWith(number02);
            //bool result = number01.IsSubsetOf(number02);
            //Console.WriteLine(result);

            //result = number01.IsProperSubsetOf(number02);
            //Console.WriteLine(result);

            //bool result = number01.IsSupersetOf(number02);
            //Console.WriteLine(result);

            //result = number01.IsProperSupersetOf(number02);
            //Console.WriteLine(result);

            //bool result = number01.Overlaps(number02);
            //Console.WriteLine(result);

            //result = number01.SetEquals(number02);
            //Console.WriteLine(result);

            //foreach (int number in number01)
            //    Console.Write($"{number} ");
            //Console.WriteLine("\n-----------------");
            //foreach(int number in number02) 
            //    Console.Write($"{number} ");

            #endregion

            #endregion

            #region SortedList<T>

            //SortedSet<int> numbers = new SortedSet<int>() { 4, 5, 6, 9, 3, 2, 1, 8, 7, 10 };
            ////SortedSet<int> numbers = new SortedSet<int>(new IntComparer()) { 4, 5, 6, 9, 3, 2, 1, 8, 7, 10 };


            ////SortedSet<int> Range = numbers.GetViewBetween(4, 8);
            ////foreach(var item in Range)
            ////    Console.WriteLine(item);


            ////int max = numbers.Max();
            ////int min = numbers.Min();
            ////Console.WriteLine(max);
            ////Console.WriteLine(min);

            ////foreach (var item in numbers)
            ////    Console.WriteLine(item);
            

            //SortedSet<Car> cars = new SortedSet<Car>();
            //cars.Add(new Car(10, "BMW", 220));
            //cars.Add(new Car(10, "BMW", 220));
            //cars.Add(new Car(10, "BMW", 220));
            //cars.Add(new Car(20, "BYD", 190));
            //cars.Add(new Car(30, "Audi", 250));
            //cars.Add(new Car(40, "BMW", 290));


            ////Car Max = cars.Max;
            ////Car Min = cars.Min;
            ////Console.WriteLine(Max);
            ////Console.WriteLine(Min);

            //SortedSet<Car> CarRange = cars.GetViewBetween(new Car(20, "BYD", 190), new Car(40, "BMW", 290));
            //foreach (Car car in CarRange)
            //    Console.WriteLine(car);


            #endregion

        }
    }
}
