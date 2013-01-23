using System;
using System.Windows.Media;

namespace MyWPF
{
	public static class BlackPen
	{

		private static Pen instance;

		public static Pen Instance
		{
			get
			{
				if (null == instance)
					instance = new Pen(QuickBrush.Black, 1);
				return instance;
			}
		}

	}

}
