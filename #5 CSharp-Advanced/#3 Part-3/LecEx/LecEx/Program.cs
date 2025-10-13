namespace LecEx
{
    internal class Program
    {
        // Step 0 : Defining Delegate
        public delegate int StringFuncDelegate(string s);
        // New Delegate [Class]
        // Reference From This Delegate Can Refer To
        // Function or more [Pointer To Function]
        // This Function Can Be static function [class member function]
        // this function can be non static function
        // these function must be same signature of delegate
        // regardless function naming [method name, parameter name]
        // regardless access modifier
        static void Main(string[] args)
        {
            #region Delegate
            #region Example 01
            ////int x = StringFunctions.GetCountOfUpperCaseChar; // Invalid

            //// Step 1 : Declare For reference From Delegate
            //StringFuncDelegate? stringFunc;

            //// Step 2 : Initialize Reference with new object from delegate [StringFuncDelegate0]
            ////stringFunc = new StringFuncDelegate(StringFunctions.GetCountOfUpperCaseChar);
            //// syntax suggare
            //stringFunc = StringFunctions.GetCountOfUpperCaseChar;

            //stringFunc += StringFunctions.GetCountOfLowerCaseChar;
            //// Remove reference of GetCountOfLowerCaseChar
            //stringFunc -= StringFunctions.GetCountOfLowerCaseChar ;
            //// Step 3 : Use Delegate [Call Method]
            ////int c = stringFunc.Invoke("Ali Ahmed Sharaf");
            //int c = stringFunc("Ali Ahmed Sharaf");

            //Console.WriteLine(c); 
            #endregion

            #region Example 02
            //int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //SortingAlgorithms.BubbleSortAsc(numbers); // Sort In Asc
            //foreach (int i in numbers)
            //    Console.Write($"{i} ");
            //Console.WriteLine();
            //SortingAlgorithms.BubbleSortDesc(numbers); // Sort In Desc
            //foreach (int i in numbers)
            //    Console.Write($"{i} ");

            //SortingAlgorithms.BubbleSort(numbers, SortingTypes.CompareGreater);
            //foreach (int i in numbers)
            //    Console.Write($"{i} ");

            //Console.WriteLine();

            //SortingAlgorithms.BubbleSort(numbers, SortingTypes.CompareLess); 
            //foreach (int i in numbers)
            //    Console.Write($"{i} ");

            //SortingTypesFuncDelegate sortingType = SortingTypes.CompareGreater;

            //SortingAlgorithms.BubbleSort(numbers, sortingType);
            //foreach (int i in numbers)
            //    Console.Write($"{i} ");

            //Console.WriteLine();
            //sortingType = SortingTypes.CompareLess;
            //SortingAlgorithms.BubbleSort(numbers, sortingType);
            //foreach (int i in numbers)
            //    Console.Write($"{i} ");

            //sortingType = default;
            //Console.WriteLine();
            //SortingAlgorithms.BubbleSort(numbers, sortingType);
            //foreach (int i in numbers)
            //    Console.Write($"{i} ");
            #endregion

            #region Example 02 - With Generic

            //int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //SortingAlgorithms<int>.BubbleSort(numbers, SortingTypes.CompareGreater);
            //foreach (int i in numbers)
            //    Console.Write($"{i} ");

            //SortingTypesFuncDelegate<int> sortingType = SortingTypes.CompareLess;
            //Console.WriteLine();

            //SortingAlgorithms<int>.BubbleSort(numbers, sortingType); 
            //foreach (int i in numbers)
            //    Console.Write($"{i} ");


            //string[] names = { "Omar", "Mohamed", "Amr", "Salma" };
            //SortingAlgorithms<string>.BubbleSort(names, SortingTypes.SortAsc);
            //foreach (string name in names)
            //    Console.Write($"{name} - ");
            //Console.WriteLine();

            //SortingTypesFuncDelegate<string, string, bool> sortingType = SortingTypes.SortDesc;
            //SortingAlgorithms<string>.BubbleSort(names, sortingType);
            //foreach (string name in names)
            //    Console.Write($"{name} - ");


            #endregion

            #region Example 03

            //List<int> numbers = Enumerable.Range(1, 100).ToList();
            ////List<int> OddList =  FilterLists.FindOddNumbers(numbers);
            ////List<int> EvenList =  FilterLists.FindEvenNumbers(numbers);

            //List<int> OddList = FilterLists.FindElements(numbers, FiltersOfList.CheckOdd);
            //FilterFuncDelegate<int> filterDelegate = FiltersOfList.CheckEven;
            //List<int> EvenList = FilterLists.FindElements(numbers, filterDelegate);


            //List<int> Divisble7Numbers = FilterLists.FindElements(numbers, FiltersOfList.DivisbleBy7);
            //List<int> Divisble10Numbers = FilterLists.FindElements(numbers, FiltersOfList.DivisbleBy10);

            //foreach (int i in Divisble10Numbers)
            //    Console.Write($"{i} ");

            // List<string> Names = new List<string>() { "Ahmed", "Aya", "Khalid", "Rawan", "Heba"};
            //List<string> Names = ["Ahmed", "Aya", "Khalid", "Rawan", "Heba"];

            //FilterFuncDelegate<string> filterFuncDelegate = FiltersOfList.CheckLength; 
            //List<string> MoreThan4 = FilterLists.FindElements(Names, filterFuncDelegate);
            //foreach (string s in MoreThan4)
            //    Console.WriteLine(s);


            #endregion

            #endregion

            #region Built-in Delegate [Func, Action, Predicate]

            //Predicate<int> predicate =  TestBuitInDelegates.CheckPositive;
            //bool result = predicate(8); //predicate.Invoke(8);
            //Console.WriteLine(result);

            //Func<int, string> func = TestBuitInDelegates.Casting;
            //string number = func.Invoke(8);
            //Console.WriteLine(number);

            //Action action = TestBuitInDelegates.Print;
            //action.Invoke();

            //Action<string> action1 = TestBuitInDelegates.PrintName;
            //action1.Invoke("Ahmed");

            #endregion

            #region Anonymous Method

            //Predicate<int> predicate = delegate (int number) { return number > 0; };
            //bool result = predicate(8);
            //Console.WriteLine(result);

            //Func<int, string> func = delegate (int number) { return number.ToString(); };
            //string number = func.Invoke(8);
            //Console.WriteLine(number);

            //Action action = delegate { Console.WriteLine("Hello"); };
            //action.Invoke();

            //Action<string> action1 = delegate (string name) { Console.WriteLine($"Hello {name}"); };
            //action1.Invoke("Ahmed");

            #endregion

            #region Lambda Expression

            //Predicate<int> predicate =  number => number > 0;
            //bool result = predicate(8);
            //Console.WriteLine(result);

            //Func<int, string> func = (int number) => number.ToString() ;
            //string number = func.Invoke(8);
            //Console.WriteLine(number);

            //Action action = () => Console.WriteLine("Hello"); 
            //action.Invoke();

            //Action<string> action1 =  name =>  Console.WriteLine($"Hello {name}") ;
            //action1.Invoke("Ahmed");

            #endregion

            #region List Methods Take Function As Parameters

            //List<int> Numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

            //bool result = Numbers.Exists(x => x == 10);
            //Console.WriteLine(result);

            //int element = Numbers.Find(x => x % 2 == 0);
            //Console.WriteLine(element);

            //int element = Numbers.FindLast(x => x % 2 == 0);
            //Console.WriteLine(element);

            //int element = Numbers.FindIndex(x => x % 2 == 0);
            //Console.WriteLine(element);

            //int element = Numbers.FindLastIndex(x => x % 2 == 0);
            //Console.WriteLine(element);

            //List<int> element = Numbers.FindAll(x => x % 2 == 0);
            //foreach(int i in element)
            //    Console.WriteLine(i);

            //Numbers.ForEach(x => x++); 
            //Numbers.ForEach(x => ++x); // invalid 
            //foreach (int i in Numbers)
            //    Console.Write($"{i} ");

            //bool flag = Numbers.TrueForAll(x => x % 2 == 0);
            //Console.WriteLine(flag);

            //int numRemoved = Numbers.RemoveAll(x => x % 3 == 0);
            //Console.WriteLine(numRemoved);
            //foreach (int i in Numbers)
            //    Console.Write($"{i} ");
            #endregion

            #region Function Return Function

            //// To Invoke
            //// 1.
            //Action action = FunctionReturnDelegate.DelegateAction();
            //action.Invoke();
            //// 2.
            //action();
            //// 3.
            //FunctionReturnDelegate.DelegateAction().Invoke();
            //// 4.
            //FunctionReturnDelegate.DelegateAction()();

            //bool flag = FunctionReturnDelegate.DelegatePredicate().Invoke(4);
            //flag = FunctionReturnDelegate.DelegatePredicate()(4);

            //Console.WriteLine(FunctionReturnDelegate.DelegatePredicate()(4));


            //string name = FunctionReturnDelegate.DelegateFunc()(new char[] {'a', 'h', 'm', 'e', 'd'});
            //Console.WriteLine(name);
            #endregion
        }
    }
}
