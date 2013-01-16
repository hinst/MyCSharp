using System;
using Point = System.Windows.Point;

using MyCSharp;

namespace MyWPF
{

	public static class PointHelper
	{

		public static Point CreateWindowsPoint(this double[] array)
		{
			Assert.Condition(array.Length == 2, () => new ArgumentException("Array length must be 2"));
			return new Point(array[0], array[1]);
		}

	}

}
