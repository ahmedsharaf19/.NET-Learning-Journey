namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Question 01
            //1 - Write a program that takes a number from the user then print yes if that number can be divided by 3 and 4 otherwise print no.

            //bool Flag;
            //int Number;

            //do
            //{
            //    Console.WriteLine("Enter Number: ");

            //    Flag = int.TryParse(Console.ReadLine(), out Number);
            //}
            //while (!Flag);

            //if (Number % 3 == 0 && Number % 4 == 0)
            //    Console.WriteLine("Yes");
            //else
            //    Console.WriteLine("No");


            #endregion

            #region Question 02
            //2- Write a program that allows the user to insert an integer then print negative if it is negative number otherwise print positive.

            //bool Flag;
            //int Number;

            //do
            //{
            //    Console.WriteLine("Enter Number: ");

            //    Flag = int.TryParse(Console.ReadLine(), out Number);
            //}
            //while (!Flag);

            //if(Number > 0)
            //    Console.WriteLine("Positive");
            //else if (Number < 0)
            //    Console.WriteLine("Negative");
            //else
            //    Console.WriteLine("Zero");

            #endregion

            #region Question 03
            //3- Write a program that takes 3 integers from the user then prints the max element and the min element.

            //bool Flag01, Flag02, Flag03;
            //int Number01, Number02, Number03;

            //do
            //{
            //    Console.WriteLine("Enter First Number: ");
            //    Flag01 = int.TryParse(Console.ReadLine(), out Number01);
            //    Console.WriteLine("Enter Second Number: ");
            //    Flag02 = int.TryParse(Console.ReadLine(), out Number02);
            //    Console.WriteLine("Enter Third Number: ");
            //    Flag03 = int.TryParse(Console.ReadLine(), out Number03);
            //}
            //while (!(Flag01 && Flag02 && Flag03));

            //if (Number01 > Number02 && Number02 > Number03)
            //{
            //    if (Number02 > Number03)
            //        Console.WriteLine($"{Number01} Is The Max and {Number03} Is The Min");
            //    else
            //        Console.WriteLine($"{Number01} Is The Max and {Number02} Is The Min");
            //}
            //else if (Number02 > Number01 && Number02 > Number03)
            //{
            //    if (Number01 > Number03)
            //        Console.WriteLine($"{Number02} Is The Max and {Number03} Is The Min");
            //    else
            //        Console.WriteLine($"{Number02} Is The Max and {Number01} Is The Min");

            //}

            //else if (Number03 > Number01 && Number03 > Number02)
            //{
            //    if (Number01 > Number02)
            //        Console.WriteLine($"{Number03} Is The Max and {Number02} Is The Min");
            //    else
            //        Console.WriteLine($"{Number03} Is The Max and {Number01} Is The Min");

            //}
            //else
            //    Console.WriteLine("Equal Numbers");



            #endregion

            #region Question 04
            //4- Write a program that allows the user to insert an integer number then check If a number is even or odd.

            //bool Flag;
            //int Number;

            //do
            //{
            //    Console.WriteLine("Enter Number: ");

            //    Flag = int.TryParse(Console.ReadLine(), out Number);
            //}
            //while (!Flag);

            //if(Number % 2 == 0)
            //    Console.WriteLine("Even");
            //else
            //    Console.WriteLine("Odd");
            #endregion

            #region Question 05
            //5- Write a program that takes character from the user then if it is a vowel chars (a,e,I,o,u) then print (vowel) otherwise print (consonant).


            //char X;
            //Console.WriteLine("Enter Character: ");
            //char.TryParse(Console.ReadLine().ToLower(), out X);

            //switch (X)
            //{
            //    case 'a':
            //    case 'e':
            //    case 'i':
            //    case 'o':
            //    case 'u':
            //        Console.WriteLine("Vowel");
            //        break;
            //    default:
            //        Console.WriteLine("Consonant");
            //        break;
            //}




            #endregion

            #region Question 06
            //6- Write a program that allows the user to insert an integer then print all numbers between 1 to that number.

            //bool Flag;
            //int Number;

            //do
            //{
            //    Console.WriteLine("Enter Number: ");

            //    Flag = int.TryParse(Console.ReadLine(), out Number);
            //}
            //while (!Flag);

            //for(int i = 1; i <= Number; i++)
            //    Console.Write($"{i}  ");

            #endregion

            #region Question 07
            //7 - Write a program that allows the user to insert an integer then print a multiplication table up to 12.

            //bool Flag;
            //int Number;

            //do
            //{
            //    Console.WriteLine("Enter Number: ");

            //    Flag = int.TryParse(Console.ReadLine(), out Number);
            //}
            //while (!Flag);

            //for(int i = 1; i<= 12; i++)
            //    Console.WriteLine($"{Number} * {i} = {Number * i}");

            #endregion

            #region Question 08
            //8- Write a program that allows to user to insert number then print all even numbers between 1 to this number

            //bool Flag;
            //int Number;

            //do
            //{
            //    Console.WriteLine("Enter Number: ");

            //    Flag = int.TryParse(Console.ReadLine(), out Number);
            //}
            //while (!Flag);

            //if(Number > 0)
            //{
            //    for(int i = 1; i < Number; i++)
            //        if(i % 2 == 0)
            //            Console.WriteLine(i);
            //}
            //else
            //{
            //    for(int i = Number; i <= 1; i++)
            //        if(i % 2 == 0)
            //            Console.WriteLine(i);
            //}


            #endregion

            #region Question 09
            //9 - Write a program that takes two integers then prints the power.

            //bool Flag01 , Flag02;
            //int Base , Power;
            //double Result = 1;

            //do
            //{
            //    Console.WriteLine("Enter Base: ");
            //    Flag01 = int.TryParse(Console.ReadLine(), out Base);
            //    Console.WriteLine("Enter Power: ");
            //    Flag02 = int.TryParse(Console.ReadLine(), out Power);
            //}
            //while (!(Flag01 && Flag02));

            //if(Power > 0)
            //{
            //    for (int i = 0; i < Power; i++)
            //        Result *= Base;
            //    Console.WriteLine($"{Base} ^ {Power} = {Result}");
            //}
            //else if (Power < 0)
            //{
            //    for(int i = Power; i < 0; i++)
            //        Result *= Base;
            //    Console.WriteLine($"{Base} ^ {Power} = {1/Result}");
            //}

            //else
            //    Console.WriteLine($"{Base} ^ {Power} = 1 ");
            #endregion

            #region Question 10
            //10 - Write a program to enter marks of five subjects and calculate total, average and percentage.
            //      Example
            //      Input: -Enter Marks of five subjects: 95 76 58 90 89
            //      Output: Total marks = 408
            //              Average Marks = 81
            //              Percentage = 81

            //double Number, Average, Percentage, Total = 0;
            //int Count = 0;
            //bool Flag;

            //while(Count < 5)
            //{
            //    Console.WriteLine($"Enter Mark Of Subject {Count + 1} ");
            //    Flag = double.TryParse( Console.ReadLine(), out Number );

            //    if(Flag && (Number >= 0 && Number <= 100))
            //    {
            //        Total += Number;
            //        Count++;
            //    }
            //    else
            //        Console.WriteLine("Not Valid Mark");

            //}

            //Average = Total / 5;
            //Percentage = (Total * 100) / 500;
            //Console.WriteLine($"Total Marks = {Total}");
            //Console.WriteLine($"Average = {Average}");
            //Console.WriteLine($"Percentage = {Percentage} %");


            #endregion

            #region Question 11
            //11- Write a program to input the month number and print the number of days in that month.

            //bool Flag;
            //int Month;

            //do
            //{
            //    Console.WriteLine("Enter Month Number: ");

            //    Flag = int.TryParse(Console.ReadLine(), out Month);
            //}
            //while (!Flag);

            //switch (Month)
            //{
            //    case 1:
            //    case 3:
            //    case 5:
            //    case 7:
            //    case 8:
            //    case 10:
            //    case 12:
            //        Console.WriteLine("Number Of Days For This Month = 31");
            //        break;
            //    case 2:
            //        Console.WriteLine("Number Of Days For This Month = 28");
            //        break;
            //    default:
            //        Console.WriteLine("Number Of Days For This Month = 30");
            //        break;
            //}

            #endregion

            #region Question 12
            //12- Write a program to create a Simple Calculator.

            //bool Flag01, Flag02, Flag03;
            //int Num01, Num02, Result = 0;
            //char Operator;
            //do
            //{
            //    Console.WriteLine("Enter First Number: ");
            //    Flag01 = int.TryParse(Console.ReadLine(), out Num01);
            //    Console.WriteLine("Enter Operator: ");
            //    Flag03 = char.TryParse(Console.ReadLine(), out Operator);
            //    Console.WriteLine("Enter Second Number: ");
            //    Flag02 = int.TryParse(Console.ReadLine(), out Num02);

            //}
            //while (!(Flag01 && Flag02 && Flag03));

            //switch (Operator)
            //{
            //    case '+':
            //        Result = Num01 + Num02;
            //        Console.WriteLine($"{Num01} {Operator} {Num02} = {Result}");
            //        break;
            //    case '-':
            //        Result = Num01 - Num02;
            //        Console.WriteLine($"{Num01} {Operator} {Num02} = {Result}");
            //        break;
            //    case '*':
            //        Result = Num01 * Num02;
            //        Console.WriteLine($"{Num01} {Operator} {Num02} = {Result}");
            //        break;
            //    case '/':
            //        if (Num02 == 0)
            //        {
            //            Console.WriteLine("Can not divide by Zero");
            //            break;
            //        }
            //        else
            //        {
            //            Result = Num01 / Num02;
            //            Console.WriteLine($"{Num01} {Operator} {Num02} = {Result}");
            //            break;

            //        }
            //    default:
            //        Console.WriteLine("Invalid");
            //        break;
            //}


            #endregion

            #region Question 13
            //13- Write a program to allow the user to enter a string and print the REVERSE of it.

            //Console.WriteLine("Enter Word");
            //string Word = Console.ReadLine();


            //for(int i = Word.Length-1; i >= 0; i--)
            //    Console.Write(Word[i]);
            #endregion

            #region Question 14
            //14- Write a program to allow the user to enter int and print the REVERSED of it.
            //123
            //321

            //bool Flag;
            //int Number , Result = 0;

            //do
            //{
            //    Console.WriteLine("Enter Number: ");

            //    Flag = int.TryParse(Console.ReadLine(), out Number);
            //}
            //while (!Flag);

            //while(Number > 0)
            //{
            //    int Remainder = Number % 10;
            //    Result = (Result * 10) + Remainder;
            //    Number = Number / 10;
            //}

            //Console.WriteLine($"Reversed Number = {Result}");


            #endregion

            #region Question 15
            //15 - Write a program in C# Sharp to find prime numbers within a range of numbers.
            //     Test Data:
            //                 Input starting number of range: 1
            //     Input ending number of range: 50
            //     Expected Output :
            //     The prime number between 1 and 50 are:
            //                 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47
            // 1 2 3 4 5 6 7

            //bool Flag01 , Flag02;
            //int StartNumber, EndNumber,Count ;

            //do
            //{
            //    Console.WriteLine("Enter StartNumber: ");
            //    Flag01 = int.TryParse(Console.ReadLine(), out StartNumber);
            //    Console.WriteLine("Enter EndNumber: ");
            //    Flag02 = int.TryParse(Console.ReadLine(), out EndNumber);
            //}
            //while (!(Flag01 && Flag02));

            //for(int i = StartNumber; i < EndNumber; i++)
            //{
            //    Count = 0;

            //    for(int j = 2; j <= i; j++)
            //    {
            //        if (i % j == 0)
            //            Count++;
            //            break;
            //    }

            //    if(Count == 0 && i !=1)
            //        Console.Write($"{i}  ");
            //}



            #endregion

            #region Question 16
            //16 - .Write a program in C# Sharp to convert a decimal number into binary without using an array.
            //      Test Data:
            //                  Enter a number to convert: 25
            //      Expected Output :
            //      The Binary of 25 is 11001.

            // 16
            // 16/2 = 0
            // 8/2  = 0
            // 4/2  = 0
            // 2/2  = 0
            // 1/2  = 1
            // 0/2
            // 10000

            //bool Flag01;
            //int Number , DN , Binary = 0 , j;

            //do
            //{
            //    Console.WriteLine("Enter Number: ");
            //    Flag01 = int.TryParse(Console.ReadLine(), out Number);

            //}
            //while (!Flag01);
            //DN = Number;
            //j = 1;

            //for(int i = Number; i>0; i = i / 2)
            //{
            //    Binary = Binary + (Number % 2) * j;
            //    j = j * 10;
            //    Number = Number / 2;
            //}

            //Console.WriteLine($"Binary Of {DN} = {Binary}");



            #endregion

            #region Question 17
            //17- Create a program that asks the user to input three points (x1, y1), (x2, y2), and (x3, y3), and determines whether these points lie on a single straight line.


            //int X1 , X2 , X3 , Y1 , Y2 , Y3 ;
            //int Slope01, Slope02, Slope03;

            //Console.WriteLine("Enter Point 01: ");
            //X1 = int.Parse(Console.ReadLine());
            //Y1 = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter Point 02: ");
            //X2 = int.Parse(Console.ReadLine());
            //Y2 = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter Point 03: ");
            //X3 = int.Parse(Console.ReadLine());
            //Y3 = int.Parse(Console.ReadLine());

            //Slope01 = Y2 - Y1 / X2-X1;
            //Slope02 = Y3 - Y1 / X3-X1;
            //Slope03 = Y3 - Y2 / X3-X2;

            //if(Slope01 == Slope02 && Slope01 == Slope03)
            //    Console.WriteLine("Lie on a single straight line");
            //else
            //    Console.WriteLine("Do No Lie on a single straight line");


            #endregion

            #region Question 18
            //18 - Within a company, the efficiency of workers is evaluated based on the duration required to complete a specific task.A worker's efficiency level is determined as follows: 
            //   - If the worker completes the job within 2 to 3 hours, they are considered highly efficient.
            //   - If the worker takes 3 to 4 hours, they are instructed to increase their speed.
            //   - If the worker takes 4 to 5 hours, they are provided with training to enhance their speed.
            //   - If the worker takes more than 5 hours, they are required to leave the company.
            //To calculate the efficiency of a worker, the time taken for the task is obtained via user input from the keyboard.


            //bool Flag01;
            //int Number ;

            //do
            //{
            //    Console.WriteLine("Enter Number Of Hours: ");
            //    Flag01 = int.TryParse(Console.ReadLine(), out Number);

            //}
            //while (!Flag01);

            //if(Number >= 2 && Number <= 3)
            //    Console.WriteLine("highly efficient");
            //else if (Number >= 3 && Number <= 4)
            //    Console.WriteLine("increase their speed");
            //else if (Number >= 4 && Number <= 5)
            //    Console.WriteLine("enhance their speed");
            //else
            //    Console.WriteLine("required to leave the company");



            #endregion

            #region Question 19
            //19- . Write a program that prints an identity matrix using for loop, in other words takes a value n from the user and shows the identity table of size n * n.

            // 100
            // 010
            // 001

            //bool Flag01;
            //int Number;

            //do
            //{
            //    Console.WriteLine("Enter Size Of Matrix: ");
            //    Flag01 = int.TryParse(Console.ReadLine(), out Number);

            //} while (!Flag01);

            //for(int i = 0; i < Number; i++)
            //{
            //    for(int j = 0; j < Number; j++)
            //    {
            //        if(i == j)
            //            Console.Write($" {1} ");
            //        else
            //            Console.Write($" {0} ");

            //    }

            //    Console.Write("\n");
            //}

            #endregion

            #region Question 20
            //20- Write a program in C# Sharp to find the sum of all elements of the array.

            //bool Flag01;
            //int Size;

            //do
            //{
            //    Console.WriteLine("Enter Size: ");
            //    Flag01 = int.TryParse(Console.ReadLine(), out Size);

            //} while (!Flag01);

            //int[] array = new int[Size];

            //for(int i = 0; i<Size; i++)
            //{
            //    do
            //    {
            //        Console.WriteLine($"Enter Number: {i+1}");
            //        Flag01 = int.TryParse(Console.ReadLine(), out array[i]);

            //    } while (!Flag01);
            //}

            //int Sum = 0;
            //for(int i = 0; i< Size; i++)
            //    Sum += array[i];

            //Console.WriteLine($"Sum = {Sum}");
            #endregion

            #region Question 21
            //21- Write a program in C# Sharp to merge two arrays of the same size sorted in ascending order.

            //bool Flag01;
            //int Size01;

            //do
            //{
            //    Console.WriteLine("Enter Size Of First Array: ");
            //    Flag01 = int.TryParse(Console.ReadLine(), out Size01);

            //} while (!Flag01);

            //int[] array01 = new int[Size01];

            //for (int i = 0; i < Size01; i++)
            //{
            //    do
            //    {
            //        Console.WriteLine($"Enter Number: {i + 1}");
            //        Flag01 = int.TryParse(Console.ReadLine(), out array01[i]);

            //    } while (!Flag01);
            //}

            //int Size02;

            //do
            //{
            //    Console.WriteLine("Enter Size Of Second Array: ");
            //    Flag01 = int.TryParse(Console.ReadLine(), out Size02);

            //} while (!Flag01);

            //int[] array02 = new int[Size02];

            //for (int i = 0; i < Size02; i++)
            //{
            //    do
            //    {
            //        Console.WriteLine($"Enter Number: {i + 1}");
            //        Flag01 = int.TryParse(Console.ReadLine(), out array02[i]);

            //    } while (!Flag01);
            //}

            //int Size03 = Size01 + Size02;
            //int[] array03 = new int[Size03];


            //int x;

            //for (x = 0; x < Size01; x++)
            //    array03[x] = array01[x];

            //for(int i = 0; i < Size02; i++)
            //{
            //    array03[x] = array02[i];
            //    x++;
            //}

            //int Temp;

            //for(int i = 0; i < Size03; i++)
            //{
            //    for(int j = i+1; j < Size03; j++)
            //    {
            //        if (array03[i] > array03[j])
            //        {
            //            Temp = array03[i];
            //            array03[i] = array03[j];
            //            array03[j] = Temp;
            //        }
            //    }
            //}

            //Console.WriteLine("Merged Array: ");

            //for(int i = 0; i < Size03; i++)
            //    Console.WriteLine($"{array03[i]} | ");


            #endregion

            #region Question 22
            //22- Write a program in C# Sharp to count the frequency of each element of an array.

            //bool Flag01;
            //int Size01;

            //do
            //{
            //    Console.WriteLine("Enter Size Of First Array: ");
            //    Flag01 = int.TryParse(Console.ReadLine(), out Size01);

            //} while (!Flag01);

            //int[] array01 = new int[Size01];
            //int[] Freq = new int[Size01];

            //for (int x = 0; x < Size01; x++)
            //{
            //    do
            //    {
            //        Console.WriteLine($"Enter Number: {x + 1}");
            //        Flag01 = int.TryParse(Console.ReadLine(), out array01[x]);
            //        Freq[x] = -1;

            //    } while (!Flag01);
            //}

            //int i, j, Counter;

            //for(i = 0; i < Size01; i++) // 1 2 3 1
            //                            // 2     0
            //{
            //    Counter = 1;
            //    for(j = i+1; j < Size01; j++)
            //    {
            //        if (array01[i] == array01[j])
            //        {
            //            Counter++;
            //            Freq[j] = 0; // Freq[3] = 0
            //        }

            //        if (Freq[i] != 0)
            //            Freq[i] = Counter;
            //    }

            //}

            //Console.WriteLine("Frequency Equal = ");

            //for(int k = 0; k < Size01; k++)
            //{
            //    if (Freq[k] != 0)
            //        Console.WriteLine($"{array01[k]} Occures {Freq[k]}");
            //}
            #endregion

            #region Question 23
            //23- Write a program in C# Sharp to find maximum and minimum element in an array


            //bool Flag01;
            //int Size01;

            //do
            //{
            //    Console.WriteLine("Enter Size Of First Array: ");
            //    Flag01 = int.TryParse(Console.ReadLine(), out Size01);

            //} while (!Flag01);

            //int[] array01 = new int[Size01];

            //for (int i = 0; i < Size01; i++)
            //{
            //    do
            //    {
            //        Console.WriteLine($"Enter Number: {i + 1}");
            //        Flag01 = int.TryParse(Console.ReadLine(), out array01[i]);

            //    } while (!Flag01);
            //}

            //int Max = array01[0];
            //int Min = array01[0];

            //for(int i = 0; i < array01.Length; i++)
            //{
            //    if (array01[i] > Max)
            //        Max = array01[i];
            //    if (array01[i] < Min)
            //        Min = array01[i];
            //}
            //Console.WriteLine($"Max = {Max}");
            //Console.WriteLine($"Min = {Min}");

            #endregion

            #region Question 24
            //24- Write a program in C# Sharp to find the second largest element in an array.

            //bool Flag01;
            //int Size01;

            //do
            //{
            //    Console.WriteLine("Enter Size Of First Array: ");
            //    Flag01 = int.TryParse(Console.ReadLine(), out Size01);

            //} while (!Flag01);

            //int[] array01 = new int[Size01];

            //for (int i = 0; i < Size01; i++)
            //{
            //    do
            //    {
            //        Console.WriteLine($"Enter Number: {i + 1}");
            //        Flag01 = int.TryParse(Console.ReadLine(), out array01[i]);

            //    } while (!Flag01);
            //}

            //int Largest = array01[0];

            //for(int i = 0; i < array01.Length; i++)
            //{
            //    if(Largest < array01[i])
            //        Largest = array01[i];
            //}

            //int Largest02 = 0;


            //for(int i = 0; i < array01.Length; i++)
            //{
            //    if (array01[i] > Largest02 && array01[i] < Largest)
            //        Largest02 = array01[i];
            //}

            //Console.WriteLine($"Second Largest Element: {Largest02} ");
            #endregion

            #region Question 25
            //25 -.Consider an Array of Integer values with size N, having values as in this Example
            //7   0    0   0  0  5   6   7   5   0   7   5   3

            //write a program find the longest distance between Two equal cells.In this example.The distance is measured by the number Of cells- for example, the distance between the first and the fourth cell is 2(cell 2 and cell 3).

            //In the example above, the longest distance is between the first 7 and the
            //10th 7, with a distance of 8 cells, i.e.the number of cells between the 1st
            //And the 10th 7s.

            //Note:
            //-Array values will be taken from the user
            //-If you have input like 1111111 then the distance is the number of
            //Cells between the first and the last cell.
            // 1231561


            //bool Flag01;
            //int Size01;

            //do
            //{
            //    Console.WriteLine("Enter Size Array: ");
            //    Flag01 = int.TryParse(Console.ReadLine(), out Size01);

            //} while (!Flag01);

            //int[] array01 = new int[Size01];

            //for (int i = 0; i < Size01; i++)
            //{
            //    do
            //    {
            //        Console.WriteLine($"Enter Number: {i + 1}");
            //        Flag01 = int.TryParse(Console.ReadLine(), out array01[i]);

            //    } while (!Flag01);
            //}

            //int Distance = 0;

            //for(int i = 0; i < array01.Length; i++)
            //{
            //    for(int j = i+1; j < array01.Length; j++)
            //    {
            //        if (array01[i] == array01[j]) // 1 2 3 1 2 5 1 
            //            if (Distance < j - i - 1)
            //                Distance = j - i - 1;
            //    }
            //}

            //Console.WriteLine($"Distance = {Distance}");


            #endregion

            #region Question 26
            //26 - Given a list of space separated words, reverse the order of the words.

            //      Input: this is a test       Output: test a is this
            //      Input: all your base        Output: base your all
            //      Input: Word Output: Word
            //      Note : 
            //      Check the Split Function(Member in String Class) Output will be a Single Console.WriteLine Statement

            //Console.WriteLine("Enter Sentence : ");
            //string Sen = Console.ReadLine();
            //string Result = "";
            //string[] str = Sen.Split(" ");

            //for (int i = str.Length - 1; i >= 0; i--)
            //    Result += str[i] + " ";
            //Console.WriteLine(Result);


            #endregion

            #region Question 27
            //27- Write a program to create two multidimensional arrays of same size. Accept value from user and store them in first array. Now copy all the elements of first array on second array and print second array.

            //int[,] arr01 = new int[3, 3];
            //int[,] arr02 = new int[3, 3];


            //for(int i =0; i < 3; i++)
            //{
            //    for(int j = 0; j < 3; j++)
            //    {
            //        Console.WriteLine("Enter Values: ");
            //        arr01[i,j] = int.Parse(Console.ReadLine());
            //    }
            //}

            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        arr02[i,j] = arr01[i,j];
            //    }
            //}

            //Console.WriteLine("Second Array: ");

            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        Console.WriteLine($"{arr02[i,j]} | ");
            //    }
            //}


            #endregion

            #region Question 28
            //28- Write a Program to Print One Dimensional Array in Reverse Order

            //int[] Arr = { 1, 2, 3, 4, 5 };

            //for(int i = Arr.Length-1; i >=0;i--)
            //    Console.WriteLine($"{Arr[i]} , ");
            #endregion

        }
    }
}
