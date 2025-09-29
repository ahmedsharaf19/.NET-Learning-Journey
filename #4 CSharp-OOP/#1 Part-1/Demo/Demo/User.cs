using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    internal class User
    {
        public int Id { get; set; }
        //public bool[] Permission { get; set; } = new bool[4];
        public Permissions Permission {get; set; }
    }
}
