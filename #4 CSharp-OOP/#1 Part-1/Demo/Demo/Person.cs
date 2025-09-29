using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    internal class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        //public string Gender { get; set; }
        public Gender gender { get; set; }
        // it can hold only male of female
    }
}
