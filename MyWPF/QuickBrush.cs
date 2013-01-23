using System;
using System.Windows.Media;

namespace MyWPF
{

	public static class QuickBrush
	{

		private static SolidColorBrush black;

		public static SolidColorBrush Black
		{
			get
			{
				if (null == black)
					black = new SolidColorBrush(Colors.Black);
				return black;
			}

		}

		private static SolidColorBrush white;

		public static SolidColorBrush White
		{
			get
			{
				if (null == white)
					white = new SolidColorBrush(Colors.White);
				return white;
			}

		}

	}

}
