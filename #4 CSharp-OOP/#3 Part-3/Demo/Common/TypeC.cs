using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    internal class TypeC
    {
        public void Test()
        {
            TypeB typeBObj = new TypeB();
            typeBObj.B = 2; // Valid - Internal
            typeBObj.C = 3; // valid - Public

            typeBObj.X = 10; // Invalid - [Private]
            typeBObj.Y = 20; // Invalid - [Private]
            typeBObj.Z = 30; // valid - [Internal]
        }
    }
}
