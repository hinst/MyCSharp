using System;
using System.Globalization;
using System.Threading;

namespace MyCSharp
{

	public static class CurrentThreadCulture
	{

		public static void SetEnglish()
		{
			Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-us");
			Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-us");
		}

	}

}
