using System;
using System.Windows;

using NLog;

namespace MyWPF
{

	public static class ControlSizeHelper
	{

		private static Logger log = LogManager.GetCurrentClassLogger();

		public static Size GetSize(this FrameworkElement element)
		{
			return new Size(element.Width, element.Height);
		}

		public static Size GetActualSize(this FrameworkElement element)
		{
			return new Size(element.ActualWidth, element.ActualHeight);
		}

	}

}
