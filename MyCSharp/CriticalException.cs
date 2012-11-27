using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharp
{

	public class CriticalException : Exception
	{

		public CriticalException(string message = null, Exception inner = null)
			:
			base
			(
				message ?? "Critical exception: " + (inner != null ? "see inner exception" : "unknown"),
				inner
			)
		{
		}

	}

	public static class CriticalExceptionHelper
    {

        public static bool IsCritical(this Exception e)
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
			if (e is CriticalException)
				return true;
            return false;
        }

    }

}
