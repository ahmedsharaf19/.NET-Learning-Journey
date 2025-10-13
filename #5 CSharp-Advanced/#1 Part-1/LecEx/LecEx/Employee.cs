using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecEx
{
    internal class Employee : IEquatable<Employee>, IComparable<Employee>
    {
       

        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Salary { get; set; }
        public Employee(int id, string? name, decimal salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        #region Operators Overloading
        //public static bool operator == (Employee left, Employee right) 
        //{
        //    // True => left.Id == right.Id and left.Name == right.Name and left.Salary == right.Salary
        //    // False => otherwise
        //    //return left.Id == right.Id && left.Name == right.Name && left.Salary == right.Salary;
        //    return left.Equals(right);
        //    // Equals of object by default compare references 
        //    // value type class inherit object overridden method 'Equals' to compare object state
        //    // Employee Inherit From Value Type class
        //}

        //public static bool operator !=(Employee left, Employee right)
        //{
        //    // True => left.Id == right.Id and left.Name == right.Name and left.Salary == right.Salary
        //    // False => otherwise
        //    //return left.Id != right.Id || left.Name != right.Name || left.Salary != right.Salary;
        //    //return !(left == right);
        //    return !left.Equals (right);
        //}

        public override string ToString()
        {
            return $"Id = {Id}, Name = {Name}, Salary = {Salary}";
        }

        //public override bool Equals(object? obj)
        //{

        //    #region Safe Way - Is Operator
        //    ////1. is operator => for checking and casting [Optional With Pattern Mathcing]obj
        //    //// true => obj is employee or type inherit from employee [casting using pattern matching]
        //    //// false => obj is not employee
        //    //if (obj is Employee employee) // check and casting
        //    //{
        //    //    return Id == employee.Id && Name == employee.Name && Salary == employee.Salary;
        //    //}
        //    //else
        //    //    return false; 
        //    #endregion

        //    #region Safe Way - as operator
        //    ////2. as operator => for casting obj to employee
        //    //Employee? employee = obj as Employee;
        //    //if (employee is not null)
        //    //{
        //    //    return Id == employee.Id && Name == employee.Name && Salary == employee.Salary;
        //    //}
        //    //else 
        //    //    return false;
        //    #endregion

        //    #region Unsafe Way Using Explicit Casting

        //    //    // Compare Object State [Id, Name, Salary] 
        //    //    Employee? employee = (Employee?)obj; // Explicit Casting
        //    //    // Unsafe - May Throw Exception in Runtime

        //    //    if (obj is not null)
        //    //    {
        //    //        return this.Id == employee.Id && this.Name == employee.Name && this.Salary == employee.Salary;
        //    //    }
        //    //    else
        //    //    {
        //    //        return false;
        //    //    }
        //    #endregion

        //}



        public override int GetHashCode()
        {
            //return this.Id.GetHashCode() + (this.Name?.GetHashCode() ?? 0) + this.Salary.GetHashCode();
            //return this.Id.GetHashCode() ^ (this.Name?.GetHashCode() ?? 0) ^ this.Salary.GetHashCode();
            return HashCode.Combine(Id, Name, Salary); // Utility Method Combine Intoduce .Net Core2.[C#7] 
        }

        public bool Equals(Employee? employee)
        {
            if (employee is not null)
            {
                return Id == employee.Id && Name == employee.Name && Salary == employee.Salary;

            }
            else 
                return false;
        }

        // CompareTo Sort Based On Salary
        public int CompareTo(Employee? employee)
        {
            // Compare Based On Salary
            // This.Salary > employee.Salary => +Ve
            // This.Salary < employee.Salary => -Ve
            // This.Salary == employee.Salary => 0
            // this != null == employee is null =>  + Ve

            if (employee is null)
                return 1;
            else 
                return this.Salary.CompareTo(employee.Salary);
        }


        // if this struct not class
        //public bool Equals(Employee employee)
        //{
        //        return Id == employee.Id && Name == employee.Name && Salary == employee.Salary;
        //}
        #endregion
    }
}
