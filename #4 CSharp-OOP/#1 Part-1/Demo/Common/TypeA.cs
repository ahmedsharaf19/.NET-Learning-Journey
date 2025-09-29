using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class TypeA // Can Show on another project 
    {
        private int x;
        internal int y;
        public int z;

        public TypeA()
        {
            x = 1; // Accessable within its scope
            y = 2; // Accessable within its scope
            z = 3; // Accessable within its scope
        }
    }
}
