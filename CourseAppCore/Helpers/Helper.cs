using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseAppCore.Helpers
{
    public static class Helper
    {
        public static string ToCapitalize(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;

            if (str.Length == 1) return str.ToUpper();

            return str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
        }
    }
}
