using System;

using MyCSharp;

namespace MyTest
{

	/// <summary>
	/// Application runner
	/// </summary>
	public class MainApplication
	{

		[STAThread]
		public static int Main(string[] args)
		{
			ApplicationClassRunner.Main(args);
			return 0;
		}

	}

}
