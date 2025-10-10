using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Built_In_Interfaces
{
    internal class Employee : ICloneable, IComparable<Employee>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Salary { get; set; }

        public Employee()
        {
            
        }

        // Copy Constructor => Special Constructor
        // Used To Make A deep Copy For Reference Type Object
        public Employee(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            Salary = employee.Salary;
        }

        public object Clone()
        {
            return new Employee() // this => Caller
            {
                Id = this.Id,
                Name = this.Name,
                Salary = this.Salary
            };
        }
        public override string ToString()
        {
            return $"Id = {Id} , Name = {Name} , Salary = {Salary}";
        }

        public int CompareTo(Employee? other)
        {
            // +Ve => This.Salary > other.Salary
            // -Ve => this.Salary < other.salary
            // 0 => this.salaty = other.salary
            //if (this.Salary > other?.Salary)
            //    return 1;
            //else if (this.Salary < other?.Salary)
            //    return -1;
            //else 
            //    return 0;
            // Equivalent to
            return this.Salary.CompareTo(other?.Salary);
        }
    }
}
