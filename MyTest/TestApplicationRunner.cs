using System;

using MyCSharp;

namespace MyTest
{

	public class TestApplicationRunner
	{

		public static int Main(string[] arguments)
		{
			Console.WriteLine("Main");
			return 16;
		}

		public class Crash
		{

			public static int Main(string[] arguments)
			{
				throw new OutOfMemoryException("Out of memoree");
			}

		}

		public class Void
		{

			public static void Main(string[] arguments)
			{
				Console.WriteLine("Void");
			}

		}

	}

}
