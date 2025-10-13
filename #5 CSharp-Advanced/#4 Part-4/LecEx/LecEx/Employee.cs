using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecEx
{
    internal class Employee : IComparable<Employee>
    {
        public Employee(int id, string? name, decimal salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"Id = {Id}, Name = {Name}, Salary = {Salary}";
        }

        public override bool Equals(object? obj)
        {
            Employee? employee = obj as Employee;
            if (employee is null) return false;
            return Id == employee.Id && Name == employee.Name && Salary == employee.Salary;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name,Salary);
        }

        public int CompareTo(Employee? other)
        {
            if (other is null) return 1;
            return Id.CompareTo(other.Id);
        }
    }
}
