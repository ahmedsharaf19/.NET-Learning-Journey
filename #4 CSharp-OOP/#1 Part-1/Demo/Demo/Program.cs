using System.Net.Http.Headers;
using Common;

namespace Demo
{
    #region Namespace Info
    // what you can write Inside Namespace ?
    // 1. class
    // 2. Struct 
    // 3. Enum
    // 4. Interface

    // Access Modifiers Allowed Inside Namespace 
    // 1. Internal
    // 2. Public

    // Default Access Modifier Inside Namespace
    // Internal

    // With Namespace 
    // No Access Modifiers
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Class Library
            //Product product = new Product()
            //{
            //    ID = 10,
            //    Name = "Iphone",
            //    Count = 10
            //};
            #endregion

            #region Access Modifiers
            //TypeA typeA = new TypeA();

            ////typeA.x = 1; // invalid
            ////typeA.y = 2; // invalid // internal is accessable within its scope and in same project only
            ////typeA.z = 4; // valid  // public is Accessable within its scope and in same project and outside project
            #endregion

            #region Enum

            #region Example 01
            //Person person1 = new Person();

            //person1.Id = 10;
            //person1.Name = "Oamr";
            ////person1.Gender = "Hamada"; // becaise it is string can alloable any thing so we defined it as enum
            //person1.gender = Gender.Male;
            #endregion

            #region Example 02

            //Grades Grd01 = new Grades();
            //// Default of Int => 0
            //Console.WriteLine(Grd01); // 0
            //// if zero represent A it print A

            //Grd01 = Grades.D;
            //Console.WriteLine(Grd01); // D

            //Grd01 = Grades.A;
            //if (Grd01 == Grades.A || Grd01 == Grades.B)
            //    Console.WriteLine("Bravo");
            //else
            //    Console.WriteLine(":(");

            ////Grd01 = 4; // Invalid Must Use Castitn Operater
            //Grd01 = (Grades)4;
            //Console.WriteLine(Grd01);

            //Grd01 = (Grades)10;
            //Console.WriteLine(Grd01); // 10

            //Gender Gender01 = new Gender();
            //Console.WriteLine(Gender01);

            //Gender01 = Gender.M;
            //Console.WriteLine(Gender01);


            #endregion

            #region Example 03
            //Student std01 = new Student()
            //{
            //    Id = 1,  // 1
            //    Name = "Eman", // Eman
            //    Gender = Gender.Female, // 2
            //    Branche = Branches.Dokki, // 10
            //    Grade = Grades.B // 2
            //};



            #endregion

            #region Example 04
            //Student std02 = new Student();
            //Console.WriteLine("Please Enter Data Of Student ");
            //bool isParsed;
            //int stdId;
            //do
            //{
            //    Console.Write("Id : ");
            //    isParsed = int.TryParse(Console.ReadLine(), out stdId);
            //} while (!isParsed);
            //std02.Id = stdId;

            //Console.Write("Name : ");
            //std02.Name = Console.ReadLine();

            //object stdGen;
            //do
            //{
            //    Console.Write("Gender : ");
            //    isParsed = Enum.TryParse(typeof(Gender),Console.ReadLine(), out stdGen);
            //} while (!isParsed || stdGen is null);
            //std02.Gender = (Gender)stdGen;

            //Branches stdBranch;
            //do
            //{
            //    Console.Write("Branch : ");
            //    isParsed = Enum.TryParse<Branches>(Console.ReadLine(), out stdBranch);
            //} while (!isParsed);
            //std02.Branche = stdBranch; // Now We Don't need casting

            //Grades stdGrade;
            //do
            //{
            //    Console.Write("Grade : ");
            //    isParsed = Enum.TryParse(Console.ReadLine(), out stdGrade);
            //} while (!isParsed);
            //std02.Grade = stdGrade;

            //Console.Clear();
            //Console.WriteLine($"Hello {std02.Name} Welcome To .NET\nYour Branch is {std02.Branche} And Your Grade Is {std02.Grade}");


            #endregion

            #region Exammple 05

            //User user01 = new User();
            //user01.Id = 10;
            //user01.Permission[0] = true; // write
            //user01.Permission[1] = false; // read
            //user01.Permission[2] = true; // Execute
            //user01.Permission[3] = false; // Delete
            //// 4 Byte fpr Permission and 4 Byte For Id
            //// Data For Each User 8 Bytes

            //User user02 = new User();
            //user02.Id = 20;
            //user02.Permission[0] = true; // write
            //user02.Permission[1] = true; // read
            //user02.Permission[2] = false; // Execute
            //user02.Permission[3] = false; // Delete

            //User user01 = new User();
            //user01.Id = 10;
            //user01.Permission = (Permissions) 4; // 1 Byte
            //Console.WriteLine(user01.Permission);



            //User user02 = new User();
            //user02.Id = 20;
            //user02.Permission = (Permissions)10; // 
            //Console.WriteLine(user02.Permission);

            //User user03 = new User();
            //user03.Id = 30;
            //user03.Permission = (Permissions)3;
            //Console.WriteLine(user03.Permission); // Delete, Execute

            //// add permision (read) do xor with number of read
            //user03.Permission = user03.Permission ^ Permissions.Read;
            //Console.WriteLine(user03.Permission);
            
            //// deny permission (read)
            //user03.Permission ^= Permissions.Read;
            //Console.WriteLine(user03.Permission);

            //// check permission (Execute) is existed
            //if ((user03.Permission & Permissions.Execute) == Permissions.Execute)
            //{
            //    Console.WriteLine("User Has Execute Permission");
            //}
            //else
            //    Console.WriteLine("User Hasn't Execute Permission");

            //bool hasExecte = user03.Permission.HasFlag(Permissions.Execute);
            //if (hasExecte)
            //{
            //    Console.WriteLine("User Has Execute Permission");
            //}
            //else
            //    user03.Permission ^= Permissions.Execute;

            //// Check If User Has Permission (Delete) 
            //// if existed => Do Nothing
            //// if not existed => Add it
            //// Do | Or Operation
            //user03.Permission = user03.Permission | Permissions.Read;
            //Console.WriteLine(user03.Permission);

            #endregion

            #endregion
        }
    }
} 
