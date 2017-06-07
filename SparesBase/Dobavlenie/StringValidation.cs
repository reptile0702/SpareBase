using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparesBase
{
    class StringValidation
    {
        public static bool IsLatin(char ch)
        {
            return (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z');
        }

        public static bool IsValid(string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;


            for (int i = 0; i < s.Length; i++)
            {
                if (!IsLatin(s[i]) && s[i] != '_' && s[i] != '-' && s[i] != '.' && s[i] != '@' && !char.IsDigit(s[i]))
                    return false;
            }
            return true;
        }
    }
}
