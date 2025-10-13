using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecEx
{
    internal static class StringFunctions
    {
        public static int GetCountOfUpperCaseChar(string str)
        {
            int Count = 0;
            if (str?.Length > 0) 
                for(int i = 0; i < str.Length; i++)
                    if (Char.IsUpper(str[i])) 
                        Count++; 
            return Count;
        }

        public static int GetCountOfLowerCaseChar(string str)
        {
            int Count = 0;
            if (str?.Length > 0)
                for (int i = 0; i < str.Length; i++)
                    if (Char.IsLower(str[i]))
                        Count++;
            return Count;
        }
    }
}
