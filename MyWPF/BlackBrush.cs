using System;
using System.Windows.Media;

namespace MyWPF
{

	public static class BlackBrush
	{

		private static SolidColorBrush instance;

		public static SolidColorBrush Instance
		{
			get
			{
				if (null == instance)
					instance = new SolidColorBrush(Colors.Black);
				return instance;
			}

		}

	}

}
