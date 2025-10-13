using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecEx
{
    internal class EmployeeNameComparer : IComparer<Employee>
    {
        public int Compare(Employee? x, Employee? y)
        {
            // x is null => -1
            // y is null => 1
            // x.Name is null =>  -1
            // y.Name is null => 1
            // x > y => +ve 
            // x < y => -ve 
            // x == y => 0 

            //if (x is null || x.Name is null) return -1;
            //else if (y is null) return 1;
            //else return x.Name.CompareTo(y.Name);

            return x?.Name?.CompareTo(y?.Name) ?? -1;
        }
    }
}
