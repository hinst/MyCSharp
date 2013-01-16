using System;
using System.Windows;

namespace MyWPF
{

	public static class SizeHelper
	{

		/// <summary>
		/// 
		/// </summary>
		/// <param name="size"></param>
		/// <returns></returns>
		private static Rect ToRect(this Size size)
		{
			return new Rect(size);
		}

	}

}
