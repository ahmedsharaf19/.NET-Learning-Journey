using System.Collections;
using System.Collections.ObjectModel;
namespace LecEx
{
    internal class Program
    {
        public static int SumArrayList(ArrayList arrayList)
        {
            int sum = 0;
            if (arrayList?.Count > 0) 
            {
                for (int i = 0; i < arrayList.Count; i++)
                    sum += (int?)arrayList[i] ?? 0;
            }
            return sum;
        }

        public static int SumList(List<int> list)
        {
            int sum = 0;
            if (list?.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                    sum += list[i];
            }
            return sum;
        }

        static void Main(string[] args)
        {

            #region Non-Generic Collection - ArrayList

            //ArrayList arrayList = new ArrayList();
            // ArrayList internally is an array of object
            // ArrayList Has Capacity which in number of element that it can hold
            // ArrayList Has Count which in number of element that it Actually hold

            //Console.WriteLine($"{arrayList.Capacity}, {arrayList.Count}");

            #region Add Elements
            //arrayList.Add(1); // boxing
            //// Add New Element Using Add(), Adding at End Of This ArrayList
            //// If Add is First Element capacity == default, adding another capacity increased by twice
            //Console.WriteLine($"{arrayList.Capacity}, {arrayList.Count}");
            //arrayList.AddRange(new int[] {2, 3, 4});
            //Console.WriteLine($"{arrayList.Capacity}, {arrayList.Count}");

            //arrayList.Add(7);
            //// After Adding 5th Element 
            //// Double Caspacity
            //Console.WriteLine($"{arrayList.Capacity}, {arrayList.Count}");


            #endregion

            #region Insert Element

            ////foreach (int item in arrayList) // Unboxing
            ////{
            ////    Console.Write($"{item} ");
            ////}
            //arrayList.Insert(1, 10);
            ////foreach (int item in arrayList) // Unboxing
            ////{
            ////    Console.Write($"{item} ");
            ////}
            ////arrayList.Insert(7, 20); // ArgumentOutOfRangeException
            ////// can not add using insert
            //Console.WriteLine();
            //arrayList.InsertRange(2, new int[] {20, 30 ,40});
            ////foreach (int item in arrayList) // Unboxing
            ////{
            ////    Console.Write($"{item} ");
            ////}
            #endregion

            #region Trim ArrayList
            //arrayList.TrimToSize();
            //Console.WriteLine($"{arrayList.Capacity}, {arrayList.Count}");

            #endregion

            #region Remove
            ////foreach (int item in arrayList) // Unboxing
            ////{
            ////    Console.Write($"{item} ");
            ////}
            //Console.WriteLine();
            //arrayList.Remove(10); // Remove First Occurence
            ////foreach (int item in arrayList) // Unboxing
            ////{
            ////    Console.Write($"{item} ");
            ////}

            //arrayList.RemoveAt(0); // remove at index
            //Console.WriteLine();
            ////foreach (int item in arrayList) // Unboxing
            ////{
            ////    Console.Write($"{item} ");
            ////}

            //arrayList.RemoveRange(0, 2);
            //Console.WriteLine();
            ////foreach (int item in arrayList) // Unboxing
            ////{
            ////    Console.Write($"{item} ");
            ////}
            #endregion

            #region Indexed

            //int FirstElement = (int?)arrayList[0] ?? 0; // unboxing - Explicit Casting - Unsafe
            //Console.WriteLine(FirstElement);


            #endregion

            #region Check If Element Is Exists
            //bool flag = arrayList.Contains(100);
            //Console.WriteLine(flag);
            #endregion

            #region Using 3 Constructors
            // array of object[size]
            //arrayList = new ArrayList(); // object[0]
            //arrayList.Add(1); // object[4]
            //arrayList.Add(2); // object[4]
            //arrayList.Add(3); // object[4]
            //arrayList.Add(4); // object[4]
            //arrayList.Add(5); // object[8]

            //arrayList = new ArrayList() { 1, 2, 3, 4, 5};
            //Console.WriteLine($"{arrayList.Capacity}, {arrayList.Count}");

            //// capacity = 10
            //arrayList = new ArrayList(10) { 1, 2, 3, 4, 5 };
            //Console.WriteLine($"{arrayList.Capacity}, {arrayList.Count}");

            //// create capacity auto = 5
            //arrayList = new ArrayList(new int[] {1, 2, 3, 4, 5});
            //Console.WriteLine($"{arrayList.Capacity}, {arrayList.Count}");
            #endregion

            #region Disadvantages of ArrayList 
            //arrayList = new ArrayList(5);
            //arrayList.Add(1); // boxing
            //arrayList.Add(2); // boxing
            //arrayList.Add(3); // boxing
            //arrayList.Add(4); // boxing
            //arrayList.Add("Ahmed"); // Type Safety

            ////int Result = SumArrayList(arrayList); // InvalidCastException
            ////Console.WriteLine($"Result = {Result}");

            //foreach(int item in arrayList)
            //    Console.WriteLine(item); // InvalidCastException

            //foreach (var item in arrayList)
            //    Console.WriteLine(item);  
            #endregion

            #endregion

            #region Generic Collection - List<T>

            //List<int> list = new List<int>();
            //// list internally is an array of T[int]
            //Console.WriteLine($"{list.Capacity}, {list.Count}"); // 0, 0

            #region Adding Element

            //list.Add(1);
            ////Console.WriteLine($"{list.Capacity}, {list.Count}"); // 4, 1

            //list.AddRange(2, 3, 4); // Params

            //list.AddRange(5);
            ////Console.WriteLine($"{list.Capacity}, {list.Count}"); // 8, 5

            #endregion

            #region Insert

            //Console.WriteLine($"{list.Capacity}, {list.Count}"); // 8, 5

            //foreach (int i in list)
            //    Console.Write($"{list[i]} ");
            //list.Insert(1, 10);
            //Console.WriteLine();
            //foreach (int i in list)
            //    Console.Write($"{list[i]} ");


            #endregion

            #region TrimExcess

            //list.TrimExcess();

            #endregion

            #region Remove
            //list.Remove(2);

            //list.RemoveAt(0);

            //list.RemoveRange(1, 1);
            #endregion

            #region Access Element In List By Index

            //int FirstElement = list[0];
            //Console.WriteLine(FirstElement);

            #endregion

            #region Check Element is existed
            //bool flag = list.Contains(100);
            #endregion

            #region 3 Constructor in list
            //list = new List<int>() { 1, 2, 3, 4, 5 };

            //list = new List<int>(10) { 1, 2, 3, 4, 5 };

            //list = new List<int>(new int[] {1, 2, 3, 4, 5});

            //list = new List<int>([1, 2, 3, 4, 5 ]); // object initializer




            #endregion

            #region Iterate On List
            //foreach (int i in list)
            //    Console.Write($"{i} ");
            #endregion

            #region List Indexer

            //list[0] = 100; // use indexer as setter
            //Console.WriteLine(list[0]); // use indexer as getter

            ////list[100] = 1; // can't use indexer to add
            #endregion

            #region EnsureCapacity

            //Console.WriteLine($"{list.Capacity}, {list.Count}");
            //list.EnsureCapacity(10); // increase capacity or don't change
            //Console.WriteLine($"{list.Capacity}, {list.Count}");

            #endregion

            #region Type Safety

            //list = new List<int>(5) { 1, 2, 3, 4 };
            ////list.Add("Sharaf"); // Invalid

            //Console.WriteLine(SumList(list)); // No Casting - No Exception Will Be Throw

            #endregion


            //List<int> numbers = new List<int>(10) { 1, 2, 3, 4, 5};
            //numbers.Add(10);
            //numbers.AddRange(20, 30, 40, 50, 60);

            #region AsReadOnly()
            //ReadOnlyCollection<int> ReadOnlyNumbers =  numbers.AsReadOnly<int>();
            ////ReadOnlyNumbers[0] = 100; // Invalid

            //foreach(int item in ReadOnlyNumbers)
            //    Console.Write($"{item} ");

            //numbers[0] = 100; // valid

            //foreach (int item in ReadOnlyNumbers)
            //    Console.Write($"{item} "); 
            #endregion

            #region BinarySearch

            //int index = numbers.BinarySearch(3);
            //Console.WriteLine(index);

            //index = numbers.BinarySearch(100);
            //Console.WriteLine(index);

            #endregion

            #region Clear()
            //Console.WriteLine($"{numbers.Capacity}, {numbers.Count}");
            //numbers.Clear();
            //Console.WriteLine($"{numbers.Capacity}, {numbers.Count}");

            #endregion

            #region GetRange

            //foreach (int item in numbers)
            //    Console.Write($"{item} ");

            //List<int> RangeNumbers = numbers.GetRange(1, 5);
            //foreach(int item in RangeNumbers)
            //    Console.Write($"{item} ");


            #endregion

            #region IndexOf(), LastIndexOf()

            //int FirstIndex = numbers.IndexOf(10);
            //Console.WriteLine(FirstIndex);

            //int LastIndex = numbers.LastIndexOf(10);
            //Console.WriteLine(LastIndex);

            #endregion

            #region CopyTo()

            //int[] arr = new int[15];
            //numbers.CopyTo(arr);
            //numbers.CopyTo(arr, 2);
            //numbers.CopyTo(1, arr, 2, 5);

            #endregion

            #endregion

            #region Linked List

            //LinkedList<int> linkedList = new LinkedList<int>();
            //LinkedListNode<int> FirstNode = linkedList.AddFirst(10);
            //linkedList.AddFirst(20); // Add Before First Node 
            //LinkedListNode<int> Node = new LinkedListNode<int>(30);
            //linkedList.AddFirst(Node);
            //linkedList.AddLast(40);
            //LinkedListNode<int> AnotherNode = new LinkedListNode<int>(100);

            //linkedList.AddAfter(Node, AnotherNode);
            ////linkedList.AddBefore(Node, AnotherNode);
            //foreach (int item in linkedList)
            //    Console.WriteLine($"{item} ");

            //Console.WriteLine(linkedList.Count);
            //LinkedListNode<int>? FirstNodeOfLinkdedList = linkedList.First;
            //LinkedListNode<int>? LastNodeOfLinkdedList = linkedList.Last;
            //Console.WriteLine(FirstNodeOfLinkdedList?.Value);
            //Console.WriteLine(FirstNodeOfLinkdedList?.ValueRef);
            //LinkedListNode<int>? prevNode = FirstNodeOfLinkdedList?.Previous;
            //LinkedListNode<int>? nextNode = FirstNodeOfLinkdedList?.Next;

            //LinkedList<int> x = AnotherNode.List;

            #endregion

            #region Stack

            //Stack<int> stack = new Stack<int>();
            //Console.WriteLine($"{stack.Capacity}, {stack.Count}");
            //stack.Push(1);
            //stack.Push(2);
            //stack.Push(3);
            //stack.Push(4);
            
            //foreach(int item in stack)
            //    Console.Write($"{item} ");

            //Console.WriteLine();

            //int TopElement = stack.Pop();
            //Console.WriteLine(TopElement);
            //Console.WriteLine(stack.Peek());
            //bool flag = stack.TryPop(out TopElement);
            //Console.WriteLine(flag);

            //stack.Clear()
            #endregion

            #region Queue

            //Queue<int> queue = new Queue<int>();
            //queue.Enqueue(1);
            //queue.Enqueue(2);
            //queue.Enqueue(3);
            //queue.Enqueue(4);

            //Console.WriteLine($"{queue.Capacity}, {queue.Count}");
            //foreach(int i in queue) 
            //    Console.Write($"{i} ");

            ////queue.Dequeue();
            ////queue.Dequeue();
            ////queue.Dequeue();
            ////queue.Dequeue();

            ////queue.Peek();

            //bool flag = queue.TryDequeue(out int firstElement);
            //Console.WriteLine(flag);
            //Console.WriteLine(firstElement);

            //queue.Clear();

            #endregion

        }
    }
}
