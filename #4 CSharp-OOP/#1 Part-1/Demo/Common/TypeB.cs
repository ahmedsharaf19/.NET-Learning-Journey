using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    internal class TypeB
    {
        public TypeB()
        {
            TypeA typeA = new TypeA();
            // typeA.x = 1; // InValid Private Accessable within its scope only
            typeA.y = 2; // Valid // Internal is Accessable within its scope and in same project
            typeA.z = 3; // // Valid // public is Accessable within its scope and in same project
        }
    }
}
