using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharp
{

    public class CriticalException
    {

        public static bool Is(Exception e)
        {
            if (e is OutOfMemoryException) 
                return true;
            if (e is AppDomainUnloadedException) 
                return true;
            if (e is BadImageFormatException) 
                return true;
            if (e is CannotUnloadAppDomainException) 
                return true;
            if (e is InvalidProgramException) 
                return true;
            if (e is System.Threading.ThreadAbortException)
                return true;
            return false;
        }

    }

}
