using System;
using System.Windows;

namespace MyWPF
{

	public static class ControlSizeHelper
	{

		public static Size GetSize(this FrameworkElement element)
		{
			return new Size(element.Width, element.Height);
		}

	}

}
