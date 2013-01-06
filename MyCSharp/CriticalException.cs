using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyCSharp
{

	public class CriticalException : Exception
	{

		/// <summary>
		/// Which exceptions are critical
		/// </summary>
		public static Type[] Types = 
			new Type[] 
			{
				typeof(NullReferenceException),
				typeof(ArgumentNullException),
				typeof(OutOfMemoryException),
				typeof(AppDomainUnloadedException),
				typeof(BadImageFormatException),
				typeof(CannotUnloadAppDomainException),
				typeof(InvalidProgramException),
				typeof(ThreadAbortException),
				typeof(CriticalException)
			};

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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="exception"> 
		/// Returns false if exception is null because no exception means no critical exception
		/// </param>
		/// <returns></returns>
		public static bool IsCritical(this Exception exception)
		{
			return exception == null ? false : CriticalException.Types.Contains(exception.GetType());
		}

	}

}
