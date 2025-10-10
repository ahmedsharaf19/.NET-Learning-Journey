using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Binding
{
    internal class FullTimeEmployee : Employee
    {
        #region Properties
        public decimal Salary { get; set; }
        #endregion

        #region Constructor
        public FullTimeEmployee(int id, string? name, int age, decimal salary)
        {
            Id = id;
            Name = name;
            Age = age;
            Salary = salary;
        }
        #endregion

        #region Method
        public new void GetEmployeeType()
        {
            Console.WriteLine("I am Full Time Employee");
        }
        public override void GetEmployeeData()
        {
            Console.WriteLine($"Data : Id = {Id} , Name = {Name} , Age = {Age} , Salary = {Salary:c}");
        }
        #endregion


    }
}
