using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Inheritance
{
    internal class TypeD : TypeA
    {
        public TypeD()
        {
            A = 1; // Invalid - Not Inherited [private]
            B = 2; // Invalid - Not Inherited [Internal]
            C = 3; // Valid - Inherited [Public]

            X = 10; // Invalid - Not Inherited [Private Protected]
            Y = 20; // Valid - Inherited Protected => [Private]
            Z = 30; // valid - inherited Internal Protected => Private
        }
    }
}
