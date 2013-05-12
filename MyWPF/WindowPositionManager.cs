using System;
using System.Windows;
using System.Configuration;

namespace MyWPF
{

	public class WindowPositionManager
	{

		public static void SetAtCenter(Window v, Window w)
		{
			v.UpdateLayout();
			w.UpdateLayout();
			w.Left = v.Left + (v.ActualWidth - w.ActualWidth) / 2;
			w.Top = v.Top + (v.ActualHeight - w.ActualHeight) / 2;
		}

	}



}
