using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecEx
{
    internal class FunctionReturnDelegate
    {
        public static Action DelegateAction()
        {
            return delegate { Console.WriteLine("Hello Ahmed"); };
           // return () => Console.WriteLine("Hello Ahmed");
        }

        public static Predicate<int> DelegatePredicate()
        {
            return delegate (int x) { return x > 0; };

        }

        public static Func<char[], string> DelegateFunc()
        {
            return delegate (char[] chars) { return new string(chars); };
        }
    }
}
