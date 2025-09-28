namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q1
            ////Write a program that allows the user to enter a number then print it.
            //Console.Write("Enter Number : ");
            //bool isParsed = int.TryParse(Console.ReadLine(), out int num);
            //if (isParsed)
            //{
            //    Console.WriteLine($"Number is : {num}");
            //}
            //else
            //{ Console.WriteLine("Invalid Number"); }
            #endregion

            #region Q2
            ////Write C# program that Convert a string to an integer, but the string contains non-numeric characters. And mention what will happen
            //string st = "asd123";
            //int result = Convert.ToInt32(st); // throw exception
            #endregion

            #region Q3
            //Write C# program that Perform a simple arithmetic operation with floating-point numbers And mention what will happen
            //double num1 = 4.5;
            //double num2 = 5.5;
            //double result = num1 + num2;
            //Console.WriteLine($"Result = {result}"); // 10
            #endregion

            #region Q4
            //Write C# program that Extract a substring from a given string.
            //string name = "Ahmed Sharaf";
            //Console.WriteLine(name.Substring(2, 5));

            #endregion

            #region Q5
            //Write C# program that Assigning one value type variable to another and modifying the value of one variable and mention what will happen
            //int X = 5, Y = 10;
            //Console.WriteLine("Before Assigning");
            //Console.WriteLine($"X : {X}");
            //Console.WriteLine($"Y : {Y}");
            //Console.WriteLine("##################################################");
            //X = Y;
            //X = 15;
            //Console.WriteLine("Before Assigning And Modifying");
            //Console.WriteLine($"X : {X}");
            //Console.WriteLine($"Y : {Y}");

            #endregion

            #region Q6
            ////Write C# program that Assigning one reference type variable to another and modifying the object through one variable and mention what will happen
            //int[] arr = { 1, 2, 3 };
            //int[] arr2 = arr;

            //Console.WriteLine("Before Assigning");
            //Console.WriteLine($"arr[1] : {arr[1]}");
            //Console.WriteLine($"arr2[1] : {arr2[1]}");
            //Console.WriteLine("##################################################");
            //arr2[1] = 50;
            //Console.WriteLine("Before Assigning And Modifying");
            //Console.WriteLine($"arr[1] : {arr[1]}");
            //Console.WriteLine($"arr2[1] : {arr2[1]}");
            #endregion

            #region Q7
            //Write C# program that take two string variables and print them as one variable 
            //string firstName = "Ahmed";
            //string lastName = "Sharaf";
            //Console.WriteLine($"{firstName} {lastName}");

            #endregion

            #region Q8
            //// 8 - Write a program that calculates the simple interest given the principal amount, rate of interest, and time.
            ////The formula for simple interest is Interest = (principal * rate * time) / 100.
            //double principal = 1000.0;
            //double rate = 5.0;
            //double time = 2.0;

            //double interest = (principal * rate * time) / 100;
            //Console.WriteLine($"Simple Interest : {interest}");

            #endregion

            #region Q9
            ////9 - Write a program that calculates the Body Mass Index(BMI) given a person's weight in kilograms and height in meters.
            ////The formula for BMI is BMI = (Weight) / (Height * Height)
            //double weight = 70.0;
            //double height = 1.90;
            //double BMI = (weight) / (height * height);
            //Console.WriteLine($"BMI : {BMI}");
            #endregion

            #region Q10
            ////10 - Write a program that uses the ternary operator to check if the temperature is too hot, too cold, or just good.
            ////Assign the result in variable then display the result.Assume that
            ////below 10 degrees is "Too Cold",
            ////above 30 degrees is "Just Hot",
            ////and anything else is "Just Good".

            //int temp = 20;
            //string result = temp < 10 ? "Too Cold" : temp > 30 ? "Just Hot" : "Just Good";
            //Console.WriteLine(result);

            #endregion

            #region Q11
            ////11 - Write a program that takes the date from user and displays it in various formats using string interpolation.
            //DateTime currentDate = DateTime.Now;
            //Console.WriteLine($"{currentDate.Day},{currentDate.Month},{currentDate.Year}");
            //Console.WriteLine($"{currentDate.Day}/{currentDate.Month}/{currentDate.Year}");
            //Console.WriteLine($"{currentDate.Day}-{currentDate.Month}-{currentDate.Year}");
            #endregion

            #region Q12
            //What is the output of the following C# code?

            //DateTime date = new DateTime(2024, 6, 14); 
            //Console.WriteLine($"The event is on {date:MM/dd/yyyy}"); 

            ////a) The event is on 14/06/2024
            ////b) The event is on 2024-06-14
            ////c) The event is on 06/14/2024
            ////d) The event is on June 14, 2024

            //// Ansewr --> c
            #endregion

            #region Q13
            //13 - Which of the following statements is correct about the C#.NET code snippet given below?
            //int d;
            //d = Convert.ToInt32(!(30 < 20)); // 1

            ////e)	A value 0 will be assigned to d.
            ////f)	A value 1 will be assigned to d.
            ////g)	A value -1 will be assigned to d.
            ////h)	The code reports an error.
            ////i)	The code snippet will work correctly if ! is replaced by Not.


            //Console.WriteLine(d);


            // Ansewr --> f
            #endregion

            #region Q14
            //14-	Which of the following is the correct output for the C# code given below?
            //Console.WriteLine(13 / 2 + " " + 13 % 2); // 6.5  1

            //a)	6.5 1
            //b)	6.5 0
            //c)	6 0
            //d)	6 1
            //e)	6.5 6.5


            // Answer --> d
            #endregion

            #region Q15
            //What will be the output of the C# code given below?
            //int num = 1, z = 5;


            //if (!(num <= 0))
            //    Console.WriteLine(++num + z++ + " " + ++z); /// 7 7
            //else
            //    Console.WriteLine(--num + z-- + " " + --z);

            //a)	5 6
            //b)	6 5
            //c)	6 6
            //d)	7 7


            // Answer --> d
            #endregion

        }

    }
}
