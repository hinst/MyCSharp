using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYCSHARP
{

    public static class ClassNameHelper
    {

        public static string GetFullClassName(this object x)
        {
            const string NullClassName = "Null";
            string result = NullClassName;
            if (x != null)
            {
                Type type = x.GetType();
                result = type.FullName;
            }
            return result;
        }

    }

}
