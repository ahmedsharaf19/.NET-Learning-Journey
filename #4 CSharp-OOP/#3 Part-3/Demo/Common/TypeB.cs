using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class TypeB : TypeA
    {

        public void Print()
        {
            #region Without Inheritance
            //TypeA typeAObj = new TypeA();
            //typeAObj.A = 1; // invalid [private] within class only
            //typeAObj.B = 2; // valid [internal] within calss and same project only
            //typeAObj.C = 3; // valid [public] within class, project and outside project

            //typeAObj.X = 10; // invalid [private protected]  within class only
            //typeAObj.Y = 20; // invalid [protected] within class only
            //typeAObj.Z = 30; // vali [internal protected] within class and same project 
            #endregion


        }

        #region With Inheritance

        public TypeB()
        {
            //A = 1; // Invalid [Not Inherited] - Private
            B = 2; // Valid [inherited] - Internal
            C = 3;  // Valid [Inherited] - Public

            X = 10; // Inherited Private Protected => Private
            Y = 20; // Inherited Protected => Private
            Z = 30; // Inherited Internal Protected => Internal
        }
        #endregion
    }
}
