using System;
using Point = System.Windows.Point;

namespace MyTest
{

	public class TestWindowsPoint
	{

		public static void Main(string[] arguments)
		{
			var a = new Point(-1, 1);
			Console.WriteLine(a);
			var b = a;
			Console.WriteLine(b);
		}

	}

}
