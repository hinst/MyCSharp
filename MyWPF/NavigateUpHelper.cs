#region using System
using System;
using System.Windows;
#endregion
#region using Mine
using MyCSharp;
#endregion

namespace MyWPF
{

	public static class NavigateUpHelper
	{

		public static T LogicalNavigateUp<T>(this FrameworkElement element) where T: DependencyObject
		{
			if (element == null)
				return null;
			do
			{
				var parent = element.Parent;
				if (parent == null)
					return null;
				if (parent is T)
					return (T)parent;
				if (parent is FrameworkElement)
					element = (FrameworkElement)parent;
				else
					return null;
			}
			while (true);
		}

	}

}
