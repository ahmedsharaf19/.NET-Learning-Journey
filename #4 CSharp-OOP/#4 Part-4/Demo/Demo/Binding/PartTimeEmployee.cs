using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Binding
{
    internal class PartTimeEmployee : Employee
    {
        #region Properties
        public decimal HourRate { get; set; }
        public int CountOfHours { get; set; }
        #endregion

        #region Constructors
        public PartTimeEmployee(int id, string? name, int age, int countOfHours, decimal hourRate)
        {
            Id = id;
            Name = name;
            Age = age;
            CountOfHours = countOfHours;
            HourRate = hourRate;
        }
        #endregion

        #region Methods
        public override void GetEmployeeData()
        {
            base.GetEmployeeData();
            Console.WriteLine($" HourRate = {HourRate:c} , Count Of Hours = {CountOfHours}");
        }

        public new void GetEmployeeType()
        {
            Console.WriteLine("I am PartTimeEmployee");
        }
        #endregion

    }
}
