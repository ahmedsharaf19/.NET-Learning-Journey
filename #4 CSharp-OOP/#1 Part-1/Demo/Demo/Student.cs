using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    internal class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Gender Gender { get; set; }
        public Grades Grade { get; set; }
        public Branches Branche { get; set; }
    }
}
