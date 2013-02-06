using System;
using System.Windows;
using System.Windows.Input;

namespace MyWPF
{

	public class MouseDrop
	{

		public void Create(FrameworkElement target, Cursor cursor)
		{
			this.target = target;
			Target.Cursor = cursor;
			Target.PreviewMouseDown += PreviewTargetMouseDown;
		}

		protected FrameworkElement target;

		public FrameworkElement Target
		{
			get
			{
				return target;
			}
		}

		void PreviewTargetMouseDown(object sender, MouseButtonEventArgs e)
		{
		}

	}


}
